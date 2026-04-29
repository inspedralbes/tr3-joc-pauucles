## 1. Local Transmission Optimization

- [x] 1.1 Add distance threshold logic to `NetworkSync.cs`.
- [x] 1.2 Refactor `NetworkSync.Update()` to include time and distance checks.
- [x] 1.3 Ensure `lastPosition` is updated only when a message is actually sent.

## 2. Remote Interpolation Core

- [x] 2.1 Add `targetPosition` and `interpolationSpeed` to `RemotePlayer.cs`.
- [x] 2.2 Implement `Update()` loop in `RemotePlayer.cs` with `Vector3.Lerp`.
- [x] 2.3 Add snap logic for large distance updates (e.g., > 5 units).

## 3. Visual State Synchronization

- [x] 3.1 Refactor `RemotePlayer.UpdateStatus()` to update `targetPosition` instead of `transform.position`.
- [x] 3.2 Verify immediate updates for `flipX` and `anim` states in `RemotePlayer.UpdateStatus()`.

## 4. Verification

- [x] 4.1 Verify local transmission is throttled when stationary.
- [x] 4.2 Verify smooth movement for remote players on the client.
- [x] 4.3 Verify animation synchronization for remote players.
