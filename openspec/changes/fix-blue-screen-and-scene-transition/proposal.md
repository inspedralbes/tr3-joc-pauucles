## Why

This change addresses a critical bug where players encounter a "blue screen" (empty scene) or fail to transition to the game scene correctly after a match starts. The current implementation likely misses mandatory data persistence for the player's session (Username, Team, Color) and relies on potentially unreliable scene transition logic that doesn't trigger correctly or fast enough after receiving the start event.

## What Changes

- **Update `MenuManager.cs`**: Add `using UnityEngine.SceneManagement;` to enable explicit scene loading.
- **Structured Data Handling**: Define a `PartidaIniciadaMsg` helper class to reliably parse the full `PARTIDA_INICIADA` JSON message.
- **Mandatory Data Persistence**: Update the `PARTIDA_INICIADA` handler to save the local player's `username`, `team`, and `color` into `WebSocketClient` static properties immediately upon receipt.
- **Explicit Scene Transition**: Add a direct call to `SceneManager.LoadScene("Bosque")` within the `EnqueueMainThread` block after hiding the UI, ensuring the transition happens immediately and without exceptions.

## Capabilities

### New Capabilities
- `game-transition`: Reliable transition from lobby to game scene with session data persistence.

### Modified Capabilities
- None

## Impact

- **Affected Code**: `MenuManager.cs`, `WebSocketClient.cs` (static properties).
- **APIs**: Client-side message handling logic for `PARTIDA_INICIADA`.
- **System**: Game initialization flow and scene management.
