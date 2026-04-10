## 1. Setup

- [x] 1.1 Add `UnityEngine.UI` to imports in `Player.cs`.
- [x] 1.2 Define new variables in `Player.cs`: `int lives = 3`, `bool isFrozen = false`, `bool isInvulnerable = false`, `Transform respawnPoint`, and `Text livesText`.

## 2. Core Implementation

- [x] 2.1 Wrap the input/movement logic in `Update()` with a `!isFrozen` check.
- [x] 2.2 Create `UpdateLivesUI()` method to update the `livesText`.
- [x] 2.3 Implement the loss coroutine `HandleLossCoroutine(int duration)`.
- [x] 2.4 Implement the win coroutine `HandleWinCoroutine(int duration)`.
- [x] 2.5 Implement the respawn coroutine `HandleRespawnCoroutine(int duration)`.

## 3. Event Triggers

- [x] 3.1 Create public methods `LoseCombat()` and `WinCombat()` to trigger the coroutines.
- [x] 3.2 Ensure `LoseCombat()` handles flag detachment and life reduction.
- [x] 3.3 Ensure `WinCombat()` only applies invulnerability.

## 4. Verification

- [x] 4.1 Verify that movement is disabled during the 7s and 45s freezes.
- [x] 4.2 Verify that teleportation happens correctly when lives reach 0.
- [x] 4.3 Verify visual color changes for frozen and invulnerable states.
