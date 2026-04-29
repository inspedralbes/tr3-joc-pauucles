## Why

The current `MenuManager.cs` performs authentication requests but doesn't transition the UI upon success. This change implements the logic to switch from the Login screen to the Lobby screen specifically after a successful `/login` request, improving the user experience and flow.

## What Changes

- **UI Transition Logic**: In the `EnviarPeticio` coroutine, add a check for the `/login` endpoint.
- **Screen Management**: Upon successful login, hide the `pantallaLogin` and show the `pantallaLobby` using UI Toolkit's `DisplayStyle`.
- **UI References**: Ensure `pantallaLogin` and `pantallaLobby` are correctly referenced within the class.

## Capabilities

### New Capabilities
- `login-ui-transition`: Automatically transitions the UI from Login to Lobby upon successful authentication.

### Modified Capabilities
- None.

## Impact

- `DAMT3Atrapa la bandera/Assets/Scripts/MenuManager.cs`: Primary file for script modifications.
- **UI Flow**: The user will now be automatically moved to the lobby after logging in.
