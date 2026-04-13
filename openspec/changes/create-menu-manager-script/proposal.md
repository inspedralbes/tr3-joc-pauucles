## Why

The project needs a robust menu management system to handle the transition between the login screen and the game lobby using Unity's UI Toolkit. This script will manage user authentication (local name storage) and lobby navigation.

## What Changes

- **New Script**: Creation of `MenuManager.cs`.
- **Login Logic**: Added functionality to capture player names, save them to `PlayerPrefs`, and transition to the lobby.
- **Lobby Logic**: Added navigation between the lobby and login screens, along with placeholders for game creation and joining.
- **UI Toolkit Integration**: Direct reference and manipulation of `VisualElement` objects for screen visibility and event handling.

## Capabilities

### New Capabilities
- `menu-navigation-and-auth`: Defines the behavior for navigating between login and lobby states and persisting basic user identity.

### Modified Capabilities
<!-- No existing behavioral specs for menu management were found in openspec/specs/. -->

## Impact

- `MenuManager.cs`: A new script that will be attached to a GameObject with a `UIDocument` component.
- UI Design: Requires specific naming conventions in the `.uxml` file (`pantallaLogin`, `pantallaLobby`, `inputNomJugador`, etc.).
