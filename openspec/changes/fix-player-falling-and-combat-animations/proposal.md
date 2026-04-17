## Why

Fixes inconsistencies in the player's grounding logic while falling and ensures that combat-related animations (hurt, death/respawn) are correctly triggered to improve visual feedback and gameplay reliability.

## What Changes

- **Grounding logic**: Added a safety check in `Update` to set `isGrounded` to false if vertical velocity is significant and the player is not climbing.
- **Collision exit**: Explicitly sets `isGrounded` to false in `OnCollisionExit2D` to prevent "ghost" grounding states.
- **Combat feedback**: Triggers the "hurt" animation when losing combat.
- **Respawn animations**: Handles the "isDead" animator parameter during the respawn process (setting it to true at the start and false at the end).

## Capabilities

### New Capabilities
- `player-animations-and-grounding`: Defines requirements for player grounding detection during falls and combat/respawn animation synchronization.

### Modified Capabilities
<!-- None -->

## Impact

- **`Player.cs`**: Main logic updates.
- **Player Animator**: Requires "hurt" (trigger) and "isDead" (bool) parameters to be correctly set up.
