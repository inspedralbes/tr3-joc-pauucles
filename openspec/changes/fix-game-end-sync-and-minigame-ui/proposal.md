## Why

The game lacks proper synchronization for the end-game state via WebSockets, leading to inconsistent states between clients when a player wins. Additionally, the minigame UI is often invisible when starting a combat because its root visibility isn't explicitly set before the logic begins.

## What Changes

- **Game End Synchronization**:
  - Modify `GameManager.cs` to emit a `GAME_OVER` WebSocket message when `FinalitzarPartida(true)` is called.
  - Add a listener for `GAME_OVER` in the client (likely in `WebSocketClient.cs` or `GameManager.cs`) to trigger `FinalitzarPartida(false)` for the other player.
- **Minigame UI Visibility**:
  - Rename `ShowUI` to `IniciarMinijoc` in `MinijocUIManager.cs` (to match the requested naming and clarify intent).
  - Ensure `IniciarMinijoc` sets the UI root to visible (`DisplayStyle.Flex` and/or `gameObject.SetActive(true)`) immediately before triggering specific minigame logic.
  - Update calls to `ShowUI` in `Player.cs` to `IniciarMinijoc`.

## Capabilities

### New Capabilities
- `game-over-sync`: Synchronizes the 'GAME_OVER' state across all clients via WebSockets when one player wins.
- `minigame-ui-visibility-fix`: Ensures the minigame UI is correctly displayed and activated when a combat starts.

### Modified Capabilities
- `foundations`: Update game flow foundations to include networked game termination.

## Impact

- `GameManager.cs`: Logic for sending and receiving game over events.
- `MinijocUIManager.cs`: Visibility logic and method renaming.
- `Player.cs`: Call site for starting minigames.
- `WebSocketClient.cs` (or equivalent): Handling of the new `GAME_OVER` message type.
- Backend `server.js`: Broadcasting the `GAME_OVER` message.
