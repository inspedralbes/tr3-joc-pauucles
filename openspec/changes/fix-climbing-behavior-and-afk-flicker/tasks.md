## 1. Player AFK Logic Fix

- [x] 1.1 Modify the AFK flicker condition in `Update()` to exclude the climbing state (`!escalant`).
- [x] 1.2 Verify that the player does not flicker when stationary on a ladder.

## 2. Climbing Movement Refinement

- [x] 2.1 Refactor the climbing input logic in `FixedUpdate()` to use a single `vInput` variable.
- [x] 2.2 Implement continuous movement for the "Jump" button (Space) while climbing.
- [x] 2.3 Verify that holding the "Jump" button results in continuous upward movement on a ladder.
- [x] 2.4 Verify that vertical axis input still works for climbing (up and down).
