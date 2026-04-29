## Context

The `MenuManager` handles HTTP requests for authentication. Upon a successful login response from `/users/login`, the client saves the user ID and skin preferences. However, the subsequent UI transition to the Lobby screen is currently reliant on local panel references that might not be correctly updated or forced in all execution paths, leading to a "blue screen" (no panel visible).

## Goals / Non-Goals

**Goals:**
- Force a reliable UI switch from Login to Lobby immediately after authentication data is stored.
- Leverage the existing `ActualitzarVisibilitatSegonsSessio()` method for consistency.
- Provide clear console feedback for the transition.

**Non-Goals:**
- Refactoring the entire `MenuManager` networking logic.
- Changing the authentication API response format.

## Decisions

- **Direct Method Call**: Instead of relying solely on the localized checks in `EnviarPeticio`, the system will call `ActualitzarVisibilitatSegonsSessio()`. This method already contains the logic to ensure the root `UIDocument` is visible and toggles the main panels.
- **Thread Safety**: Ensure the UI updates happen within the main thread context (though `EnviarPeticio` as a Coroutine already runs on the main thread, the explicit call reinforces the sequence).
- **Log Prefixing**: Use `[MenuManager]` as a standard prefix for the transition log to assist in debugging.

## Risks / Trade-offs

- **[Risk]** → `ActualitzarVisibilitatSegonsSessio()` might fail if UI references (`pantallaLogin`, `pantallaLobby`) are null.
    - **[Mitigation]** → The method already includes null-checks. If references are null, the manual fallback logic in `EnviarPeticio` will still attempt to find them via `root.Q`.
- **[Trade-off]** → Redundant visibility checks.
    - **[Mitigation]** → Minimal performance impact compared to the cost of a locked UI state.
