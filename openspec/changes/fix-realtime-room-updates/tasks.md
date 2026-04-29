## 1. Backend: Enhance Real-time Updates

- [x] 1.1 Add `await this.broadcastToRoom(updatedGame)` to the `join` method in `backend/src/controllers/GameController.js` to notify room members of new joins.
- [x] 1.2 Verify that `create` in `GameController.js` correctly awaits `broadcastRoomUpdates()`.
- [x] 1.3 Ensure the `READY` handler in `backend/src/server.js` correctly broadcasts updates to both the room and the lobby if needed.
- [x] 1.4 Review `leave_room` logic to ensure lobby list is updated when a host leaves and the room is deleted.

## 2. Verification

- [x] 2.1 Test that creating a room immediately updates the lobby list for other clients.
- [x] 2.2 Test that joining a room updates the member list for clients already in that room.
- [x] 2.3 Test that setting ready status propagates to all room members in real-time.
