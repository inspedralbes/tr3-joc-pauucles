## Context

The player character currently experiences issues where it might stay in a "grounded" state while falling, and lacks visual feedback during combat loss or respawn.

## Goals / Non-Goals

**Goals:**
- Ensure `isGrounded` is correctly reset when the player falls or exits a collision.
- Trigger the "hurt" animation when losing combat.
- Manage the "isDead" animation state during the respawn coroutine.

**Non-Goals:**
- Refactoring the entire movement system.
- Modifying the Animator Controller assets (assumes "hurt" and "isDead" parameters exist).

## Decisions

- **Grounding Safety Logic**: Implement a velocity-based check in `Update` as a fallback for the collision-based grounding. This ensures that even if `OnCollisionExit2D` fails to trigger correctly, the player state remains accurate.
- **Explicit Collision Reset**: Use `OnCollisionExit2D` to immediately reset grounding state, providing reactive feedback.
- **Animation Synchronization**: Hook into existing combat and respawn methods to set animator parameters.

## Risks / Trade-offs

- **[Risk]** The velocity threshold (0.1f) might be too sensitive. **[Mitigation]** This value is standard for falling detection, but may need adjustment if "grounded" state flickers on slight slopes.
