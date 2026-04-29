## 1. Networking Infrastructure Updates

- [x] 1.1 Add `EnviarMinijocUpdate(string data)` and `EnviarMinijocResult(string winner)` methods to `MenuManager.cs`.
- [x] 1.2 Update `AlRebreActualitzacioSales` in `MenuManager.cs` to handle `MINIJOC_UPDATE` and `MINIJOC_RESULT` message types.
- [x] 1.3 Implement the forwarding of these messages to `MinijocUIManager.Instance`.

## 2. UI Manager Bridge Implementation

- [x] 2.1 Add `RebreActualitzacioXarxa(string data)` and `RebreResultatXarxa(string winner)` methods to `MinijocUIManager.cs`.
- [x] 2.2 Implement logic in `MinijocUIManager` to pass these events to the specific active minigame logic script (using type-checking or a shared interface).

## 3. Minigame Logic Synchronization

- [x] 3.1 Update `MinijocAturaBarraLogic`, `MinijocMatesLogic` (if exists), and `MinijocCablePelatLogic` to send results on win and react to rival results.
- [x] 3.2 Update `MinijocPolsimForcaLogic` to broadcast score updates and sync rival progress.
- [x] 3.3 Update `MinijocPPTLLSLogic` to broadcast choices and resolve synchronized outcome.

## 4. Verification

- [ ] 4.1 Verify that a winner in one client triggers an immediate loss in the other for speed games.
- [ ] 4.2 Verify that scores in "Polsim de Força" are synchronized in real-time.
- [ ] 4.3 Verify that "PPTLLS" resolution only happens after both players choose.
