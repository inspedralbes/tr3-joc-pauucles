## Why

The current collision-based grounding system is unreliable, especially on ramps or during rapid vertical movements. This change replaces it with a robust `BoxCast` detection method to ensure consistent gameplay and jump behavior.

## What Changes

- **Ground detection refactor**: Replaces the `OnCollisionEnter2D`/`Exit2D` based grounding with a dedicated `BoxCast` check in `Update`.
- **Logic cleanup**: Removes velocity-based grounding safety checks and direct assignments in collision methods that are now obsolete.
- **Improved ramp support**: The `BoxCast` method provides a more accurate representation of the player's contact with the ground, including slopes.

## Capabilities

### New Capabilities
- `player-ground-detection`: Requirements for robust ground detection using Physics2D queries.

### Modified Capabilities
<!-- None -->

## Impact

- **`Player.cs`**: Significant changes to movement and grounding logic.
- **Physics**: Requires correct setup of colliders (triggers vs. non-triggers).
