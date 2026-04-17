## Why

Currently, the game lobby and room waiting screens do not always update in real-time when rooms are created, joined, or when players set themselves as ready. This leads to a poor user experience where players have to manually refresh or wait for unrelated events to see updates.

## What Changes

- **Room Creation Broadcast**: Ensure that creating a room immediately triggers a broadcast of the updated waiting rooms list to all clients in the lobby.
- **Join Room Broadcast**: Update the `join` logic to broadcast both the updated lobby list and a specific `ROOM_UPDATED` event to players already in the room.
- **Ready State Broadcast**: Ensure that setting a player as "READY" triggers both the specific `ROOM_UPDATED` event and a general lobby update if necessary.
- **Code Consolidation**: Ensure all critical game state changes (create, join, ready, leave) consistently use the broadcast system.

## Capabilities

### New Capabilities
- `realtime-room-updates`: Real-time synchronization of room lists and room member status via WebSockets.

### Modified Capabilities
- None

## Impact

- **Affected Code**: `backend/src/controllers/GameController.js`, `backend/src/server.js`.
- **APIs**: `/api/games/create`, `/api/games/join`, and WebSocket `READY` handler.
- **System**: Real-time communication layer.
