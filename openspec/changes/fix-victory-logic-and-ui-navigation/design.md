## Context

The game uses a mix of local player logic and remote player (clone) logic. The collision handler in `Player.cs` for the base/flag capture is currently shared, leading to the remote player's actions accidentally triggering the local victory UI.
In `GameManager.cs`, the `FinalitzarPartida` method sends a `GAME_OVER` WebSocket message but was using an uninitialized or incorrect variable for the `roomId`.
UI Toolkit event binding in Unity can be tricky if the UI document is not fully initialized or if specific elements are missed by singular queries.

## Goals / Non-Goals

**Goals:**
- Isolate victory triggers to the local player instance.
- Ensure correct data flow for the `GAME_OVER` WebSocket broadcast.
- Stabilize the "Back to Menu" UI navigation.

**Non-Goals:**
- Changing the physics system or collision layers.
- Modifying the server-side room validation logic.

## Decisions

- **Local Player Check**: Use `gameObject.name.Contains("(Clone)")` and/or check for the absence of local-only components to identify remote players in `Player.cs`. A `return` statement will be added at the top of the trigger method for these instances.
- **Room ID Sourcing**: Explicitly use `MenuManager.Instance.currentRoomData.roomId` in `GameManager.cs`. This ensures we pull from the source of truth that is preserved in the `MenuManager` singleton.
- **Query-Based Button Binding**: Use `root.Query<Button>("BotoTornar").ToList()` to find all instances of the button in the visual tree and subscribe to their `clicked` event. This is more resilient than `Q<Button>`.
- **Navigation Feedback**: Add explicit `Debug.Log` statements in `TornarAlMenu` to confirm the user interaction was captured before calling `SceneManager.LoadScene`.

## Risks / Trade-offs

- **[Risk]** → If the `MenuManager.Instance` or `currentRoomData` is null, the game might crash during the victory sequence.
  - **[Mitigation]** → Add null checks before accessing the room ID.
- **[Trade-off]** → Filtering by name string `(Clone)` is slightly brittle if Unity changes naming conventions.
  - **[Mitigation]** → Combine with a component check (e.g., `GetComponent<RemotePlayer>() != null`) for better reliability.
