## Why

Currently, the `MinijocPolsimForcaLogic` minigame ends without applying the necessary consequences to the players (such as invulnerability for the winner or freezing for the loser). Other minigames handle this via `MinijocUIManager`, but `PolsimForca` needs to explicitly call these `Player` methods to ensure consistent gameplay behavior.

## What Changes

- **Add Player references**: `MinijocPolsimForcaLogic` will now store references to the two competing players.
- **Implement victory/defeat logic**: In `FinalitzarMinijoc()`, call `WinCombat()` on the winner and `LoseCombat()` on the loser.
- **Ensure UI notification**: Confirm `MinijocUIManager.Instance.FinalitzarCombat(guanyador);` is called at the very end of the game logic.

## Capabilities

### New Capabilities
- None

### Modified Capabilities
- None

## Impact

- **Affected Code**: `MinijocPolsimForcaLogic.cs`, `MinijocUIManager.cs`
- **APIs/Systems**: `Player` objects will now receive combat results from the `PolsimForca` minigame.
