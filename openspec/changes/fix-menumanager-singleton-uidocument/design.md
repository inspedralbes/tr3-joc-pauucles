## Context

The `MenuManager` is designed as a persistent singleton to maintain session state across scenes. However, its current implementation doesn't strictly enforce the singleton pattern, which can lead to duplicate managers. More critically, the `UIDocument` component it relies on for UI operations is scene-dependent. When a scene reloads, the old `UIDocument` is destroyed, but the persistent `MenuManager` still holds a reference to the now-deleted object, resulting in `MissingReferenceException`.

## Goals / Non-Goals

**Goals:**
- Implement a robust, industry-standard Singleton pattern for `MenuManager`.
- Ensure UI operations always use the currently active `UIDocument` in the scene.
- Eliminate `MissingReferenceException` during scene transitions.

**Non-Goals:**
- Changing the UI framework from UI Toolkit to something else.
- Moving session state management out of `MenuManager`.

## Decisions

- **Strict Singleton Check**: In `Awake()`, if an `Instance` already exists and is not the current one, destroy the current object immediately. This prevents initialization logic of the duplicate from running and potentially corrupting state.
- **Lazy/Refreshed Reference Fetching**: Modify the `OnSceneLoaded` event handler to explicitly re-fetch the `UIDocument` using `GetComponent<UIDocument>()` (or `FindObjectOfType<UIDocument>()` if the component is on a different GameObject) before calling any methods that depend on `rootVisualElement`.
- **Reference Guarding**: Add null checks for the `UIDocument` and `rootVisualElement` before performing visibility toggles or event binding.

## Risks / Trade-offs

- **[Risk]** → If multiple `UIDocument` instances exist in the scene, `FindObjectOfType` might return the wrong one.
  - **[Mitigation]** → Ensure the `MenuManager` GameObject itself has the correct `UIDocument` component or use a specific naming convention to find the intended root.
- **[Trade-off]** → Destroying duplicate objects in `Awake` is standard but requires careful attention to the order of operations to ensure no valid state is lost.
