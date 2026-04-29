## Why

Remote players currently experience jitter and "air blocking" due to local gravity interfering with network-received positions. Unifying the synchronization logic in `NetworkSync.cs` and using kinematic rigidbodies for remote players will ensure smoother, more predictable movement that accurately reflects the server state.

## What Changes

- **Kinematic Remote Players**: Modify `NetworkSync.Start()` to detect if the object is a remote player and set its `Rigidbody2D.bodyType` to `Kinematic` to disable local physics influence.
- **Interpolated Movement**: Implement a target-based interpolation system in `NetworkSync.Update()` for remote players using `Lerp`.
- **Logic Unification**: Consolidate local transmission and remote reception/interpolation logic within `NetworkSync.cs` for better maintainability.

## Capabilities

### New Capabilities
- `remote-kinematic-movement`: Logic to disable local physics on remote players and use smooth interpolation to target coordinates.
- `unified-network-sync`: A single component capable of handling both transmission for local players and interpolation for remote players.

### Modified Capabilities
- None.

## Impact

- `NetworkSync.cs`: Significant refactor to handle both local and remote roles.
- `RemotePlayer.cs`: Likely to be simplified or deprecated if logic is fully unified in `NetworkSync.cs`.
- Prefabs: Ensure `NetworkSync` is correctly configured on both local and remote player prefabs.
