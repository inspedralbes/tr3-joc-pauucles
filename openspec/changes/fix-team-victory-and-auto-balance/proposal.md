## Why

The current match conclusion logic doesn't account for team affiliation, meaning players might see a victory or defeat screen that doesn't accurately reflect their team's outcome. Additionally, teams can become unbalanced if players join rooms without a mechanism to distribute them evenly, leading to unfair matches.

## What Changes

- **Team-Aware Victory Logic**: Update `GameManager.cs` to determine the local player's win/loss state by comparing their team to the winner's team received via WebSocket.
- **Client-Side Team Auto-Balancing**: Modify `MenuManager.cs` to automatically assign a joining player to the team with fewer participants, ensuring a 2vs2 distribution where possible.
- **Real-time Team Distribution**: Ensure team counts are checked immediately before the "join room" request is sent.

## Capabilities

### New Capabilities
- `team-victory-logic`: Accurately synchronizes win/loss states based on team results.
- `team-auto-balance`: Automatically distributes players between teams 'A' and 'B' to maintain balance.

### Modified Capabilities
- `foundations`: Update match foundation to support team-based synchronization.

## Impact

- `GameManager.cs`: Networked game-over handling.
- `MenuManager.cs`: Room joining and team assignment logic.
- Backend: Relies on correct team data being sent/received.
