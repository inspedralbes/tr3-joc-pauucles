## 1. Script Logic (MenuManager.cs)

- [x] 1.1 In `MenuManager.cs`, locate the `OnEnable` method or the logic that shows the waiting room.
- [x] 1.2 Add code to query `codeLabel` using `root.Q<Label>("codeLabel")`.
- [x] 1.3 Set `labelCodi.text = "CODI: " + currentRoomId;` with a null check.

## 2. Styling (MenuStyles.uss)

- [x] 2.1 Update the `#pantallaSalaEspera` style in `MenuStyles.uss`.
- [x] 2.2 Set `flex-direction: column`, `align-items: center`, and `justify-content: center`.

## 3. UI Structure (MenuUI.uxml)

- [x] 3.1 Locate the action buttons ("btnAnarSkins" and "btnConfirmarReady") in `MenuUI.uxml`.
- [x] 3.2 Ensure they are wrapped in a `VisualElement` (e.g., `contenedorBotonsInferiors`).
- [x] 3.3 Set the container's `flex-grow` to `0` and ensure its position is stable.

## 4. Verification

- [x] 4.1 Verify that the room code is correctly displayed when entering a room.
- [x] 4.2 Confirm that the waiting room UI is centered on different screen sizes.
- [x] 4.3 Ensure the action buttons remain visible and properly positioned.
