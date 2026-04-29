## Context

La personalització visual i la sincronització de dades multijugador són claus per a la jugabilitat. Cal unificar les solucions de Singleton i moviment que s'han anat proposant en un sistema coherent basat en colors d'equip.

## Goals / Non-Goals

**Goals:**
- Implementar un sistema de prefabs per color (Vermell, Verd, Blau, Groc).
- Assignar el color correcte basant-se en l'equip (A/B) i el color de la sala.
- Garantir la persistència de la xarxa.
- Sincronitzar els noms (Nametags) i l'orientació (flipX).

**Non-Goals:**
- Implementar canvis de color en temps real durant la partida (el color s'assigna en el spawn).
- Canviar la infraestructura del backend (seguim amb broadcasts globals de moviment).

## Decisions

### 1. Diccionari de Colors al GameManager
El `GameManager` tindrà referències directes a prefabs per als colors més comuns.
- **Racional:** Facilita l'assignació ràpida a l'editor d'Unity i permet escalar a més colors si cal.

### 2. Lògica de selecció de color
En iniciar la partida, el client consultarà `WebSocketClient.Team` (A/B) i els colors definits a `GameData` per a la sala actual per determinar quin prefab instanciar.

### 3. Sincronització de Moviment Refinada
El missatge `PLAYER_MOVE` inclourà `flipX` com a booleà.
- **Racional:** Evita haver de calcular la direcció a cada client receptor, estalviant CPU i garantint que l'orientació visual és idèntica a l'original.

## Risks / Trade-offs

- **[Risk]** Si no s'assignen tots els prefabs de color al `GameManager`, el spawn podria fallar. -> **Mitigation:** S'afegirà un prefab per defecte (ex: blanc o gris) per si el color rebut no està mapejat.
- **[Trade-off]** `DontDestroyOnLoad` en el `MenuManager` requereix una neteja acurada de les referències de la UI en canviar d'escena.
