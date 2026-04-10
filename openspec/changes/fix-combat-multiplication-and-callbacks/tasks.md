## 1. State Management Implementation

- [x] 1.1 Add `public bool minijocActiu = false;` and `private bool combatResolentse = false;` to `MinijocUIManager.cs`.
- [x] 1.2 Update `MinijocUIManager.ShowUI` to set `minijocActiu = true` and `combatResolentse = false` at the beginning.
- [x] 1.3 Update `MinijocUIManager.HideUI` to set `minijocActiu = false`.

## 2. Input Resolution Guarding

- [x] 2.1 Update `HandlePPTLLSClick` in `MinijocUIManager.cs` to check `combatResolentse` and set it to `true` on first valid click.
- [x] 2.2 Update `HandleParellsSenarsClick` in `MinijocUIManager.cs` to check `combatResolentse` and set it to `true` on first valid click.
- [x] 2.3 Update `HandleAturaBarraClick` in `MinijocUIManager.cs` to check `combatResolentse` and set it to `true` on first valid click.

## 3. Collision Guarding

- [x] 3.1 Update `Player.OnCollisionEnter2D` to only call `ShowUI` if `MinijocUIManager.Instance.minijocActiu` is `false`.

## 4. Event Listener Cleanup

- [x] 4.1 Update `SetupPPTLLSButtons` in `MinijocUIManager.cs` to unbind existing `-=` click listeners before binding `+=` new ones.
- [x] 4.2 Update `SetupParellsSenarsButtons` in `MinijocUIManager.cs` to unbind existing `-=` click listeners before binding `+=` new ones.
- [x] 4.3 Update `SetupAturaBarraButtons` in `MinijocUIManager.cs` to unbind existing `-=` click listeners before binding `+=` new ones.
