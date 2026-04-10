## Why

This change integrates the gameplay consequences of winning or losing minigames into the `Player.cs` controller. It ensures that minigame outcomes have a direct impact on the game loop by managing player lives, movement restrictions, and temporary invulnerability.

## What Changes

- Modified `Player.cs` to include a life system (3 lives) displayed via Text UI.
- Implemented loss consequences: dropping the flag, losing a life, and a 7-second movement freeze with visual feedback (color change).
- Implemented "death" logic: when lives reach 0, the player teleports to a respawn point and is frozen for 45 seconds.
- Implemented win consequences: 5 seconds of invulnerability with visual feedback.
- Used Unity Coroutines for managing timed states (freezes, invulnerability).

## Capabilities

### New Capabilities
- `player-consequences`: Logic for handling player states (lives, invulnerability, movement lock) based on external game events.

### Modified Capabilities
- `plan`: Updating the player movement and state logic to accommodate temporary restrictions and invulnerability.

## Impact

- **Player.cs**: Major logic additions for state management.
- **UI**: Requirement for a Text component to display lives.
- **Gameplay**: Introduces temporary disables and respawn mechanics.
