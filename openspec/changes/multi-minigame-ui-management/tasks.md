## 1. UI Manager Refactoring

- [x] 1.1 Implement the `AmagarTotsElsMinijocs(VisualElement root)` helper method in `MinijocUIManager.cs`.
- [x] 1.2 Update `IniciarMinijoc` to acquire the `rootVisualElement` and call `AmagarTotsElsMinijocs` immediately after `gameObject.SetActive(true)`.

## 2. Minigame Activation Logic

- [x] 2.1 Update the `switch` statement in `IniciarMinijoc` to selectively display the relevant container (`DisplayStyle.Flex`) for PPTLLS.
- [x] 2.2 Update the `switch` statement for ParellsSenars.
- [x] 2.3 Update the `switch` statement for AturaBarra.
- [x] 2.4 Update the `switch` statement for PolsimForca.
- [x] 2.5 Update the `switch` statement for AcaparamentMirades (DuelMirades).

## 3. Verification

- [ ] 3.1 Verify that all minigame containers are hidden at the start of combat.
- [ ] 3.2 Verify that only the chosen minigame's UI is visible.
- [ ] 3.3 Ensure no overlaps occur when transitioning between minigame sessions.
