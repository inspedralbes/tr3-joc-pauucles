## 1. WebSocket Integration in Backend

- [x] 1.1 Update `backend/src/server.js` to export or pass the `wss` instance to relevant modules.
- [x] 1.2 Update `backend/src/routes/gameRoutes.js` to receive `wss` and pass it to `GameController`.
- [x] 1.3 Update `GameController` constructor to accept and store the `wss` reference.

## 2. Broadcast Implementation

- [x] 2.1 Add a `broadcastRoomUpdates` method to `GameController`.
- [x] 2.2 Implement the client loop using `wss.clients.forEach` with `readyState` checks.
- [x] 2.3 Integrate the broadcast call into the `create` method of `GameController` after successful room creation.

## 3. Verification

- [x] 3.1 Verify that creating a room triggers the broadcast logic in the server logs.
- [x] 3.2 Ensure the JSON message structure matches `{ type: "ACTUALITZAR_SALES", games: [...] }`.
