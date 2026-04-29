## Context

The `MenuManager.cs` currently lacks the UI references and logic to navigate between screens after a successful network operation. This design addresses this by adding class-level references to the relevant UI elements and implementing the transition within the `EnviarPeticio` coroutine.

## Goals / Non-Goals

**Goals:**
- Add `pantallaLogin` and `pantallaLobby` as private `VisualElement` members.
- Retrieve these elements in `OnEnable`.
- Implement conditional screen switching in `EnviarPeticio` specifically for the `/login` endpoint on success.

**Non-Goals:**
- Implementation of transition effects or animations.
- Refactoring the entire UI management system.

## Decisions

- **Class-level UI references**: Store references to `pantallaLogin` and `pantallaLobby` to avoid re-querying the document during runtime.
- **DisplayStyle for Transitions**: Use `DisplayStyle.None` and `DisplayStyle.Flex` as they are the standard way to hide and show elements in UI Toolkit.
- **Endpoint Check**: Perform an explicit string comparison on the `endpoint` parameter to ensure the transition only occurs for login.

## Risks / Trade-offs

- **Naming Dependency**: The design relies on specific element names ("pantallaLogin", "pantallaLobby") in the UXML. [Risk] → Mitigation: Ensure naming consistency and add null checks before attempting to set styles.
