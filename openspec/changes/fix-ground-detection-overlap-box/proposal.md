## Why

The `Physics2D.BoxCast` grounding detection can be sensitive to narrow edges or slight floating point inaccuracies. Replacing it with a precise `Physics2D.OverlapBoxAll` check at the player's base provides more reliable grounding detection, especially on ramps and edges.

## What Changes

- **Ground detection update**: Replaces the `BoxCast` in `CheckGrounded()` with an `OverlapBoxAll` check.
- **Improved precision**: The check is now focused exactly at the bottom edge of the player's collider with a slight horizontal inset to avoid "wall-grounding".

## Capabilities

### New Capabilities
- `player-ground-detection-overlap`: Requirements for grounding detection using concentrated overlap boxes at the player's base.

### Modified Capabilities
<!-- None -->

## Impact

- **`Player.cs`**: Implementation details of `CheckGrounded()` are updated.
- **Movement**: Jumping and falling transitions will be more predictable.
