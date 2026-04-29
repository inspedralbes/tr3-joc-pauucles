## Context

The current `MenuManager.cs` is a Unity MonoBehaviour that manages user authentication via `UnityWebRequest` and `UI Toolkit`. It currently uses a hardcoded `baseUrl` that includes the resource path, making it inflexible for other API resources like games.

## Goals / Non-Goals

**Goals:**
- Update the API base URL to a generic version (`/api`).
- Implement the UI logic for a new game creation flow.
- Ensure data integrity via client-side validation of team selections.

**Non-Goals:**
- Modifying the UXML layout file (assumed to already contain the required elements).
- Implementing the backend `/games/create` endpoint.
- Handling game room listing or joining (out of scope for this change).

## Decisions

- **API Endpoint Refactoring**: The `baseUrl` will be set to `http://localhost:3000/api`. Coroutines like `RegistrarUsuari` and `FerLogin` will now pass more specific paths (e.g., `/users/register`) to the `EnviarPeticio` method.
- **UI Toolkit Binding**: New fields will be added to `MenuManager` to store references to the game creation pop-up and its controls. These will be initialized in `OnEnable` using `root.Q<T>`.
- **Data Serialization**: A new `[System.Serializable]` class `CreateGameData` will be defined to represent the game configuration object, ensuring compatibility with `JsonUtility`.
- **Validation Logic**: `CrearNovaSala` will perform a value comparison between the two team dropdowns. If they match, the process is halted with a warning. This prevents creating invalid "same-team" games.

## Risks / Trade-offs

- **[Risk] UI Reference Nulls**: If the UXML doesn't match the IDs used in the script (e.g., `popUpCrearSala`), the script will fail to bind events. 
    - **Mitigation**: Use null checks where appropriate and ensure clear documentation of required UI element names.
- **[Risk] Backend Compatibility**: The `CreateGameData` fields must match the backend's expectations.
    - **Mitigation**: Following the exact field names provided: `teamAColor`, `teamBColor`, and `maxPlayers`.
