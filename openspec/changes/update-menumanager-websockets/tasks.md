## 1. Update MenuManager.cs Dependencies

- [x] 1.1 Add `using SocketIOClient;` and `using SocketIOUnity;` namespaces at the top of the file.

## 2. Implement WebSocket Variable and Initialization

- [x] 2.1 Declare a private class-level variable `private SocketIOUnity socket;`.
- [x] 2.2 Create the `void Start()` method after the existing class variable declarations.
- [x] 2.3 Inside `Start()`, initialize the `socket` with the URI `http://localhost:3000`.

## 3. Register Event Listeners and Connect

- [x] 3.1 In `Start()`, register the `OnConnected` event to log "Connexió Socket.io establerta amb èxit!".
- [x] 3.2 In `Start()`, register the `OnDisconnected` event to log "Socket desconnectat".
- [x] 3.3 Call `socket.Connect()` at the end of the `Start()` method.

## 4. Verification

- [x] 4.1 Verify that the code compiles without errors in Unity.
- [x] 4.2 (Manual) Verify that the console logs the connection status when the scene starts (requires backend running).
