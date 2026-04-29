## Why

Users are experiencing a "blue screen" lock (empty UI state) immediately after a successful login. This occurs because the UI state transition in `MenuManager.cs` might not be robustly triggered or synchronized with the session data update, leaving the `UIDocument` root or the main panels in an inconsistent state.

## What Changes

- **Immediate Visibility Update**: Explicitly call `ActualitzarVisibilitatSegonsSessio()` immediately after the user session data (username and skin) is saved in the login success handler.
- **Fallback Manual Toggle**: Implement manual `DisplayStyle` overrides for `pantallaLogin` and `pantallaLobby` within the main thread context to ensure the transition occurs even if the reference-based method has issues.
- **Traceability**: Add diagnostic logging to confirm the UI switch from Login to Lobby.

## Capabilities

### New Capabilities
- `login-ui-transition-reliability`: Ensures a consistent and immediate UI state transition upon successful authentication.

### Modified Capabilities
- `foundations`: Update UI state management foundations for authenticated sessions.

## Impact

- `MenuManager.cs`: Updated `EnviarPeticio` logic for the `/users/login` endpoint.
- User Experience: Eliminates the blank screen state following login.
