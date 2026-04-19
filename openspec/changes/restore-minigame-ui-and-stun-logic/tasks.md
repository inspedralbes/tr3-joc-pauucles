## 1. Minigame Logic Restoration

- [x] 1.1 Restore button bindings in `MinijocPPTLLSLogic.cs` ensuring `RegisterCallback` or `clicked` events are active.
- [x] 1.2 Review and restore button bindings in `MinijocParellsSenarsLogic.cs`.
- [x] 1.3 Review and restore button bindings in `MinijocAturaBarraLogic.cs`.
- [x] 1.4 Review and restore button bindings in any other `Minijoc*Logic.cs` (e.g. Mates, CablePelat).

## 2. Player Component Enhancement

- [x] 2.1 Implement `public void GuanyarMinijoc()` in `Player.cs`.
- [x] 2.2 Implement `public void PerdreMinijoc()` in `Player.cs`.
- [x] 2.3 Implement the `RutinaStun` coroutine in `Player.cs`.

## 3. UI Manager Bridge

- [x] 3.1 Update `MinijocUIManager.FinalitzarCombat` to close the UI using `gameObject.SetActive(false)`.
- [x] 3.2 Update `FinalitzarCombat` to find the local player and trigger the win/loss status methods.

## 4. Verification

- [ ] 4.1 Verify that minigame buttons correctly trigger local and network logic.
- [ ] 4.2 Verify that losing a minigame immobilizes the local player for exactly 3 seconds.
- [ ] 4.3 Verify that winning a minigame allows immediate movement.
