## 1. Player Script Updates

- [x] 1.1 Update `OnCollisionEnter2D` in `Player.cs` to set `this.potMoure = false` before calling `IniciarMinijoc`.
- [x] 1.2 Ensure the `opponent` is correctly identified and passed as the second argument to `MinijocUIManager.Instance.IniciarMinijoc`.

## 2. MinijocUIManager Script Updates

- [x] 2.1 Verify that `MinijocUIManager.IniciarMinijoc` stores the participants in `_jugador1` and `_jugador2`.
- [x] 2.2 Verify that `MinijocUIManager.FinalitzarCombat` only calls `FinalitzarCombat()` on `_jugador1` and `_jugador2`.

## 3. Global State Cleanup

- [x] 3.1 Review `MinijocUIManager.cs` to ensure no global "pause" state is being applied that would affect non-combatants (aside from UI visibility).
- [x] 3.2 Test with multiple players to confirm that Player C can move while A and B are in combat.
