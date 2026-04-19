## Context

Minigame interactions are currently non-functional due to broken button bindings. Additionally, the outcome of a minigame (victory or defeat) lacks immediate gameplay consequences. This design addresses both issues by enforcing reliable UI event registration and introducing a "Stun" mechanic that penalizes the loser of a minigame session.

## Goals / Non-Goals

**Goals:**
- Ensure all minigame buttons properly trigger their respective logic.
- Implement a clear win/loss feedback loop for the local player.
- Introduce a 3-second temporary immobilization (Stun) for minigame losers.
- Cleanly bridge the UI closure with the player status update.

**Non-Goals:**
- Changing minigame internal rules (only the trigger and resolution).
- Modifying the networking protocol (handled in a separate change).

## Decisions

### 1. Robust UI Event Binding
- **Decision**: Standardize button registration in all `Minijoc*Logic.cs` scripts using the `RegisterCallback<PointerDownEvent>` or the `clicked` event from UI Toolkit.
- **Rationale**: Direct assignment ensures that even after UI resets or object re-activations, the events are correctly linked to the runtime logic.

### 2. Player Status Bridge
- **Decision**: Create `GuanyarMinijoc` and `PerdreMinijoc` as the official entry points for minigame resolution effects.
- **Implementation**:
    - `GuanyarMinijoc`: Restores full mobility.
    - `PerdreMinijoc`: Triggers a 3s `RutinaStun` coroutine.
    - `RutinaStun`: Sets `potMoure = false`, waits 3s, then sets `potMoure = true`.

### 3. Centralized Resolution in `MinijocUIManager`
- **Decision**: Update `FinalitzarCombat` to determine the local outcome and call the appropriate player method.
- **Implementation**: After UI closure, use `GameObject.FindWithTag("Player")` (filtered by `isLocalPlayer` or similar logic) to trigger the status update.

## Risks / Trade-offs

- **[Risk] Double Stun** → If multiple collisions occur.
    - *Mitigation*: The 3s cooldown in `Player.cs` (from the deterministic sync fix) already prevents rapid combat starts.
- **[Risk] UI Object discovery** → `FindWithTag` might be unreliable in complex scenes.
    - *Mitigation*: We will use `GameManager.Instance.localPlayer` if available for a direct reference.
