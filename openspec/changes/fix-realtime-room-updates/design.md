## Context

The backend uses a combination of REST APIs and WebSockets. While some operations (like room creation) are initiated via REST, the updates must be propagated to all interested clients via WebSockets. Currently, the propagation is incomplete in some key flows (joining a room, ready state changes).

## Goals / Non-Goals

**Goals:**
- Guarantee that every room creation results in an immediate `room_list` broadcast.
- Guarantee that every room join results in both a `room_list` and a `ROOM_UPDATED` broadcast.
- Guarantee that every ready state change results in a `ROOM_UPDATED` broadcast and optionally a `room_list` broadcast.

**Non-Goals:**
- Implementing room-based rooms in the `ws` server (keeping the "broadcast to all" simple approach for now as per current architecture).
- Refactoring the networking to use `socket.io` or similar.

## Decisions

- **Consistent Broadcast Calls**: Place `broadcastRoomUpdates()` calls immediately after any repository operation that changes the list of waiting rooms.
- **Immediate Room Feedback**: Call `broadcastToRoom()` in the `join` method of `GameController` to notify existing members of the room about the new participant.
- **Awaiting Broadcasts**: Ensure all broadcast calls are awaited to prevent race conditions where the response is sent before the broadcast is triggered.

## Risks / Trade-offs

- **[Risk] Performance at Scale** → Broadcasting all updates to all connected clients can be expensive as the number of clients grows.
- **[Mitigation]** For this phase, the number of clients is expected to be small. In the future, a "room" or "topic" based subscription model should be implemented.
