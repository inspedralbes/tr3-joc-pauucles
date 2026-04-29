## Why

The current game logic allows enemy clones to trigger a local victory state upon colliding with the base, which is incorrect as only the local player should be able to trigger this state for themselves. Furthermore, the `GAME_OVER` message is being sent with an empty `roomId`, causing synchronization failures on the backend, and the "Back to Menu" button in the end-game screen is not reliably responding to user clicks.

## What Changes

- **Local-Only Victory Trigger**: Modify `Player.cs` to ignore base collisions if the player is a remote clone.
- **Robust Room ID Retrieval**: Update `GameManager.cs` to correctly fetch the active room ID from the `MenuManager` persistent data when broadcasting a game-over event.
- **UI Toolkit Button Subscription**: Fix the event binding for the "BotoTornar" button in `GameManager.cs` using a query-based approach to ensure all instances are covered.

## Capabilities

### New Capabilities
- `victory-logic-refinement`: Ensures only the local player can trigger the victory sequence for their client.
- `game-over-sync-fix`: Corrects the room identification in networked game-over messages.
- `ui-navigation-fix`: Reliable button event subscription for UI Toolkit-based menus.

### Modified Capabilities
- `foundations`: Update base collision and scene transition foundations.

## Impact

- `Player.cs`: Collision logic.
- `GameManager.cs`: Network messaging and UI event handling.
- `MenuManager.cs`: Data source for room information.
