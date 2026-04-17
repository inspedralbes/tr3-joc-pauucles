## Context

The game currently experiences issues during the transition from the lobby to the game scene ("Bosque"). This is characterized by a "blue screen" or failure to load the scene. Additionally, player session data (Username, Team, Color) is not reliably persisted before the scene transition. There is also a dual WebSocket implementation (`MenuManager` using `NativeWebSocket` and `WebSocketClient` using `System.Net.WebSockets`) which might be causing conflicting logic.

## Goals / Non-Goals

**Goals:**
- Ensure `MenuManager.cs` handles the `PARTIDA_INICIADA` message by parsing all player data.
- Persist player data to `WebSocketClient` static properties.
- Trigger a reliable scene transition to "Bosque" immediately after UI adjustments.
- Use `UnityEngine.SceneManagement` explicitly in `MenuManager`.

**Non-Goals:**
- Removing the `WebSocketClient.cs` file (though its transition logic might become redundant).
- Refactoring the entire networking architecture.

## Decisions

- **Explicit Scene Loading**: Use `SceneManager.LoadScene("Bosque")` directly in `MenuManager`'s main thread queue. This ensures the engine handles the scene swap immediately.
- **Typed Message Parsing**: Create a local `PartidaIniciadaMsg` class inside `MenuManager` to parse the JSON message reliably using `JsonUtility`.
- **Static State Persistence**: Populate `WebSocketClient.Username`, `WebSocketClient.Team`, and `WebSocketClient.ColorName` before scene loading. These fields are used by the `Player` script in the next scene.

## Risks / Trade-offs

- **[Risk] Dual Logic**: Both `MenuManager` and `WebSocketClient` might try to load the scene if both receive the message. → **Mitigation**: The explicit logic in `MenuManager` (requested by user) will be the primary driver. If issues persist, `WebSocketClient` logic might need to be disabled.
- **[Risk] Scene Name mismatch**: If "Bosque" is not the exact name in Build Settings, it will fail. → **Mitigation**: Assuming "Bosque" is the correct scene name as per instructions.
