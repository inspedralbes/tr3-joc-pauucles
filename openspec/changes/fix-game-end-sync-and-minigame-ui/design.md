## Context

The current game state synchronization lacks a mechanism to notify the opponent when a match has ended. When a player captures the flag and triggers `FinalitzarPartida(true)`, the other player remains in the game state without knowing they have lost.
Additionally, the minigame UI suffers from intermittent invisibility issues, likely due to the UI root not being explicitly activated or displayed before its children logic starts.

## Goals / Non-Goals

**Goals:**
- Synchronize game termination across all clients in a room.
- Ensure the minigame UI is always visible when active.
- Align method naming in `MinijocUIManager` with the requested `IniciarMinijoc`.

**Non-Goals:**
- Implementing complex server-side validation for game over (trusting client broadcast for now).
- Refactoring the entire WebSocket architecture.

## Decisions

- **WebSocket Event**: Implement a new message type `GAME_OVER`.
  - Structure: `{ "type": "GAME_OVER", "roomId": "...", "winner": "...", "loser": "..." }`.
- **Backend Role**: `server.js` will receive `GAME_OVER` and broadcast it to all clients in the same room (excluding sender).
- **Frontend Listener**: `MenuManager.cs` (which manages the WebSocket connection) will listen for `GAME_OVER`.
  - When received, it will call `GameManager.Instance.FinalitzarPartida(false)` on the main thread.
- **Trigger**: `GameManager.FinalitzarPartida(true)` will be responsible for sending the `GAME_OVER` message.
- **UI Visibility Fix**: 
  - Rename `MinijocUIManager.ShowUI` to `MinijocUIManager.IniciarMinijoc`.
  - In `IniciarMinijoc`, explicitly set `_uiDocument.rootVisualElement.style.display = DisplayStyle.Flex` and ensure the underlying GameObject is active.
  - Call `AmagarTotsElsContenidors()` immediately after to clear previous states, then activate the specific minigame container.

## Risks / Trade-offs

- **[Risk]** → Network latency might cause a delay in showing the "Game Over" screen for the loser.
  - **[Mitigation]** → Acceptable for this project scope; the state is eventually consistent.
- **[Risk]** → `GameManager.Instance` might be null if the message arrives during a scene transition.
  - **[Mitigation]** → Add null checks before calling `FinalitzarPartida`.
- **[Trade-off]** → Using `MenuManager` for game logic messages might bloat it, but since it currently owns the WebSocket connection, it's the most straightforward path.
