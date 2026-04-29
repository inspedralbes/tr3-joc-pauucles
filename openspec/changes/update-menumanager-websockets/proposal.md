## Why

This change is necessary to establish a real-time communication channel between the Unity client and the backend server. Using WebSockets (Socket.io) allows the game to synchronize state, manage lobbies, and handle multiplayer interactions more efficiently than standard HTTP requests.

## What Changes

- **Update `MenuManager.cs`**: Add `using SocketIOClient;` and `using SocketIOUnity;` namespaces.
- **Socket Initialization**: Add a private `SocketIOUnity socket` variable and initialize it in the `Start()` method with the server URI (`http://localhost:3000`).
- **Event Listeners**: Implement event handlers for `OnConnected` and `OnDisconnected` to log the connection status.
- **Connection Logic**: Explicitly call `socket.Connect()` at the end of the `Start()` method to initiate the connection.

## Capabilities

### New Capabilities
- `websocket-core-connection`: Handles the initialization and lifecycle of the Socket.io connection in the main menu.

### Modified Capabilities
- (None)

## Impact

- **Affected Code**: `MenuManager.cs` in the Unity project.
- **Dependencies**: Requires the `SocketIOUnity` and `SocketIOClient` libraries to be present in the project.
- **Systems**: Backend server must be running and listening for Socket.io connections on `http://localhost:3000`.
