## Why

The backend currently lacks several critical real-time updates via WebSockets, leading to a disconnected experience where clients (lobby and game rooms) do not receive immediate notifications for room creation, joining, ready status, or player departures. This change restores these "lost" broadcasts to ensure all clients stay synchronized with the latest MongoDB state.

## What Changes

- **Room Creation Broadcast**: Trigger a global lobby update (`room_list` / `ACTUALITZAR_SALES`) immediately after a new room is saved to MongoDB.
- **Join Room Broadcast**: Trigger both a room-specific update (`ROOM_UPDATED`) and a global lobby update when a player joins a room.
- **Ready State Broadcast**: Mandate a `ROOM_UPDATED` broadcast when a player sets their status to "READY", ensuring it occurs before checking for game start conditions.
- **Leave/Disconnect Broadcast**: Trigger both `ROOM_UPDATED` (if the room persists) and `room_list` updates when a player leaves or disconnects.
- **Retention of Game Start Logic**: Ensure existing `PARTIDA_INICIADA` logic is preserved while integrating the missing broadcast calls.

## Capabilities

### New Capabilities
- `realtime-lobby-sync`: Automated synchronization of the game lobby across all clients upon any room state change.
- `room-member-sync`: Immediate notification of member status changes (join, ready, leave) to all players within a specific game room.

### Modified Capabilities
- None

## Impact

- **Affected Code**: `backend/src/server.js`, `backend/src/controllers/GameController.js`, `backend/src/services/GameService.js`.
- **APIs**: `/games/create`, `/games/join`, and WebSocket message handlers for `READY` and `leave_room`.
- **System**: Real-time communication layer and client-side UI responsiveness.
