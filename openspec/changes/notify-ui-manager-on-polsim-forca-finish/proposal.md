## Why

Currently, when the "Polsim de Força" minigame ends, the UI manager is not notified of the result. This prevents the combat from being finalized correctly, which includes hiding the minigame UI and handling the flag transfer if the defender loses.

## What Changes

- **Add function call**: In `MinijocPolsimForcaLogic.cs`, inside the `FinalitzarMinijoc()` function, add `MinijocUIManager.Instance.FinalitzarCombat(guanyador);` immediately after the `Debug.Log` statement.

## Capabilities

### New Capabilities
- None

### Modified Capabilities
- None

## Impact

- **Affected Code**: `DAMT3Atrapa la bandera/Assets/Scripts/MinijocPolsimForcaLogic.cs`
- **APIs/Systems**: `MinijocUIManager` will now receive a notification when this minigame ends, triggering the end-of-combat logic.
