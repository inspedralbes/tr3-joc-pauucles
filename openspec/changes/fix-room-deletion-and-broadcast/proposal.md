## Why

Actualment, la lògica d'eliminació de sales no és prou robusta (no s'elimina quan el host marxa o la sala queda buida) i els broadcasts de llista de sales no arriben a tots els clients connectats, cosa que provoca desincronitzacions en el Lobby.

## What Changes

- **Lògica d'eliminació**: S'actualitza `GameService.js` perquè una sala s'elimini si el `host` marxa o si no queden jugadors.
- **Broadcast Global**: S'assegura que `ACTUALITZAR_SALES` s'enviï a TOTS els clients connectats sense excepcions a `GameController.js` i `server.js`.
- **Sincronització de Lobby**: Es garanteix un broadcast global immediat després de qualsevol eliminació de sala.

## Capabilities

### New Capabilities
- `room-lifecycle-management`: Gestió automàtica del cicle de vida de les sales (creació, eliminació per abandonament).

### Modified Capabilities
- `room-sync`: Es modifiquen els requeriments de broadcast per ser globals i sense filtres de destinatari.

## Impact

- `backend/src/services/GameService.js`: Canvi en la lògica de `leaveGame`.
- `backend/src/controllers/GameController.js`: Canvi en el mètode de broadcast per ser realment global.
- `backend/src/server.js`: Revisió de la gestió de WebSockets per assegurar l'enviament a tots els clients.
- Protocol: Es garanteix que qualsevol canvi en la disponibilitat de sales es notifica a tothom.
