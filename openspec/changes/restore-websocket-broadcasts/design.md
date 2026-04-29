## Context

The current backend implementation has inconsistent broadcast coverage. While the `GameController` and `server.js` have access to the `wss` (WebSocket Server) instance, several state-changing operations omit the necessary triggers to notify other clients. This design centralizes the broadcast logic using existing helpers like `broadcastRoomUpdates` and `broadcastToRoom`.

## Goals / Non-Goals

**Goals:**
- Ensure every `createGame` call triggers a lobby update.
- Ensure every `joinGame` call triggers both room and lobby updates.
- Ensure every `setReady` call triggers a room update (and lobby/start logic if applicable).
- Ensure every `leaveGame` / disconnect call triggers necessary updates.

**Non-Goals:**
- Refactoring the WebSocket server to use `socket.io` or rooms/namespaces (staying with the current "broadcast to all and filter on client" pattern).
- Modifying the MongoDB schema.

## Decisions

- **Direct Controller Integration**: Broadcasts for REST-initiated actions (`create`, `join`) will be handled within the `GameController` immediately after successful service/repository calls.
- **WebSocket Listener Integration**: Broadcasts for WebSocket-initiated actions (`READY`, `leave_room`) will be handled within the `server.js` connection listener to maintain high responsiveness.
- **Consistency in Naming**: Although the user mentions `ACTUALITZAR_SALES`, we will map this to the existing `broadcastRoomUpdates` (which sends `type: "room_list"`) as expected by the C# `MenuManager.cs`. Similarly, `ROOM_UPDATED` will be used for room member sync.

## Risks / Trade-offs

- **[Risk] Broadcast Overhead**: Sending room lists to all connected clients on every join/leave might become a bottleneck. → **Mitigation**: Current player counts are low; if this becomes an issue, we can implement a subscription-based model later.
- **[Risk] Race Conditions**: Sending a broadcast before the database update is fully committed. → **Mitigation**: Always `await` the repository/service operation before calling the broadcast helper.
