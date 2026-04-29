## 1. Backend: Controller Updates

- [x] 1.1 Verify that `GameController.create` calls `await this.broadcastRoomUpdates()` after saving.
- [x] 1.2 Update `GameController.join` to call `await this.broadcastToRoom(updatedGame)` and `await this.broadcastRoomUpdates()` after a successful join.

## 2. Backend: WebSocket Handler Updates

- [x] 2.1 Update the `READY` handler in `server.js` to ensure `await gameController.broadcastToRoom(updatedGame)` is called immediately after `setReady`.
- [x] 2.2 Update the `leave_room` handler in `server.js` to ensure `await gameController.broadcastToRoom(updatedGame)` is called if the room survives.
- [x] 2.3 Ensure `await gameController.broadcastRoomUpdates()` is called in the `leave_room` handler regardless of whether the room survived or was deleted.

## 3. Verification

- [x] 3.1 Verify lobby sync: creating a room immediately updates the lobby list for all clients.
- [x] 3.2 Verify room sync: joining a room immediately shows the new player to the host.
- [x] 3.3 Verify ready sync: clicking "LLEST" immediately updates the status for all players in the room.
- [x] 3.4 Verify leave sync: leaving a room immediately updates both the room member list (if active) and the lobby list.
