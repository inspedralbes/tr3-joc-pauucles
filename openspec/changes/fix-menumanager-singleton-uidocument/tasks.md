## 1. Strict Singleton Implementation

- [x] 1.1 Update `Awake()` in `MenuManager.cs` to include a strict singleton check.
- [x] 1.2 Implement the `Instance` check: `if (Instance != null && Instance != this) { Destroy(this.gameObject); return; }`.
- [x] 1.3 Ensure `DontDestroyOnLoad(this.gameObject)` is only called for the valid instance.

## 2. Dynamic UI Reference Refresh

- [x] 2.1 Locate the `OnSceneLoaded` method in `MenuManager.cs`.
- [x] 2.2 Add a step to refresh the `UIDocument` reference: `uiDocument = FindObjectOfType<UIDocument>();`.
- [x] 2.3 Ensure this refresh happens BEFORE calling `ActualitzarVisibilitatSegonsSessio()` or accessing `rootVisualElement`.
- [x] 2.4 Add null guards around `rootVisualElement` access in `OnSceneLoaded`.

## 3. Verification

- [x] 3.1 Verify that returning to the menu from the game no longer triggers a `MissingReferenceException`.
- [x] 3.2 Verify that no duplicate `MenuManager` objects exist in the Hierarchy after scene reloads.
