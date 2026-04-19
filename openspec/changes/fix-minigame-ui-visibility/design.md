## Context

The `MinijocUIManager` is responsible for presenting different minigame interfaces to the player. Currently, there is no standardized way to ensure the UI root is visible when a game starts or hidden when it ends, leading to potential visual bugs where UI remains on screen or never appears.

## Goals / Non-Goals

**Goals:**
- Centralize UI Toolkit root visibility management.
- Ensure the `UIDocument` reference is always valid during operations.
- Provide clear logging for visibility state transitions.

**Non-Goals:**
- Modifying individual minigame logic.
- Redesigning the UXML layouts.

## Decisions

- **UIDocument Sourcing**: Use `GetComponent<UIDocument>()` in `Awake` or `Start` to cache the reference. This ensures the script is co-located with its UI document.
- **DisplayStyle for Hiding**: Use `DisplayStyle.Flex` for visibility and `DisplayStyle.None` for hiding. This is the standard UI Toolkit approach to remove elements from the layout pass and rendering.
- **Hook Placement**:
    - `IniciarMinijoc()`: Set `rootVisualElement.style.display = DisplayStyle.Flex`.
    - End condition/callback: Set `rootVisualElement.style.display = DisplayStyle.None`.
- **Debug Logging**: Wrap visibility changes in `Debug.Log` calls using a standard prefix (e.g., `[MinijocUI]`) for easier filtering.

## Risks / Trade-offs

- **[Risk]** → `GetComponent<UIDocument>()` returns null if the component is missing.
    - **[Mitigation]** → Add a null check and log an error if the component is not found during initialization.
- **[Trade-off]** → Using `DisplayStyle` instead of `gameObject.SetActive()`.
    - **[Mitigation]** → `DisplayStyle` is generally preferred for UI Toolkit as it doesn't trigger full object re-activations, maintaining better performance for simple visibility toggles.
