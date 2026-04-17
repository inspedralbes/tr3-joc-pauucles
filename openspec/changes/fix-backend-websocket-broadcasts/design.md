## Context

The backend WebSocket synchronization is crucial for the Unity client's UI to reflect the current state of game rooms and player readiness. Currently, these broadcasts are either missing or not consistently triggered across different actions (create, join, ready).

## Goals / Non-Goals

**Goals:**
- Ensure `ACTUALITZAR_SALES` broadcast is sent globally after every room creation and join.
- Ensure `ROOM_UPDATED` broadcast is sent after every join and ready status change.
- Standardize the JSON structure for these broadcasts as requested:
    - `type: "ACTUALITZAR_SALES"` with `sales: llistaSales`
    - `type: "ROOM_UPDATED"` with `room: salaActualitzada`
- Improve logging for better debugging of WebSocket events.

**Non-Goals:**
- Refactoring the entire WebSocket architecture or moving to a library like Socket.io.
- Changing the C# client's parsing logic (the backend must match the client's expectations).

## Decisions

- **Consistent JSON Keys**: We will update `broadcastRoomUpdates` to use the key `sales` (instead of `games`) and the type `ACTUALITZAR_SALES` to match the user's requirement.
- **Explicit Broadcast Logic**:
    - In `create`, call `broadcastRoomUpdates` with a specific "Broadcast CREAR_SALA enviat" log.
    - In `join`, call `broadcastToRoom` followed by `broadcastRoomUpdates`, with a "Broadcast JOIN_ROOM enviat" log.
    - In `server.js` (READY handler), ensure `broadcastToRoom` is called before `checkGameStart`.
- **WSS Reference**: Ensure the `wss` instance is correctly passed via the `GameController` constructor (already established but will be verified).

## Risks / Trade-offs

- **[Risk] Client Incompatibility**: Changing the JSON key from `games` to `sales` might break the client if it was already expecting `games`. → **Mitigation**: The user explicitly requested `sales`, so we will follow the directive.
- **[Risk] Performance**: Broadcasting to all clients (`wss.clients.forEach`) on every action. → **Mitigation**: For the current scale (small number of concurrent players), this is acceptable.
