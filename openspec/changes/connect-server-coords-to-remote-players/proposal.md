## Why

Currently, incoming player movement data from the server is not consistently routed to the correct remote player instances in the Unity client. This change establishes a clear data path from the WebSocket reception to the visual representation of remote players, enabling real-time multiplayer movement.

## What Changes

- **Public Remote Player Tracking**: Refactor `GameManager.cs` to maintain a public dictionary `remotePlayers` using `userId` as the key for efficient lookup.
- **Message Data Extraction**: Ensure `MenuManager.cs` (acting as the WebSocket controller) correctly extracts `userId`, `x`, and `y` from `PLAYER_MOVE` type messages.
- **Visual Update Trigger**: Implement logic to find the relevant player in the dictionary and trigger their interpolation logic via a dedicated update method.

## Capabilities

### New Capabilities
- `remote-coordinate-routing`: Logic to extract and route positional data from network messages to game objects.
- `player-tracking-dictionary`: A centralized management system for active remote player instances keyed by their unique identifiers.

### Modified Capabilities
- None.

## Impact

- `GameManager.cs`: Changes to the storage and accessibility of remote player references.
- `MenuManager.cs`: Changes to how incoming WebSocket messages are processed and dispatched.
- `NetworkSync.cs`: Potential interface updates to receive external coordinate updates.
