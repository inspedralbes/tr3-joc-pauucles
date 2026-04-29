## Why

The current UI lacks visual polish and contains stale room information that clutter the lobby. Specifically, the room list includes abandoned "waiting" sessions, the player's life count isn't visually represented with a modern HUD, and the minigame UI lacks consistent styling and readability.

## What Changes

- **Room Filtering**: Update the room list logic to automatically exclude rooms in "waiting" state that were created more than 10 minutes ago.
- **Lives HUD**: Implement a visual representation of player health using heart icons (`iconaVida`) in a dedicated UI container.
- **UI Aesthetic Refresh**: Apply semi-transparent black backgrounds to minigame containers and standardize button styles (black background, white text, minimum dimensions) to improve readability and prevent layout overlaps.
- **Lives Configuration**: Standardize player initial and maximum lives to 3.

## Capabilities

### New Capabilities
- `room-filtering`: Logic to exclude stale "waiting" rooms from the lobby list based on creation time.
- `player-lives-hud`: A dynamic UI component that renders heart icons based on the player's current health.
- `minigame-ui-styling`: Standardized styling for minigame interfaces, including background overlays and button aesthetics.

### Modified Capabilities
- `foundations`: Update global UI standards for buttons and overlays.

## Impact

- `MenuManager.cs`: Changes to `AlRebreActualitzacioSales` for filtering logic.
- `Player.cs`: Changes to life variables and `UpdateLivesUI` implementation.
- `MinijocUIManager.cs`: Procedural styling of UI elements.
- UI Assets: Use of `iconaVida` sprite.
