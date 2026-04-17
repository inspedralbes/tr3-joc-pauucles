## Why

Actualment, el backend no gestiona correctament l'estat de preparació (READY) dels jugadors ni el tret de sortida de la partida (PARTIDA_INICIADA) de forma sincronitzada. Això impedeix que el joc transicioni correctament del lobby a l'escena de combat quan tots els jugadors estan llestos. A més, l'assignació d'equips en unir-se a una sala és genèrica i no respecta l'equilibri bàsic entre els equips A i B.

## What Changes

- **Lògica de READY**: Processament del missatge WebSocket `READY` per actualitzar l'estat `isReady` del jugador a la base de dades.
- **Sincronització de Sala**: Emissió de broadcast `ROOM_UPDATED` en cada canvi d'estat de preparació.
- **Inici de Partida Automàtic**: Verificació de sala plena i tots llestos per canviar l'estat a `playing` i notificar als clients amb `PARTIDA_INICIADA`.
- **Assignació d'Equips Intel·ligent**: Millora de la ruta HTTP `/join` per assignar automàticament el segon jugador a l'equip contrari del host (A -> B).

## Capabilities

### New Capabilities
- `game-start-sequencing`: Gestió del flux des que els jugadors estan llestos fins que la partida es considera iniciada al servidor.
- `team-balancing-on-join`: Lògica d'assignació d'equips automàtica per assegurar enfrontaments 1vs1 o equilibrats en unir-se a una sala.

### Modified Capabilities
- Cap (actualització técnica de la infraestructura de sales).

## Impact

- **Backend**: `GameController.js`, `GameService.js` i gestió de missatges a `server.js`.
- **Database**: Actualització d'estats a la col·lecció `games`.
- **Frontend**: Unity rebrà els missatges necessaris per canviar d'escena i configurar la identitat del jugador.
