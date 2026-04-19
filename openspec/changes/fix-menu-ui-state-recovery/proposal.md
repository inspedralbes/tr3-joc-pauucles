## Why

When reloading the `MenuPrincipal` scene from the game, UI Toolkit elements can sometimes overlap or remain in an incorrect visibility state because the initialization logic doesn't explicitly reset all secondary panels. This results in a broken user experience where multiple screens might be visible at once or the main screens remain hidden.

## What Changes

- **Explicit UI Initialization**: Ensure `MenuManager.cs` explicitly finds and sets the initial state of `pantallaLogin` and `pantallaLobby` upon scene load.
- **Session-Based State Recovery**: Automatically toggle between Login and Lobby panels based on the existing authentication state (userId/username).
- **Secondary Panel Reset**: Force-hide secondary UI elements like `popUpCrearSala`, `pantallaSalaEspera`, and `pantallaInventari` by default on initialization to prevent overlaps.

## Capabilities

### New Capabilities
- `ui-state-recovery`: Ensures the menu UI correctly reflects the user's session state and resets all transient panels upon scene reload.

### Modified Capabilities
- `foundations`: Update foundation specs to include robust UI state initialization.

## Impact

- `MenuManager.cs`: Updated `Start` and `OnEnable` logic for UI discovery and state management.
- `UIDocument`: The main menu UI toolkit document.
