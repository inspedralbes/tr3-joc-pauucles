## 1. Registry Management (GameManager.cs)

- [x] 1.1 Change visibility of `remotePlayers` dictionary to `public`.
- [x] 1.2 Implement `RemoveRemotePlayer(string username)` to clean up the registry.
- [x] 1.3 Ensure new remote players are correctly added to the dictionary upon instantiation.

## 2. Coordinate Routing (MenuManager.cs & GameManager.cs)

- [x] 2.1 Refine `MenuManager.AlRebreActualitzacioSales()` to reliably route `PLAYER_MOVE` messages.
- [x] 2.2 Update `GameManager.UpdateRemotePlayer()` to use the dictionary lookup for existing players.
- [x] 2.3 Verify `ActualitzarPosicioRemota` logic (via `RemotePlayer.UpdateStatus`) correctly triggers `NetworkSync`.

## 3. Cleanup & Verification

- [x] 3.1 Implement registry cleanup when processing `ROOM_UPDATED` (if players are missing).
- [x] 3.2 Verify real-time routing of coordinates from WebSocket to remote player objects.
- [x] 3.3 Verify dictionary remains accurate after players leave the room.
