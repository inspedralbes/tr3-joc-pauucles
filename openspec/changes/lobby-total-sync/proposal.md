## Why

Actualment, el lobby no es sincronitza en temps real quan els jugadors canvien el seu estat (join, ready o leave). Això provoca que la llista de jugadors i el comptador de la sala no reflecteixin la realitat per a tots els participants, dificultant la coordinació per començar la partida.

## What Changes

- **Backend (Node.js)**: 
    - Implementar broadcast `ROOM_UPDATED` en els esdeveniments de `join` i `READY`.
    - Afegir esdeveniment `LEAVE_ROOM` per treure jugadors de la base de dades (MongoDB) i fer broadcast de l'actualització.
    - Eliminar la sala automàticament si es queda buida (0 jugadors) i fer broadcast de `ACTUALITZAR_SALES`.
- **Frontend (Unity)**:
    - Vincular el botó de tancar sala per enviar el missatge `LEAVE_ROOM` via WebSocket.
    - Processar el missatge `ROOM_UPDATED` a `WebSocketClient.cs` i `MenuManager.cs` per repintar la llista de jugadors.
    - Mostrar visualment l'estat de preparat: "(Llest)" si `isReady` és true o "(Esperant)" si és false.

## Capabilities

### New Capabilities
- `lobby-room-sync`: Gestió de la sincronització de l'estat dels jugadors a la sala mitjançant broadcasts de WebSocket i gestió de l'abandonament de sales.
- `unity-lobby-refresh`: Processament de les actualitzacions de sala al client d'Unity per mantenir la UI (llista de jugadors i estats) sempre al dia.

### Modified Capabilities
- Cap.

## Impact

- **Backend**: Controladors i serveis de gestió de sales i WebSockets.
- **Frontend**: `MenuManager.cs` per a la UI del lobby i `WebSocketClient.cs` per a la recepció de missatges.
- **Base de dades**: MongoDB (col·lecció de sales/games).
