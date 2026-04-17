## Why

Currently, when a new game room is created, other connected clients (like the Unity Editor or other builds) do not receive real-time updates of the available rooms. They have to manually refresh or enter the lobby again to see new rooms. Implementing a WebSocket broadcast will keep all clients synchronized in real-time.

## What Changes

- **Broadcast Logic**: Update the room creation flow to broadcast the updated list of pending rooms to all connected WebSocket clients.
- **WebSocket Integration**: Pass the `wss` (WebSocket Server) instance or a broadcast function to the `GameController` so it can trigger notifications.
- **Event Type**: Define a specific message type `ACTUALITZAR_SALES` for these real-time updates.

## Capabilities

### New Capabilities
- `broadcast-room-updates`: Real-time broadcasting of room list updates to all connected clients.

### Modified Capabilities
<!-- No requirement changes to existing specs -->

## Impact

- `backend/src/server.js`: Initialize WebSocket server and potentially pass it to routes/controllers.
- `backend/src/controllers/GameController.js`: Call the broadcast logic after successful room creation.
- `backend/src/routes/gameRoutes.js`: Update initialization to inject WebSocket dependencies.
