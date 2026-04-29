## 1. Setup and Component Access

- [x] 1.1 In `MinijocUIManager.cs`, ensure there is a private field for the `UIDocument` component.
- [x] 1.2 In the `Awake` or `Start` method, use `GetComponent<UIDocument>()` to cache the reference.
- [x] 1.3 Add a null check for the `UIDocument` reference during initialization and log an error if missing.

## 2. Visibility Logic Implementation

- [x] 2.1 Locate the method that triggers the minigame start (e.g., `IniciarMinijoc`).
- [x] 2.2 Add logic to set `uiDoc.rootVisualElement.style.display = DisplayStyle.Flex` at the beginning of the minigame start.
- [x] 2.3 Add a `Debug.Log` indicating that the minigame UI is now visible.
- [x] 2.4 Locate the logic or callback that handles minigame completion or closure.
- [x] 2.5 Add logic to set `uiDoc.rootVisualElement.style.display = DisplayStyle.None` when the minigame ends.
- [x] 2.6 Add a `Debug.Log` indicating that the minigame UI has been hidden.

## 3. Verification

- [x] 3.1 Run the game and trigger a minigame to verify that the UI appears correctly.
- [x] 3.2 Complete the minigame to verify that the UI disappears correctly.
- [x] 3.3 Check the Unity console for the corresponding "visible" and "hidden" logs.
