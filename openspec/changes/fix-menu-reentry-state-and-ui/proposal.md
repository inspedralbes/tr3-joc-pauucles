## Why

When returning from the game scene to the main menu, the `MenuManager` (which is a persistent singleton) often retains stale room data and fails to rebind UI Toolkit button events for the new scene's `UIDocument`. This prevents players from creating new rooms or interacting with the menu correctly upon reentry.

## What Changes

- **State Cleanup**: Implement `NetejarEstatTornada()` in `MenuManager.cs` to clear room-related variables.
- **Scene-Aware Initialization**: Use `SceneManager.sceneLoaded` in `MenuManager.cs` to trigger UI rebinding and lobby navigation when the "MenuPrincipal" scene is loaded.
- **Mandatory Cleanup Call**: Update `GameManager.TornarAlMenu()` to call the cleanup method before loading the menu scene.

## Capabilities

### New Capabilities
- `menu-state-cleanup`: Resets the persistent menu state to allow fresh interactions after a match ends.
- `scene-reentry-binding`: Automatically re-registers UI events when returning to the main menu scene.

### Modified Capabilities
- `foundations`: Update base scene transition and state management foundations.

## Impact

- `MenuManager.cs`: Updated to handle scene load events and state resets.
- `GameManager.cs`: Modified to ensure state cleanup before scene transitions.
- `UIDocument`: Menu UI elements will be rebound dynamically.
