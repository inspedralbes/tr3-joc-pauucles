## Why

Multiple combat instances and callback accumulation are causing inconsistent game states and bugs. Currently, multiple collisions can trigger `ShowUI` several times, and button click listeners are not being properly cleared, leading to redundant executions of combat logic and potential crashes.

## What Changes

- **State Management in MinijocUIManager**:
    - Introduced `minijocActiu` (public) to track if a minigame is currently displayed.
    - Introduced `combatResolentse` (private) to prevent multiple processing of a single combat result (e.g., double-clicking a button).
- **Collision Guard in Player**:
    - Updated `OnCollisionEnter2D` to check `minijocActiu` before initiating a new combat.
- **Initialization and Cleanup**:
    - `ShowUI` now sets `minijocActiu = true` and `combatResolentse = false`.
    - `HideUI` resets `minijocActiu = false`.
- **Event Unbinding**:
    - Added explicit unbinding (`-=`) of button click events in `HideUI` or before re-binding to prevent listener accumulation.
- **Logic Guards**:
    - All combat result handlers (`HandlePPTLLSClick`, `HandleParellsSenarsClick`, `HandleAturaBarraClick`) now check `combatResolentse` to ignore redundant inputs.

## Capabilities

### New Capabilities
- `combat-state-management`: Implementation of a state machine to control combat lifecycle (Inactive -> Active -> Resolving -> Inactive).

### Modified Capabilities
- None.

## Impact

- **Affected Code**: `MinijocUIManager.cs`, `Player.cs`.
- **Stability**: Prevents the UI from opening multiple times and ensures each combat produces exactly one result.
- **Performance**: Reduces memory overhead and unexpected behavior caused by accumulated event listeners.
