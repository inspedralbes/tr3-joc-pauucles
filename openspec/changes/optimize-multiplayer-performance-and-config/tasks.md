## 1. Infrastructure & Configuration

- [x] 1.1 Update `nginx_default.conf` with long WebSocket timeouts (`proxy_read_timeout`, `proxy_send_timeout`).
- [x] 1.2 Reload Nginx configuration and verify WebSocket stability.

## 2. Optimized Network Protocol (Unity)

- [x] 2.1 Update `PlayerMoveMessage` in `NetworkSync.cs` to include velocity (vx, vy) and `isFullUpdate` flag.
- [x] 2.2 Modify `NetworkSync.SendPosition` to implement 20Hz (0.05s) update rate.
- [x] 2.3 Implement delta logic in `SendPosition`: omit metadata if `isFullUpdate` is false.
- [x] 2.4 Add a timer to send a full update every 2 seconds.

## 3. Dead Reckoning & Interpolation (Unity)

- [x] 3.1 Implement Dead Reckoning calculation in `NetworkSync.Update()` for remote players.
- [x] 3.2 Add linear interpolation with a jitter buffer to smooth out predicted movement.
- [x] 3.3 Implement the "hard snap" threshold (4 units) to prevent extreme desync.
- [x] 3.4 Update `RemotePlayer.cs` (if needed) to support the new synchronization data.

## 4. GameManager & Reliability Improvements

- [x] 4.1 Refactor `GameManager.UpdateRemotePlayer` to optimize dictionary lookups and avoid redundant operations.
- [x] 4.2 Modify `NetejaQuirurgica` to run only once after initial scene stabilization (e.g., after 5 seconds).
- [x] 4.3 Ensure `potMoure` is strictly enforced in `Player.cs` and `NetworkSync.cs` during minigame states.

## 5. Verification & Testing

- [ ] 5.1 Verify movement smoothness with 2 players.
- [ ] 5.2 Test connection stability over long periods (>10 minutes).
- [ ] 5.3 Confirm metadata sync (skins/teams) works correctly with the new delta protocol.
