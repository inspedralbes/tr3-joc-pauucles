## 1. PPTLLS Logic Fixes

- [x] 1.1 Declare `private bool jocActiu = false;` in `MinijocPPTLLSLogic.cs` (standardizing from `_jocActiu`).
- [x] 1.2 Update `IniciarMinijoc()` to set `jocActiu = true`.
- [x] 1.3 Update `Update()` and `RebreActualitzacioXarxa()` to consistently use `jocActiu`.
- [x] 1.4 Ensure `jocActiu = false` is set when the combat concludes.

## 2. Parells i Senars Logic Fixes

- [x] 2.1 Add `public void RebreResultatXarxa(string winner)` method to `MinijocParellsSenarsLogic.cs`.
- [x] 2.2 Implement the rival-win logic: if winner is "RIVAL_WIN", force `_faseRevelacio = true` and `_guanyador = "Jugador 2"`.
- [x] 2.3 Ensure the UI reflects the defeat immediately when receiving the rival win.

## 3. Acaparament de Mirades Logic Fixes

- [x] 3.1 Add `public void RebreResultatXarxa(string winner)` method to `MinijocAcaparamentMiradesLogic.cs`.
- [x] 3.2 Implement the rival-win logic: if winner is "RIVAL_WIN", force `_faseRevelacio = true` and `_guanyador = "Jugador 2"`.
- [x] 3.3 Ensure the UI reflects the defeat immediately when receiving the rival win.

## 4. Verification

- [ ] 4.1 Verify project compiles without CS0103/CS1061 errors.
- [ ] 4.2 Verify that receiving a rival win result terminates the active minigame correctly in all three fixed scripts.
