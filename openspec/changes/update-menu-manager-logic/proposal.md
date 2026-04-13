## Why

The current `MenuManager.cs` requires specific interaction logic for the lobby buttons to ensure correct screen transitions and provide developer feedback during the room creation and joining process.

## What Changes

- **Lobby Navigation**: Updated `btnTancarLobby` to hide the lobby screen and show the login screen.
- **Room Creation Feedback**: Added a debug log to `btnCrearPartida` to signal the start of room creation.
- **Room Joining Feedback**: Added a debug log to `btnUnirsePartida` to signal an attempt to join a room.
- **Persistence**: Maintained existing `btnLogin` functionality for transitioning from login to lobby.

## Capabilities

### New Capabilities
- `menu-interaction-refinement`: Refines the UI interaction logic for the main menu and lobby screens.

### Modified Capabilities
<!-- No requirement changes to existing specs. -->

## Impact

- `MenuManager.cs`: Modifications to event callbacks and button logic.
