## Context

The `MenuManager` class is persistent (`DontDestroyOnLoad`), which means its state is preserved between scene loads. However, when returning from the game scene ("Bosque") to the menu scene ("MenuPrincipal"), the UI elements in the new scene's `UIDocument` might not align with the preserved state of the `MenuManager`. If the user is already logged in, the `Start()` or `OnEnable()` methods need to ensure that the "Lobby" screen is shown instead of the "Login" screen, avoiding a blank state.

## Goals / Non-Goals

**Goals:**
- Fix the blank/blue screen on menu reentry.
- Automatically navigate to the Lobby if the user is already authenticated.
- Ensure all relevant UI panels are set to a known visibility state (Flex/None) on start.

**Non-Goals:**
- Implementing a persistent token/cookie system for cross-session login (focus is on scene transitions within the same session).
- Redesigning the UI layout.

## Decisions

- **Entry Point for Visibility**: Use the `Start()` method in `MenuManager.cs` to perform the final visibility check, as it runs after the new `UIDocument` in the scene has been initialized and `OnEnable()` has likely finished fetching references.
- **Authentication Source**: Check `WebSocketClient.LocalUsername` and `MenuManager.Instance.userId`. If either is non-null and non-empty, the user is considered authenticated.
- **Forced Panel State**:
  - If authenticated: `pantallaLogin.style.display = DisplayStyle.None`, `pantallaLobby.style.display = DisplayStyle.Flex`.
  - If not authenticated: `pantallaLogin.style.display = DisplayStyle.Flex`, `pantallaLobby.style.display = DisplayStyle.None`.
- **WebSocket Reconnection**: Ensure that if we return to the menu, the WebSocket is still active or re-initialized if necessary (though `MenuManager` is persistent).

## Risks / Trade-offs

- **[Risk]** → `UIDocument` references might be lost or pointing to destroyed objects if not handled carefully during scene transitions.
  - **[Mitigation]** → Re-fetch or validate UI references in `OnEnable` or a dedicated initialization method called from `Start`.
- **[Trade-off]** → Using `Start` might cause a single-frame flicker of the default UI state before switching.
  - **[Mitigation]** → Acceptable for now; the primary goal is avoiding the stuck "blue screen" state.
