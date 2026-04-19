## Context

The current minigame initiation logic occurs in `Player.cs` when two players from different teams collide. While the movement restriction is intended to be local to the combatants, there's a risk of global interference or inconsistent state management. This design ensures a surgical approach where only the two participants are affected.

## Goals / Non-Goals

**Goals:**
- Surgical restriction of movement: only the two combatants are locked.
- Explicit state management in `MinijocUIManager` for the current pair of fighters.
- Seamless gameplay for other players while a specific pair is in a minigame.
- Guaranteed movement restoration only for the combatants upon minigame completion.

**Non-Goals:**
- Changing the minigame mechanics themselves.
- Modifying the networking synchronization (handled by `NetworkSync`).
- Adjusting the game-over logic which correctly freezes everyone.

## Decisions

### 1. Unified Fighter Identification in `Player.cs`
- **Decision**: Update `OnCollisionEnter2D` to explicitly identify both the local instance and the collision partner as "Fighters".
- **Rationale**: Ensures both players are acknowledged by the UI manager immediately, preventing race conditions where one might still try to move.
- **Implementation**:
    ```csharp
    this.potMoure = false;
    opponent.potMoure = false;
    MinijocUIManager.Instance.IniciarMinijoc(this, opponent);
    ```

### 2. Targeted Movement Control in `MinijocUIManager`
- **Decision**: Store references to the specific `Player` components and only toggle their `potMoure` flag.
- **Rationale**: Avoids any `FindObjects` or global loops that could accidentally catch third parties.
- **Implementation**:
    - `IniciarMinijoc` already stores `_jugador1` and `_jugador2`.
    - `FinalitzarCombat` uses these specific references to call `FinalitzarCombat()`.

### 3. Verification of "Independent Match Flow"
- **Decision**: Ensure no global "Game Paused" or "Input Locked" flag is set during minigames outside of the UI visibility itself.
- **Rationale**: The UI overlay currently covers the screen. If other players are still moving, they might be doing so "blindly" under the UI. 
- **Alternative Considered**: Making the minigame UI smaller or transparent for non-combatants. 
- **Decision**: For now, focus on the logic. If a minigame is active, only the combatants' UI should be blocking their respective views (or the match is 1v1).

## Risks / Trade-offs

- **[Risk] Multiple simultaneous minigames** → The current `MinijocUIManager.Instance.minijocActiu` check is global. If Player A and B are fighting, Player C and D cannot start a fight.
    - *Mitigation*: Since this is a small-scale prototype (likely 1v1 or 2v2), we accept this limitation. A true fix would require a non-singleton, multi-instance Minigame UI system.
- **[Risk] UI Visibility** → The UI root is currently set to `DisplayStyle.Flex` globally.
    - *Mitigation*: In a local multiplayer or "Split Screen" context, this is fine. In a networked context, only the combatants should trigger the UI activation.
