## Why

Currently, player movement synchronization is rudimentary: the local player sends updates on every tick without optimization, and remote players teleport to new coordinates, resulting in jittery visuals. This change aims to optimize network traffic and provide smooth character movement for a better multiplayer experience.

## What Changes

- **Local Player Optimization**: Refactor `NetworkSync.cs` to only send position updates if the player has moved significantly (above a threshold) or at a fixed tick rate.
- **Remote Player Interpolation**: Update `RemotePlayer.cs` to use `Vector3.Lerp` or `Vector3.MoveTowards` for smooth transitions between received coordinates instead of direct teleportation.
- **Visual State Synchronization**: Ensure visual components like sprite flipping (scale X) and animation states are correctly synchronized and applied to remote players.

## Capabilities

### New Capabilities
- `local-movement-transmission`: Optimized logic for sending position and state updates from the local player to the server.
- `remote-movement-interpolation`: Smooth movement and state synchronization for remote players based on received network data.

### Modified Capabilities
- None.

## Impact

- `NetworkSync.cs`: Refined transmission logic.
- `RemotePlayer.cs`: Implementation of interpolation and smooth state updates.
- `NetworkSync.PlayerMoveMessage`: Potential minor schema adjustments if needed for better interpolation context.
