## Why

The game currently lacks the fundamental mechanic of capturing the enemy's flag. Without this, the primary objective of "Capture the Flag" cannot be achieved. Implementing this logic now is essential for completing the core gameplay loop.

## What Changes

- **Capture State**: Add `esCapturada` boolean to track if a flag is currently being carried.
- **Target Tracking**: Add `targetSeguiment` to store the Transform of the player carrying the flag.
- **Collision Detection**: Implement `OnTriggerEnter2D` to detect player contact and verify team ownership.
- **Following Behavior**: Update the `Update` loop to make the flag follow the capturing player with a relative offset.

## Capabilities

### New Capabilities
- `flag-capture`: Logic to determine when a flag is captured based on team identity.
- `flag-follow`: Visual and positional behavior for a captured flag following its carrier.

### Modified Capabilities
- None.

## Impact

- `Bandera.cs`: Primary implementation site for capture and following logic.
- `Player.cs` or `MenuManager`: Used to identify the player's team during collision.
