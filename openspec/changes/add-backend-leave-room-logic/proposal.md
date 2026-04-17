## Why

Actualment el servidor no gestiona la sortida dels jugadors de les sales de joc. Això provoca que les sales es mantinguin actives indefinidament i amb dades obsoletes encara que els jugadors n'hagin sortit.

## What Changes

- Implementació d'un listener de missatges al servidor WebSocket.
- Suport per al missatge de tipus `leave_room`.
- Lògica per eliminar jugadors de la llista de `players` d'una sala.
- Lògica per esborrar completament una sala de la base de dades si es queda sense jugadors.

## Capabilities

### New Capabilities
- `backend-room-exit-management`: Gestió de la sortida de jugadors i neteja de sales buides al backend.

### Modified Capabilities
- Cap.

## Impact

- `backend/src/server.js`: S'afegeix la gestió de missatges de WebSocket.
- Base de dades (MongoDB): Es modifiquen o eliminen documents de la col·lecció `games`.
