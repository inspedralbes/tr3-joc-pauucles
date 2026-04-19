## Why

Currently, starting a minigame might be freezing all players or using a global state that affects everyone. This change aims to make the combat/minigame transition selective, only locking the two players involved in the collision, which improves gameplay flow for other participants in a multiplayer environment.

## What Changes

- **Selective Player Locking**: Update the collision detection to identify both participants (local and enemy).
- **Context-Aware Minigame Initialization**: Pass both player references to the `MinijocUIManager`.
- **Targeted Movement Restriction**: `MinijocUIManager` will only disable `potMoure` (or the movement component) for the specific fighters.
- **Independent Match Flow**: Ensure that non-combatants can continue moving and capturing flags while a minigame is in progress between two other players.
- **Selective Movement Restoration**: Restore movement only to the two specific fighters once the minigame concludes.

## Capabilities

### New Capabilities
- `selective-combat-locking`: Management of movement locking/unlocking for specific pairs of players during combat.

### Modified Capabilities
- `foundations`: Adjust the base minigame/combat trigger requirements to support targeted player references.

## Impact

- `Player.cs`: Collision detection logic and fighter identification.
- `MinijocUIManager.cs`: Fighter tracking and movement control logic.
- Game Flow: Transitions between world exploration and minigames.
