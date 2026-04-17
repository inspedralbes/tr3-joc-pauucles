## Why

Actualment, quan es carrega l'escena 'Bosque', tots els jugadors apareixen a la mateixa posició per defecte, el que no permet una distribució estratègica per equips. Aquest canvi implementa un sistema de gestió de la partida que distribueix els jugadors en punts de spawn específics segons el seu equip assignat.

## What Changes

- **Nou script GameManager.cs**: Centralitzarà la lògica d'inici de partida a l'escena de joc.
- **Detecció d'Equip**: El sistema llegirà el valor de `WebSocketClient.Team` per saber on ubicar el jugador.
- **Punts de Spawn Dinàmics**: Cerca d'objectes a l'escena per nom (`SpawnEquip1`, `SpawnEquip2`) o Tags per identificar les zones de sortida.
- **Posicionament Aleatori**: Selecció d'un punt a l'atzar dins de la llista de punts de l'equip corresponent per evitar que tots els jugadors d'un mateix equip apareguin exactament al mateix lloc.
- **Teletransport del Jugador**: Actualització del transform del prefab 'Woodcutter' a la posició seleccionada en carregar l'escena.

## Capabilities

### New Capabilities
- `team-based-spawning`: Gestiona la ubicació inicial dels jugadors basada en l'equip al qual pertanyen dins de l'escena de combat.

### Modified Capabilities
- Cap.

## Impact

- **Codi**: Nou script `GameManager.cs`.
- **Assets**: Cal que l'escena 'Bosque' contingui objectes amb els noms o tags acordats per als spawns.
- **Flux**: Els jugadors ja no apareixeran amuntegats al punt (0,0,0) o la posició de disseny.
