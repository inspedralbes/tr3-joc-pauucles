## Why

El backend actualment utilitza `socket.io`, que afegeix una capa d'abstracció i sobrecàrrega que no és estrictament necessària per a aquest projecte. La migració a WebSockets purs (`ws`) simplificarà la comunicació, reduirà les dependències i permetrà un control més directe sobre el protocol de xarxa.

## What Changes

- Desinstal·lació de `socket.io` i instal·lació de `ws` al backend.
- Refactorització de `backend/src/server.js` per utilitzar el servidor de `ws`.
- Implementació d'un sistema bàsic de gestió de connexions amb `ws`.
- Manteniment de la funcionalitat existent de l'API Express al mateix port.
- **BREAKING**: Els clients que utilitzin `socket.io-client` ja no podran connectar-se; hauran de canviar a l'API nativa de WebSocket.

## Capabilities

### New Capabilities
- `pure-websocket-communication`: Implementació de la comunicació bidireccional utilitzant el protocol WebSocket estàndard sense llibreries d'abstracció.

### Modified Capabilities
- Cap (La lògica de negoci es manté igual, només canvia el transport).

## Impact

- `package.json` (backend): Canvi de dependències.
- `backend/src/server.js`: Refactorització de la inicialització del servidor.
- Clients (Unity/Frontend): Caldrà actualitzar la forma en què es connecten al backend.
