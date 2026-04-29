## 1. Unified NetworkSync Refactor

- [x] 1.1 Add role detection (`isRemote`) and `posicioObjectiu` to `NetworkSync.cs`.
- [x] 1.2 Implement kinematic rigidbody enforcement in `NetworkSync.Start()`.
- [x] 1.3 Refactor `NetworkSync.Update()` to separate transmission (local) from interpolation (remote).

## 2. Remote Position Handling

- [x] 2.1 Add `RebrePosicio(float x, float y)` method to `NetworkSync.cs` to update `posicioObjectiu`.
- [x] 2.2 Transition `RemotePlayer.UpdateStatus()` to call the new `NetworkSync.RebrePosicio()`.
- [x] 2.3 Ensure visual state updates (flip, animation) are still handled correctly during the transition.

## 3. Verification

- [x] 3.1 Verify remote players are kinematic on start.
- [x] 3.2 Verify smooth interpolation to `posicioObjectiu` for remote players.
- [x] 3.3 Verify no "air blocking" due to local gravity on remote clients.
