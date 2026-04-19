## Why

The current flag capture logic is unreliable due to potential team name mismatches and a lack of diagnostic feedback during collisions. Additionally, local players lack consistent visual identification (nametags), which complicates debugging and degrades the user experience.

## What Changes

- **Enhanced Local Nametag Assignment**: Refactor `GameManager.ConfigurarLocalPlayerVisuals()` to exhaustively search for `TextMeshPro` or `Text` components on the local player to display their UserID.
- **Collision Debugging**: Add detailed debug logging to `Bandera.OnTriggerEnter2D` to report team identities during collisions.
- **Team Assignment Synchronization**: Align the team identification format in `InstanciarBanderes()` with the player's team format (e.g., "A"/"B" vs "EquipA"/"EquipB") to ensure capture logic works as intended.
- **Refined Capture Logic**: Ensure the flag capture (follow logic) only triggers when the player's team differs from the flag's owner.

## Capabilities

### New Capabilities
- `flag-capture-refinement`: Robust team-based flag capture logic with diagnostic logging.
- `local-player-visuals`: Reliable visual identification for the local player through automated nametag discovery.

### Modified Capabilities
- None.

## Impact

- `GameManager.cs`: Changes to player initialization logic.
- `Bandera.cs`: Changes to collision handling and initialization.
- Unity Editor: Requires correct hierarchy/component naming for nametags if discovery fails.
