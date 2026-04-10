## Context

The current player HUD uses the legacy Unity UI system. This transition to UI Toolkit will modernize the codebase and integrate health management with visual elements. The number of lives will be increased from 3 to 5.

## Goals / Non-Goals

**Goals:**
- Replace `UnityEngine.UI` and `Text` references with `UnityEngine.UIElements` and `UIDocument`.
- Implement a list-based life management for health indicators.
- Create a reusable UI update function that modifies element styles.
- Maintain existing coroutines and combat logic.

**Non-Goals:**
- Redesigning the health icons themselves.
- Adding complex UI animations beyond style-based hiding.

## Decisions

- **UI Elements over Text**: Swapping the `Text` component for a `UIDocument`. The `rootVisualElement` will be used as the base for querying child elements.
- **List for Life Icons**: Storing the 5 `VisualElement`s in a `List<VisualElement>` for easy indexing (0 to 4).
- **DisplayStyle.None**: Using the `style.display` property to hide icons when a life is lost. This is more standard in UI Toolkit than changing alpha or color.
- **5 Lives**: Updating the `lives` variable initialization and the respawn logic to use 5 as the base value.

## Risks / Trade-offs

- [Risk: Missing Elements] -> Mitigation: Use `Query` or `Q` with the specific names ('Vida1'...'Vida5') and log an error if any element is not found during initialization.
- [Risk: UI Context Mismatch] -> Mitigation: Ensure the `UIDocument` is correctly referenced via the inspector.
