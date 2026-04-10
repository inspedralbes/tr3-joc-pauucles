## 1. MinijocPolsimForcaLogic Refactoring

- [x] 1.1 Add `private Player p1, p2;` fields to `MinijocPolsimForcaLogic`.
- [x] 1.2 Update `InicialitzarUI` to accept `Player p1, Player p2` and assign them to the fields.
- [x] 1.3 Update `FinalitzarMinijoc()` to call `p1.WinCombat()` and `p2.LoseCombat()` if Player 1 wins, and vice-versa.
- [x] 1.4 Ensure `MinijocUIManager.Instance.FinalitzarCombat(guanyador);` is called at the end of `FinalitzarMinijoc()`.

## 2. MinijocUIManager Update

- [x] 2.1 Update `MinijocUIManager.ShowUI` case 5 to pass `_jugador1` and `_jugador2` to `logic.InicialitzarUI`.

## 3. Verification

- [x] 3.1 Verify that the code compiles correctly.
