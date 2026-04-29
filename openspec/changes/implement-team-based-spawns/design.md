## Context

The `GameManager.cs` in the "Bosque" scene is responsible for player initialization. While a basic spawning mechanism exists, it needs to be reliably connected to the `WebSocketClient.Team` variable to ensure that players are teleported to their designated team bases (`PuntSpawn_Equip1` for Team A/Red and `PuntSpawn_Equip2` for Team B/Blue) as soon as the match starts.

## Goals / Non-Goals

**Goals:**
- Ensure `GameManager.cs` correctly identifies the local player.
- Link the `AssignarSpawn` logic strictly to `WebSocketClient.Team`.
- Support various team name formats (e.g., "1", "A", "Rojo", "Vermell" for Team 1).
- Provide clear debug feedback for spawn point assignment.

**Non-Goals:**
- Implementing a lobby-to-game synchronization (this is handled by `MenuManager`).
- Managing multiple spawn points per team (using a single point per team for now).

## Decisions

- **Singleton or Direct Reference**: `GameManager` will find the `Player` object using `Object.FindFirstObjectByType<Player>()` if not assigned, ensuring the script works even if the scene setup changes slightly.
- **Team Mapping Logic**: A robust mapping function will translate the `WebSocketClient.Team` string into a target spawn point name (`PuntSpawn_Equip1` or `PuntSpawn_Equip2`).
- **Modern Unity APIs**: Use `FindObjectsByType` instead of `FindObjectsOfType` (obsolete in newer Unity versions) to gather potential spawn points.
- **Immediate Teleportation**: Teleportation happens in `Start()` to ensure the player is in position before the first frame of gameplay is rendered to the user.

## Risks / Trade-offs

- **[Risk] Missing Assets**: If `PuntSpawn_Equip1` or `PuntSpawn_Equip2` are missing from the scene, the code will fail to teleport. → **Mitigation**: Error logs will explicitly state the missing object name to aid scene setup.
- **[Risk] Delayed Team Assignment**: If `WebSocketClient.Team` is not set when `Start()` runs. → **Mitigation**: Added a fallback/warning to help during development/testing.
