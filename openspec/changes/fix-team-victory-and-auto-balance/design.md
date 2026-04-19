## Context

The current victory logic in `GameManager.cs` is based on individual player identity rather than team affiliation. This causes issues in team-based matches where a teammate's victory should count as a victory for the entire team. Additionally, players can join rooms without team balancing, often resulting in uneven teams (e.g., 3vs1) instead of the desired 2vs2 distribution.

## Goals / Non-Goals

**Goals:**
- Implement team-aware victory detection when a `GAME_OVER` message is received.
- Implement client-side team auto-balancing during the room joining process.
- Ensure the local player's win/loss state correctly reflects their team's outcome.

**Non-Goals:**
- Server-side validation of team balance (this remains a client-side "best effort" for now).
- Changing the backend WebSocket message structure.
- Modifying the UI of the victory/defeat screen.

## Decisions

### 1. Team-Aware Victory Logic
- **Decision**: Update `MenuManager.cs` WebSocket message handler for `GAME_OVER` to delegate victory determination to `GameManager`.
- **Rationale**: `GameManager` already manages the local player's state and team affiliation.
- **Implementation**:
    - Add `EsDelMeuEquip(string winnerUsername)` to `GameManager.cs`.
    - This method will look up the `winnerUsername` in `MenuManager.Instance.currentRoomData.players` to find their team.
    - Compare it with `localPlayer.equip`.
    - `MenuManager` will call `GameManager.Instance.FinalitzarPartida(GameManager.Instance.EsDelMeuEquip(goMsg.winner))`.

### 2. Client-Side Auto-Balance
- **Decision**: Calculate the optimal team in `MenuManager.UnirseAPartida` before sending the `POST /games/join` request.
- **Rationale**: The client already has the room data (including the player list) from the lobby list.
- **Implementation**:
    - In `UnirseAPartida(string roomId)`, retrieve the `GameData` for the selected room.
    - Iterate through `gameData.players` and count how many belong to team "A" and how many to team "B".
    - Assign the local player to the team with the lower count.
    - If counts are equal, assign randomly (or default to "A").
    - Update `JoinGameData.team` with the calculated team before sending.

## Risks / Trade-offs

- **[Risk] Race Condition in Auto-Balance** → If two players join the same room simultaneously, they might both see the same team counts and pick the same team.
    - *Mitigation*: Since this is a client-side fix for a small-scale project, we accept this risk. A full fix would require server-side assignment.
- **[Risk] Room Data Desync** → The lobby list might be slightly outdated when joining.
    - *Mitigation*: The `llistaPartides` is updated via WebSocket, minimizing the window for desync.
