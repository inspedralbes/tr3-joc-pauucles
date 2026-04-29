## Context

The Unity project is transitioning to UI Toolkit for its menu systems. `MenuManager.cs` currently needs to be updated to interface with these new UI components while maintaining its core backend communication logic.

## Goals / Non-Goals

**Goals:**
- Transition `MenuManager.cs` to use `UnityEngine.UIElements`.
- Bind UI Toolkit elements to the registration and login methods.
- Maintain existing authentication logic and coroutines.

**Non-Goals:**
- Implementation of new authentication features.
- Design or layout of the UI (handled in UXML/USS files).

## Decisions

- **OnEnable for Initialization**: Use the `OnEnable` lifecycle method to ensure UI elements are queried whenever the component is activated.
- **Direct Querying**: Use `root.Q<T>(name)` for surgical element retrieval, matching the exact names defined in the UXML.
- **Lambda Event Binding**: Employ anonymous lambda functions (`() => ...`) for button `clicked` events to succinctly pass input field values to the service methods.
- **Removal of TMPro**: All TextMeshPro namespaces and variables will be removed to prevent confusion and reduce overhead.

## Risks / Trade-offs

- **UXML Naming Dependency**: If the names in the UXML change, the script will fail to find elements. **Mitigation**: Use strict naming conventions and verify names during implementation.
- **Component Dependency**: The script assumes a `UIDocument` is present on the same GameObject. **Mitigation**: Add a null check or `[RequireComponent(typeof(UIDocument))]` if necessary.
