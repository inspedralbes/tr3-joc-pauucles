## Why

In the standalone build, the `MinijocUIManager` might be inactive or not yet instantiated in a way that `FindObjectOfType` can detect, causing the combat initiation logic to fail. This change ensures that the manager is always found (even if inactive) and that its UI state is properly reset and activated during combat.

## What Changes

- **Aggressive Manager Discovery**: Update `Player.cs` to use `Resources.FindObjectsOfTypeAll<MinijocUIManager>()` to locate the manager even if its GameObject is disabled.
- **Forced UI Activation**: Ensure the discovered manager's GameObject is explicitly set to active.
- **Refactored IniciarMinijoc**: Update the method signature to receive the two fighting GameObjects and handle their movement restriction internally.
- **Selective Container Visibility**: Implement a "Hide All, Show One" pattern for minigame containers (`#ContenidorPPTLLS`, etc.) within `MinijocUIManager`.
- **System Feedback**: Add diagnostic logs to track successful manager recovery and combat locking.

## Capabilities

### New Capabilities
- `robust-ui-recovery`: Ability to find and activate critical UI components regardless of their active state.

### Modified Capabilities
- `multi-minigame-ui-logic`: Update the UI initialization sequence to handle dual player references and container reset.

## Impact

- `Player.cs`: Combat collision handler logic.
- `MinijocUIManager.cs`: Initialization flow and container management.
- General Stability: Prevents "soft-locks" during combat initiation in builds.
