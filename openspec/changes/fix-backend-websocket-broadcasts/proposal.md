## Why

The backend WebSocket broadcasts are currently failing or inconsistent, preventing the game lobby and room UIs from updating in real-time when rooms are created, joined, or players set themselves as ready. This creates a disconnected user experience where manual refreshes are required to see state changes.

## What Changes

- **Reliable Lobby Synchronization**: Implement mandatory `ACTUALITZAR_SALES` (broadcast of all 'waiting' rooms) after every room creation and join operation.
- **Immediate Room Feedback**: Implement mandatory `ROOM_UPDATED` broadcasts immediately after a player joins a room or changes their ready status.
- **WebSocket Server Accessibility**: Ensure the `wss` instance is correctly injected or accessible in all relevant controllers and handlers.
- **Enhanced Observability**: Add specific console logs to track when broadcasts are triggered (e.g., "Broadcast CREAR_SALA enviat", "Broadcast JOIN_ROOM enviat").

## Capabilities

### New Capabilities
- `realtime-broadcast-reliability`: Ensures guaranteed delivery of game state updates (creation, joining, ready status) via WebSockets to all relevant clients.

### Modified Capabilities
- None

## Impact

- **Affected Code**: `GameController.js` (or equivalent), `server.js` (WebSocket message handling).
- **APIs**: WebSocket `READY` message, REST endpoints for room creation and joining.
- **System**: Real-time communication layer and UI responsiveness.
