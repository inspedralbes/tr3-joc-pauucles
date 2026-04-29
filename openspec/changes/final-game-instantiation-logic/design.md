## Context

El `GameManager` és el responsable de coordinar els elements de l'escena en iniciar la partida. Fins ara, les banderes i els personatges amb skins no s'instanciaven de forma dinàmica basant-se en les dades de la sala (obtingudes del backend via `MenuManager`).

## Goals / Non-Goals

**Goals:**
- Automatitzar l'aparició de les banderes segons els colors d'equip.
- Centralitzar la instanciació de jugadors (locals i remots) mitjançant un mètode genèric que gestioni les skins.
- Garantir que el jugador local apareix en el spawn correcte amb la seva skin.

**Non-Goals:**
- Implementar la lògica de joc de "captura" (només instanciació).
- Sincronitzar la instanciació d'objectes no personatges per xarxa (banderes són locals per a cada client per ara).

## Decisions

### 1. Mapeig de Colors a Prefabs
S'utilitzarà un `switch` dins de `InstanciarBanderes()` per traduir els strings del backend ("Blau", "Vermell", "Verd", "Groc") als prefabs corresponents (`banderaBlava`, `banderaVermella`, etc.).
- **Racional**: És una solució directa i fàcil de mantenir per a un conjunt limitat de colors.

### 2. Mètode InstanciarJugador genèric
Es crea `InstanciarJugador(string skinName, Transform spawnPoint)` que retorna el component `Player` de l'objecte instanciat.
- **Racional**: Permet reutilitzar la mateixa lògica tant per al spawn inicial com per a possibles spawns de jugadors remots que s'uneixin més tard.

### 3. Offset de Banderes
Les banderes s'instanciaran amb un offset de `+2` en l'eix X respecte al punt de spawn.
- **Racional**: Evita que la bandera i el jugador apareguin exactament en la mateixa posició, facilitant la visibilitat inicial.

## Risks / Trade-offs

- **[Risk]** Si les claus de color del backend no coincideixen exactament amb els casos del `switch` (ex: "rojo" vs "Vermell"), la bandera no apareixerà. -> **Mitigation**: Es farà una comparació en minúscules i es contemplaran sinònims comuns o valors per defecte.
- **[Trade-off]** Instanciar les banderes localment en cada client simplifica la xarxa però requereix que les dades de la sala estiguin sincronitzades prèviament.
