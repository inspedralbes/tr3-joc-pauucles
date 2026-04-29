## Why

Manual interpolation and position updates for flag carrying in `Bandera.cs` are complex to maintain and can lead to visual artifacts. By leveraging Unity's built-in transform hierarchy (`SetParent`), we can achieve perfect synchronization between the player and the carried flag with zero additional code in the `Update` loop.

## What Changes

- **Cleanup**: Remove `esCapturada`, `targetSeguiment`, and manual `Update` follow logic from `Bandera.cs`.
- **Hierarchy Capture**: Implement flag capture by setting the flag's parent to the player's transform and assigning a local offset.
- **Verification**: Ensure `NetworkSync.cs` remains active for local players to broadcast their position (and their children's position by extension if necessary, though usually just the player position is enough if remots also do the parenting).

## Capabilities

### New Capabilities
- `flag-hierarchy-capture`: Automatic flag carrying via transform parenting.

### Modified Capabilities
- None.

## Impact

- `Bandera.cs`: Removal of old follow logic and implementation of `SetParent`.
- `NetworkSync.cs`: Checked for transmission stability.
