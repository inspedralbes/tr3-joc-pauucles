## Context

The `MenuManager` is a singleton and persistent between scenes. When returning to the `MenuPrincipal` scene, the `UIDocument` is re-instantiated. If the initialization logic (in `Start` or `OnEnable`) doesn't explicitly hide all panels and only show the relevant one based on session state, the user might see multiple screens overlapping or a blank screen if references weren't correctly updated.

## Goals / Non-Goals

**Goals:**
- Ensure correct UI state (Login vs. Lobby) on scene load.
- Explicitly hide all transient panels (`popUpCrearSala`, `pantallaSalaEspera`, `pantallaInventari`).
- Guarantee no UI toolkit elements are left in a "Display: Flex" state unless they are the intended active panel.

**Non-Goals:**
- Changing the layout of the UI panels.
- Modifying the authentication backend.

## Decisions

- **Initialization Logic Placement**: Use `OnEnable` to fetch references from the root visual element and `Start` (or a dedicated init method called from `Start`) to perform the visibility reset. This ensures the scene is fully loaded before making visibility changes.
- **Reference Validation**: Before applying `DisplayStyle` changes, the system will explicitly check if the `VisualElement` references are non-null.
- **Reset-First Strategy**: On initialization, the system will first hide ALL optional panels (`popUpCrearSala`, `pantallaSalaEspera`, `pantallaInventari`) before deciding whether to show `pantallaLogin` or `pantallaLobby`.
- **Session Check**: Use `userId` (or `WebSocketClient.LocalUsername`) as the indicator of "LoggedIn" status.

## Risks / Trade-offs

- **[Risk]** → If UXML names change, the logic will fail silently (references will be null).
  - **[Mitigation]** → Add `Debug.LogWarning` for null references during the init phase.
- **[Trade-off]** → A "reset-first" approach might cause a tiny flicker if a panel was already visible, but it ensures a clean state every time.
