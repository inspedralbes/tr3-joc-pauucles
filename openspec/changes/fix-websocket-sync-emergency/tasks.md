## 1. WebSocket Instance & Controller Setup

- [x] 1.1 Verify `wss` injection in `backend/src/server.js` and `backend/src/routes/gameRoutes.js` to ensure the instance is correctly passed to the controller.
- [x] 1.2 Add a debug log in the `GameController` constructor to verify the `wss` instance is received during initialization.

## 2. Standardize Broadcast Logic in GameController.js

- [x] 2.1 Update `broadcastRoomUpdates` to include `console.log('Estat wss:', !!this.wss)` and log the number of clients reached.
- [x] 2.2 Ensure `broadcastRoomUpdates` sends exactly `{ type: 'ACTUALITZAR_SALES', sales: llistaSales }`.
- [x] 2.3 Update `broadcastToRoom` to include `console.log('Estat wss:', !!this.wss)` and log the number of clients reached.
- [x] 2.4 Ensure `broadcastToRoom` sends exactly `{ type: 'ROOM_UPDATED', room: salaData }`.

## 3. Ensure Event Triggers

- [x] 3.1 Verify the `create` method in `GameController.js` triggers `broadcastRoomUpdates` immediately after room creation.
- [x] 3.2 Verify the `join` method in `GameController.js` triggers both `broadcastToRoom` and `broadcastRoomUpdates` after a player joins.
- [x] 3.3 Verify the `READY` event handler in `server.js` triggers `broadcastToRoom` with the updated room data.

## 4. Validation

- [ ] 4.1 Perform a room creation test and verify the `ACTUALITZAR_SALES` message and client count in the server logs.
- [ ] 4.2 Perform a player join test and verify the `ROOM_UPDATED` message and client count in the server logs.
- [ ] 4.3 Toggle a player's ready status and verify the room state synchronization broadcast.
