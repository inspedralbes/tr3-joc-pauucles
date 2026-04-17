## 1. Grounding Refactor

- [x] 1.1 Update `CheckGrounded()` in `Player.cs` to use `Physics2D.OverlapBoxAll`.
- [x] 1.2 Implement filtering logic to ignore triggers and the player's own collider.
- [x] 1.3 Implement the 80% width inset logic for accurate grounding.

## 2. Verification

- [x] 2.1 Verify jumping and falling states on various surfaces.
- [x] 2.2 Confirm player doesn't stick to vertical walls.
- [x] 2.3 Verify player doesn't get grounded on trigger zones.
