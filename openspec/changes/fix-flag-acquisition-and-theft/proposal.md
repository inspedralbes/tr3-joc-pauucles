## Why

The current flag acquisition and theft logic is inconsistent or missing, which prevents players from correctly picking up the flag from the ground or stealing it from opponents after winning a minigame. This change ensures a robust and consistent behavior for flag interactions.

## What Changes

- **Flag Acquisition**: Players can now pick up the flag by colliding with it. The flag will become a child of the player and move to a specific local offset.
- **Flag Theft**: When a minigame is resolved, if the loser was carrying the flag, it will be transferred to the winner with the same local offset.

## Capabilities

### New Capabilities
- `flag-acquisition`: Logic for players to pick up the flag upon collision.
- `flag-theft`: Logic for transferring the flag between players after a combat result.

### Modified Capabilities
- None.

## Impact

- **Affected Code**: `Player.cs`, `MinijocUIManager.cs`.
- **Systems**: Gameplay mechanics and UI feedback for combat results.
