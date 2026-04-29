## Context

The "Cable Pelat" minigame is one of several combat minigames. It currently has a partial implementation that needs to be refined to use ID-based selectors for the UI elements and to correctly handle the win/loss state via the `MinijocUIManager`.

## Goals / Non-Goals

**Goals:**
- Implement ID-based element selection (`#`) for UI elements.
- Ensure correct state management with the `enCurs` flag.
- Integrate correctly with `MinijocUIManager.Instance.FinalitzarCombat`.
- Fix the UI hiding logic in `MinijocUIManager`.

**Non-Goals:**
- Redesigning the UXML layout.
- Adding new visual assets.

## Decisions

- **ID-based Selectors**: We will use `#` prefix in `root.Q<VisualElement>("#ID")` to match the user's specific request and ensure we are selecting by ID as intended by the UXML design.
- **State Transition**: The `enCurs` flag will be the source of truth for whether the minigame is active. It is set to `true` at the start zone and `false` at the end or danger zones.
- **UI Manager Integration**: `MinijocUIManager` will handle the activation of the `#ContenidorCablePelat` and call the initialization of the logic. It will also be updated to hide this container when other minigames are active or the UI is hidden.

## Risks / Trade-offs

- [Risk] → **UI Element IDs**: If the UXML doesn't have the exact IDs `#ZonaInici`, `#ZonaMeta`, or `#FonsPerill`, the logic will fail. 
- [Mitigation] → We will assume these IDs exist as per the user's instructions and the established UXML structure.
- [Risk] → **Multiple Event Calls**: `RegisterCallback` can accumulate if not managed. 
- [Mitigation] → Since the `root` (container) is refreshed or the object is initialized once per combat, this should be manageable.
