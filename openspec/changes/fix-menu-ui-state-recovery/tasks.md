## 1. UI Initialization Refinement

- [x] 1.1 In `MenuManager.cs`, update `OnEnable` to explicitly find panels by name: `pantallaLogin`, `pantallaLobby`, `popUpCrearSala`, `pantallaSalaEspera`, `pantallaInventari`.
- [x] 1.2 Implement a robust null-check for all newly discovered `VisualElement` references.
- [x] 1.3 Add a "Force Reset" block in `Start` or the init method that sets all secondary panels to `DisplayStyle.None`.

## 2. Session-Based State Recovery

- [x] 2.1 Refine `ActualitzarVisibilitatSegonsSessio()` (or equivalent) to ensure it correctly identifies the active session using both `userId` and `WebSocketClient.LocalUsername`.
- [x] 2.2 Implement the switch-case or if-else logic to show ONLY `pantallaLogin` or `pantallaLobby`.

## 3. Verification

- [x] 3.1 Verify that returning to the menu scene from a match correctly shows the Lobby screen.
- [x] 3.2 Verify that secondary panels like `popUpCrearSala` are not visible upon reentry.
- [x] 3.3 Verify that no blue screen or overlapping panels occur on scene reload.
