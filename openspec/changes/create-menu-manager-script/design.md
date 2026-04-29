## Context

The application needs a main menu script to manage state transitions between a login view and a lobby view using Unity's UI Toolkit (`UnityEngine.UIElements`). The script will be attached to a GameObject that contains a `UIDocument`.

## Goals / Non-Goals

**Goals:**
- Provide a clear transition between login and lobby.
- Persist the player's chosen name locally.
- Implement event-driven navigation using `VisualElement` callbacks.
- Log placeholder actions for creating and joining games.

**Non-Goals:**
- Implementation of the actual network logic for creating or joining games.
- Server-side authentication or password validation.
- Visual styling or layout of the UI elements (handled in `.uxml`/`.uss`).

## Decisions

### Decision 1: Use `OnEnable` for Initialization
**Rationale**: In UI Toolkit, elements are often not fully ready in `Awake`. `OnEnable` is the standard place to query the `rootVisualElement` and register callbacks.
**Implementation**: Use `GetComponent<UIDocument>().rootVisualElement` to start querying.

### Decision 2: Query by Name (Selector)
**Rationale**: The user requested specific names (e.g., `pantallaLogin`, `btnLogin`). Using `root.Q<T>("name")` is the standard way to find elements.
**Implementation**: Use `VisualElement`, `TextField`, `Button`, and `ListView` types for querying.

### Decision 3: Visibility Management via `style.display`
**Rationale**: The most straightforward way to switch between "screens" in a single `UIDocument` is to toggle the `display` style between `Flex` and `None`.
**Implementation**:
- `pantallaLogin.style.display = DisplayStyle.None;`
- `pantallaLobby.style.display = DisplayStyle.Flex;`

### Decision 4: Local Persistence via `PlayerPrefs`
**Rationale**: For a prototype, `PlayerPrefs` is the easiest way to save a string between sessions without external dependencies.
**Implementation**: `PlayerPrefs.SetString("nomJugador", inputNomJugador.value);`

## Risks / Trade-offs

- **[Risk]** UI Elements might be null if the `.uxml` is changed without updating the script.
- **[Mitigation]** Include null checks after querying each element and log warnings if they are missing.
- **[Risk]** `OnEnable` might trigger multiple times if the GameObject is toggled.
- **[Mitigation]** Use `RegisterCallback` or `clicked += ...` carefully, though usually `clicked` is safe in `OnEnable` if the object is enabled/disabled.
