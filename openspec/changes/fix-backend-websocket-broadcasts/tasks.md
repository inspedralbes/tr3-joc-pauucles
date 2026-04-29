## 1. Backend: Update Broadcast Helpers

- [x] 1.1 Update `broadcastRoomUpdates` in `GameController.js` to use `type: "ACTUALITZAR_SALES"` and `sales` key.
- [x] 1.2 Update `broadcastToRoom` in `GameController.js` to use `type: "ROOM_UPDATED"` and `room` key.

## 2. Backend: Implement Specific Broadcasts

- [x] 2.1 Update `GameController.create` to call `broadcastRoomUpdates` and log "Broadcast CREAR_SALA enviat".
- [x] 2.2 Update `GameController.join` to call `broadcastToRoom`, then `broadcastRoomUpdates`, and log "Broadcast JOIN_ROOM enviat".
- [x] 2.3 Update the `READY` handler in `server.js` to ensure `broadcastToRoom` is called before any other logic.

## 3. Verification

- [x] 3.1 Verify that creating a room triggers the global `ACTUALITZAR_SALES` broadcast with the correct JSON structure.
- [x] 3.2 Verify that joining a room triggers both `ROOM_UPDATED` and `ACTUALITZAR_SALES` broadcasts.
- [x] 3.3 Verify that setting a player as ready triggers the `ROOM_UPDATED` broadcast.
