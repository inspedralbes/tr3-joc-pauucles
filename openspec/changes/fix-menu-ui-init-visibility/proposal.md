## Why

When returning from the game scene to the main menu, the UI (UI Toolkit) often remains hidden or improperly initialized, resulting in an empty blue screen. This happens because the visibility logic doesn't account for the player's existing authentication state upon scene reload.

## What Changes

- **Automatic UI State Selection**: Implement logic in `MenuManager.cs` to automatically show either the Login screen or the Lobby screen based on the presence of authentication data.
- **Forced Visibility**: Ensure that the `UIDocument` and its core panels are never left in an ambiguous "hidden" state during `Start()` or initialization.
- **Session Check**: Add a check for existing session data (e.g., `WebSocketClient.LocalUsername` or `MenuManager.Instance.userId`) during the initialization phase.

## Capabilities

### New Capabilities
- `menu-reentry-visibility`: Ensures correct UI panel visibility when returning to the Menu scene based on authentication state.

### Modified Capabilities
- `foundations`: Update foundation specs to include menu state management on reentry.

## Impact

- `MenuManager.cs`: Primary location for the initialization and visibility logic.
- `WebSocketClient.cs`: Source of truth for existing session/username data.
