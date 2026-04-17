## Why

This change implements a team-based spawning system to ensure players start the match at their respective team bases (Red/Team A or Blue/Team B). Currently, players might spawn at a default location, which is not suitable for a competitive "Capture the Flag" style game.

## What Changes

- **New `GameManager.cs`**: Create or update a `GameManager` script in the "Bosque" scene to handle match initialization.
- **Team-Aware Spawning**: Read the persistent team data from `WebSocketClient.Team` to determine the correct spawn point.
- **Player Relocation**: Find the local player GameObject and teleport them to either `PuntSpawn_Equip1` or `PuntSpawn_Equip2` upon scene start.
- **Initialization Logging**: Add debug logs to track which spawn point was assigned to the player.

## Capabilities

### New Capabilities
- `team-spawns`: Automatic teleportation of players to team-specific spawn points during match initialization.

### Modified Capabilities
- None

## Impact

- **Affected Code**: `GameManager.cs` (new/updated), `WebSocketClient.cs` (read-only access to static fields).
- **Assets**: Requires `PuntSpawn_Equip1` and `PuntSpawn_Equip2` GameObjects to be present in the "Bosque" scene.
- **System**: Match start flow and initial player positioning.
