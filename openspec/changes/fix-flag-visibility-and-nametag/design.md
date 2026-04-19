## Context

El projecte presenta un problema de temporització en la inicialització del combat. Quan els jugadors entren a l'escena, el `Start()` s'executa immediatament, però les dades del WebSocket (necessàries per saber els colors d'equip i la identitat del jugador) poden trigar uns mil·lisegons a sincronitzar-se. Això provoca que les banderes no s'instanciïn o ho facin amb dades incorrectes, i que el personatge local no mostri el seu nom.

## Goals / Non-Goals

**Goals:**
- Retardar la instanciació d'elements crítics fins que les dades de xarxa estiguin llestes.
- Assegurar que el nom del jugador local es vegi correctament.
- Garantir una mida visual consistent per a les banderes (dinosaures).

**Non-Goals:**
- Canviar el protocol de comunicació.
- Modificar el comportament de joc de les banderes (captura/minijocs).

## Decisions

### 1. Corrutina EsperarDadesISpawn
En lloc de cridar a `InstanciarBanderes()` directament al `Start`, s'iniciarà la corrutina `EsperarDadesISpawn()`.
- **Racional**: L'ús de `yield return new WaitUntil(...)` és la forma més neta en Unity d'aturar l'execució d'un mètode fins que es compleixin condicions asíncrones d'altres scripts (`WebSocketClient` i `MenuManager`).

### 2. Actualització del Nametag Local
Dins de `ConfigurarLocalPlayerVisuals()`, s'accedirà als fills del jugador local.
- **Racional**: El component de text sol estar en un objecte fill (ex: el canvas del Nametag). Utilitzar `GetComponentInChildren` assegura la troballa independentment de l'estructura exacta del prefab, sempre que contingui un `TextMeshPro`.

### 3. Escalabilitat Forçada
Es modificarà `InstanciarBanderes()` per aplicar una escala de `(3, 3, 1)` o `(4, 4, 1)` a les instàncies creades.
- **Racional**: Alguns prefabs de dinosaures són massa petits respecte als jugadors. Centralitzar l'escala al codi garanteix que tots els colors es vegin igual de grans sense haver de modificar manualment cada prefab.

## Risks / Trade-offs

- **[Risk]** Si la connexió falla permanentment, la partida quedarà "buida" de banderes. -> **Mitigation**: Es podria afegir un timeout a la corrutina per procedir amb dades locals o mostrar un missatge d'error.
- **[Trade-off]** Esperar a les dades pot causar un petit retard visual (poques dècimes de segon) en el spawn de les banderes després d'entrar a l'escena.
