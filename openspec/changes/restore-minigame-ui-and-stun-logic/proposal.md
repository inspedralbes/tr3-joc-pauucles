## Why

The current minigame implementation suffers from broken button bindings, rendering the challenges unplayable. Additionally, winning or losing a minigame currently has no gameplay consequence. By restoring the UI links and introducing a "Stun" mechanic, we ensure that minigames are functional and that losing has a tangible penalty (temporary immobilization), while winning allows the player to continue their mission.

## What Changes

- **UI Binding Restoration**: Fix the initialization logic in `MinijocPPTLLSLogic.cs`, `MinijocMatesLogic.cs`, and other relevant logic scripts to ensure button click events are properly registered.
- **Minigame Reward/Penalty System**: Implement `GuanyarMinijoc()` and `PerdreMinijoc()` in `Player.cs` to handle the aftermath of a combat.
- **Immobilization (Stun) Mechanic**: Add a `RutinaStun` coroutine in `Player.cs` to temporarily disable movement for 3 seconds upon losing.
- **Authoritative Combat Resolution**: Update `MinijocUIManager.cs` to close the UI and trigger the appropriate win/loss state on the local player component once a minigame is resolved.

## Capabilities

### New Capabilities
- `player-status-management`: Implementation of temporary state effects (like Stun) on the player component.

### Modified Capabilities
- `multi-minigame-ui-logic`: Update the combat resolution sequence to bridge UI state with player gameplay state.

## Impact

- `Minijoc*Logic.cs`: Button event registration.
- `Player.cs`: Movement control and new state methods.
- `MinijocUIManager.cs`: Combat flow and player interaction.
