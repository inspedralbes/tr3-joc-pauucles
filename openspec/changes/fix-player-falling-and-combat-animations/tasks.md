## 1. Grounding Logic Updates

- [x] 1.1 Add falling velocity check in `Update` method just before Animator updates.
- [x] 1.2 Implement explicit `isGrounded = false` reset in `OnCollisionExit2D`.

## 2. Animation Integration

- [x] 2.1 Trigger "hurt" animation in `LoseCombat()` immediately after decrementing lives.
- [x] 2.2 Set "isDead" animator boolean to true at the beginning of `HandleRespawnCoroutine`.
- [x] 2.3 Reset "isDead" animator boolean to false at the end of `HandleRespawnCoroutine`.

## 3. Verification

- [x] 3.1 Verify player correctly transitions out of "isGrounded" state when falling.
- [x] 3.2 Confirm "hurt" animation triggers upon losing combat.
- [x] 3.3 Ensure "isDead" state is correctly managed during the entire respawn process.
