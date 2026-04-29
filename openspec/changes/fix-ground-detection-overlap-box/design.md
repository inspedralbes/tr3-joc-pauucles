## Context

The current `Physics2D.BoxCast` grounding detection may cause issues when standing on very narrow platforms or during rapid diagonal movement. A more localized check at the player's feet using an overlap box is needed for better precision.

## Goals / Non-Goals

**Goals:**
- Replace `Physics2D.BoxCast` with `Physics2D.OverlapBoxAll`.
- Concentrated grounding check at the player's base.
- Filter out triggers and the player's own collider.

**Non-Goals:**
- Changing the player's collider shape.
- Modifying general physics settings.

## Decisions

- **Physics2D.OverlapBoxAll**: Chosen over `OverlapBox` to allow manual filtering of multiple detected colliders (such as triggers and the player's own collider) in a single frame.
- **Base min.y Origin**: The origin of the overlap box is set to the minimum Y coordinate of the player's collider bounds, ensuring the check starts exactly at the feet.
- **80% Width (Inset)**: The check is slightly narrower than the player's actual width to prevent "sticking" to vertical walls, which could otherwise be detected as ground.

## Risks / Trade-offs

- **[Risk]** Allocation of the `Collider2D[]` array by `OverlapBoxAll`. **[Mitigation]** The number of colliders at the feet is typically very small; memory overhead is minimal. A future optimization could use `OverlapBoxNonAlloc` if needed.
