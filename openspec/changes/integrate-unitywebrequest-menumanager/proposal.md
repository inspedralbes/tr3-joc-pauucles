## Why

The Unity application needs to communicate with the backend server for user registration and login. Integrating `UnityWebRequest` in the `MenuManager` script enables the game to send and receive authentication data, bridging the gap between the game client and the backend API.

## What Changes

- **UnityWebRequest Integration**: Added `using UnityEngine.Networking;` to `MenuManager.cs`.
- **Backend Configuration**: Added a private `baseUrl` field pointing to the backend API.
- **Authentication Data Structure**: Introduced an internal serializable `AuthData` class for JSON serialization.
- **Authentication Methods**: Implemented `RegistrarUsuari` and `FerLogin` methods to trigger authentication requests.
- **Network Coroutine**: Created an `EnviarPeticio` coroutine to handle asynchronous POST requests with JSON payloads and provide success/failure feedback via Debug logs.

## Capabilities

### New Capabilities
- `unity-backend-auth-integration`: Enables the Unity client to perform user registration and login via the backend API.

### Modified Capabilities
<!-- No requirement changes to existing specs. -->

## Impact

- `DAMT3Atrapa la bandera/Assets/Scripts/MenuManager.cs`: Primary location for the changes.
- **Dependencies**: Depends on the backend server being active at `http://localhost:3000`.
