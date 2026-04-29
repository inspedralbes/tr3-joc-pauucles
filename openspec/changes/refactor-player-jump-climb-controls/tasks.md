## 1. Player Controls Refactor

- [x] 1.1 Replace current Jump Input logic in `Update()` with `Input.GetKeyDown(KeyCode.Space)` and add `!isClimbing` condition.
- [x] 1.2 Update Climbing Activation logic to check for `Mathf.Abs(verticalInput) > 0.1f` when `isNearLadder` is true.
- [x] 1.3 Implement "Jump from Ladder" logic by checking for `Input.GetKeyDown(KeyCode.Space)` while `isClimbing` is true, resetting `isClimbing` to false.
- [x] 1.4 Refactor `FixedUpdate()` climbing physics to handle vertical velocity and gravity scale correctly.
- [x] 1.5 Clean up redundant Jump Buffer and Coyote Time logic if it conflicts with the new strict control requirements.
- [x] 1.6 Verify that Animator updates and `OnTrigger` methods for `ZonaEscalera` remain functional and integrate correctly with the changes.
