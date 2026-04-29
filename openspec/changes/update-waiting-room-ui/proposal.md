## Why

The current Waiting Room UI has several issues:
1.  The room code is not dynamically updated when a player joins or creates a room, leading to confusion.
2.  The layout of the waiting room is not centered, which makes it look unpolished on different screen resolutions.
3.  The action buttons ("INVENTARI" and "LLEST") move unpredictably when the window is resized or in different build environments.

## What Changes

- **Dynamic Room Code**: Update `MenuManager.cs` to retrieve and display the current room ID in the `codeLabel`.
- **Layout Centering**: Update `MenuStyles.uss` to ensure the `#pantallaSalaEspera` container uses a centered column layout.
- **Button Stability**: Wrap the action buttons in a non-growing `VisualElement` to ensure they stay fixed at the bottom of the window.

## Capabilities

### New Capabilities
- None (UI and UX refinement).

### Modified Capabilities
- None (No core requirement changes).

## Impact

- `DAMT3Atrapa la bandera/Assets/Scripts/MenuManager.cs`: Logic to update the room code label.
- `DAMT3Atrapa la bandera/Assets/UI/MenuStyles.uss`: CSS updates for centering and layout.
- `DAMT3Atrapa la bandera/Assets/UI/MenuUI.uxml`: UI structure changes to group and stabilize buttons.
