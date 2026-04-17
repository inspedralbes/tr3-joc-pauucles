## Why

Real-time room synchronization is currently broken because `this.wss` is `undefined` within the `GameController`, preventing critical state updates (room creation, joins, and ready status) from being broadcast to the frontend. Fixing this is essential for a functional multiplayer lobby and game transitions.

## What Changes

- **Fix Dependency Injection**: Ensure the WebSocket server (`wss`) is correctly passed and maintained within the `GameController` instance.
- **Enhanced Broadcasting**: Update `broadcastRoomUpdates` and `broadcastToRoom` to use the exact message formats required by the frontend (`ACTUALITZAR_SALES` and `ROOM_UPDATED`).
- **Improved Observability**: Add specific logging (`console.log('Estat wss:', !!this.wss)`) and client count logs to verify WebSocket health during broadcasts.
- **Atomic Operations**: Guarantee that all state-changing actions (`CREATE_ROOM`, `JOIN_ROOM`, and `READY`) trigger immediate broadcasts after database persistence.

## Capabilities

### New Capabilities
- `room-sync`: Robust real-time synchronization of room states and room lists via WebSockets.

### Modified Capabilities
- None.

## Impact

- `backend/src/server.js`: Initialization and passing of the WebSocket instance.
- `backend/src/controllers/GameController.js`: Implementation of broadcast logic and logging.
- `backend/src/routes/gameRoutes.js`: Routing and controller instantiation.
- Frontend: Will start receiving expected real-time updates for lobby and room changes.
