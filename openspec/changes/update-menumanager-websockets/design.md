## Context

The Unity client currently relies on polling via `UnityWebRequest` to update the game lobby and list of active games. This is inefficient and results in a delayed user experience. Integrating WebSockets using the `SocketIOUnity` library will provide a foundation for real-time updates and more responsive multiplayer interactions.

## Goals / Non-Goals

**Goals:**
- Add `SocketIOClient` and `SocketIOUnity` support to `MenuManager.cs`.
- Initialize a persistent WebSocket connection to the local backend server (`http://localhost:3000`).
- Provide basic console feedback for connection status (connected/disconnected).

**Non-Goals:**
- Implementing reconnection logic (auto-retry).
- Migrating existing HTTP polling logic to WebSockets in this specific change.
- Handling complex socket events (e.g., room joining, game start) beyond basic connection lifecycle.

## Decisions

- **Namespace Inclusion**: Add `using SocketIOClient;` and `using SocketIOUnity;` at the top of `MenuManager.cs`.
- **Class Variable**: Define `private SocketIOUnity socket;` as a class-level variable to maintain the connection throughout the scene lifecycle.
- **Initialization in `Start()`**: Since `MenuManager.cs` currently lacks a `Start()` method, it will be added to handle the socket setup. This ensures the socket is initialized once when the component becomes active.
- **Server URI**: Hardcode `http://localhost:3000` for development purposes, matching the current backend setup.
- **Event Subscription**: Use the `+=` operator to subscribe to `OnConnected` and `OnDisconnected` events before calling `Connect()`.

## Risks / Trade-offs

- **[Risk] Connection Failure**: If the backend server is not running or is unreachable, the socket will fail to connect.
- **[Mitigation]**: Implement `Debug.Log` statements to provide immediate visibility in the Unity Editor console during development.
- **[Trade-off] Hardcoded URI**: Using a hardcoded URI limits flexibility but simplifies the initial integration. Future refactoring can move this to a configuration file or environment variable.
