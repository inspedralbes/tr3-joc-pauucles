## Why

The current Nametag implementation suffers from rendering issues in the executable build, with incorrect sorting and depth. Additionally, the minigame locking logic is fragile, relying on a single method to find the manager which can fail in a build environment, leading to inconsistent player states.

## What Changes

- **Nametag Visual Correction**: Adjust the `Canvas` sorting order and local Z position in `Nametag.cs` to ensure visibility and proper depth relative to the player.
- **Robust Manager Detection**: Enhance `Player.cs` to use multiple methods (FindObjectOfType and Find by name) to locate the `MinijocUIManager`.
- **Targeted Combat Locking**: Ensure `potMoure = false` is applied only to the local player and the collision partner when combat starts.
- **Diagnostic Logging**: Add system logs to verify successful UI detection and player locking.

## Capabilities

### New Capabilities
- `robust-manager-discovery`: Implementation of fallback mechanisms to find critical singleton managers.

### Modified Capabilities
- `foundations`: Update base rendering and collision requirements for reliable build performance.

## Impact

- `Nametag.cs`: Rendering and positioning logic.
- `Player.cs`: Collision detection and fighter identification logic.
- `MinijocUIManager.cs`: Indirectly affected by how it's called.
