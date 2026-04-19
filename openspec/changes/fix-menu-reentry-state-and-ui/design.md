## Context

The `MenuManager` class is a singleton marked with `DontDestroyOnLoad`. While this preserves session data (like the user's name), it also causes issues because Unity's UI Toolkit references (`UIDocument`) are destroyed when scenes change. When returning to the "MenuPrincipal" scene, the `MenuManager` needs to re-fetch and re-bind all UI events to the newly instantiated UI elements. Additionally, internal variables like `currentRoomId` must be reset to avoid logical inconsistencies (e.g., the system thinking the player is still in a room).

## Goals / Non-Goals

**Goals:**
- Implement a robust cleanup method for the `MenuManager`.
- Ensure UI events are correctly rebound every time the menu scene loads.
- Enforce the cleanup call in `GameManager` before navigation.

**Non-Goals:**
- Changing the `DontDestroyOnLoad` pattern for `MenuManager`.
- Modifying the UXML structure.

## Decisions

- **Event Subscription**: Use `SceneManager.sceneLoaded` in `MenuManager.Awake` to register a callback. This callback will check if the loaded scene is "MenuPrincipal" and, if so, trigger the rebinding logic.
- **State Clearing**: `NetejarEstatTornada()` will explicitly set `currentRoomId = ""` and `currentRoomData = null`.
- **UI Binding Encapsulation**: Move the logic currently in `OnEnable` (that finds buttons and registers clicks) into a private method `VincularEsdevenimentsUI()` so it can be called from both `OnEnable` and the `sceneLoaded` callback.
- **Mandatory Sequence**: The `GameManager.TornarAlMenu` method will be modified to follow this order: 1) Disconnect WebSocket, 2) Clean Menu State, 3) Load Scene.

## Risks / Trade-offs

- **[Risk]** → If `sceneLoaded` is triggered before the `UIDocument` in the new scene is ready, binding might fail.
  - **[Mitigation]** → Add a null check for `rootVisualElement` and consider calling the binding logic with a slight delay or ensuring it happens after the native `OnEnable` of the scene components.
- **[Trade-off]** → Binding events twice (once in `OnEnable` and once in `sceneLoaded`) could lead to duplicate callbacks.
  - **[Mitigation]** → Use the `-=` operator before `+=` to ensure only one instance of the listener is registered.
