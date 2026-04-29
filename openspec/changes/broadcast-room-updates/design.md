## Context

The backend is built with Express and `ws`. Game rooms are stored in MongoDB. Currently, room creation is handled via an HTTP POST request, but updates should be pushed to clients via WebSockets.

## Goals / Non-Goals

**Goals:**
- Broadcast the current list of pending rooms to all connected clients whenever a new room is created.
- Ensure the broadcast happens only after the room is successfully saved in MongoDB.
- Maintain real-time synchronization between Unity Build and Unity Editor.

**Non-Goals:**
- Implementing room-specific chat or game-state synchronization (out of scope for this task).
- Changing the existing HTTP API structure.

## Decisions

### 1. WebSocket Server Access
The `wss` instance initialized in `server.js` will be made accessible to the `GameController`.
- **Rationale**: The controller needs to trigger the broadcast after the `create` logic finishes.
- **Implementation**: The `GameController` will receive `wss` in its constructor or as a method argument.

### 2. Broadcast Functionality
A utility function or method will iterate over `wss.clients` and send a JSON string.
- **Payload Structure**: `{ type: "ACTUALITZAR_SALES", games: [...] }`
- **Rationale**: Standardizing the message type allows the Unity client to easily route the message.

### 3. Data Retrieval
The updated list will be fetched using `gameRepository.findAllWaiting()` (mapped to `getAllPending` in requirements).
- **Rationale**: Ensures the broadcasted list is accurate and reflects the latest database state.

## Risks / Trade-offs

- **[Risk]** → Broadcasting to many clients might impact performance.
- **[Mitigation]** → For this project scope, the number of clients is expected to be small. We only broadcast on room creation events.
- **[Risk]** → Dead WebSocket connections in the `wss.clients` set.
- **[Mitigation]** → Check for `client.readyState === WebSocket.OPEN` before sending.
