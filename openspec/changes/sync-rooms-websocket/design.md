## Context

The `MenuManager.cs` script currently handles UI interactions and networking via HTTP (`UnityWebRequest`) and WebSockets (`NativeWebSocket`). The room list is fetched via HTTP on lobby entry. We need to extend the WebSocket message handling to support real-time updates of the room list.

## Goals / Non-Goals

**Goals:**
- Listen for room update messages via WebSocket.
- Update the `ListView` (`llistaPartides`) dynamically on the main thread.
- Reuse existing `GameData` and `GameListWrapper` structures for consistency.

**Non-Goals:**
- Rewriting the entire networking layer.
- Changing the UI layout of the lobby.

## Decisions

### 1. Main Thread Dispatching
WebSocket callbacks in `NativeWebSocket` run on a background thread. We MUST use the existing `EnqueueMainThread` pattern in `MenuManager.cs` to perform UI updates.
- **Rationale**: Unity's UI Toolkit (and most Unity APIs) is not thread-safe.

### 2. Message Format
We will define a JSON message structure identifying the type of update.
- **Structure**: `{"type": "room_list", "games": [...]}`.
- **Rationale**: Allows the client to distinguish between different types of real-time notifications (room updates, player ready status, etc.).

### 3. UI Refresh Strategy
When a new room list is received, we will re-assign `llistaPartides.itemsSource` and call `llistaPartides.Rebuild()`.
- **Rationale**: Simplest way to ensure the UI stays synchronized with the server's state.

## Risks / Trade-offs

- **[Risk]** → Frequent updates could cause UI flickering or performance issues.
- **[Mitigation]** → The server should throttle updates or only send them when a room is created/deleted/filled.
- **[Risk]** → Message parsing errors if the JSON structure changes.
- **[Mitigation]** → Use `try-catch` blocks and validate message types before processing.
