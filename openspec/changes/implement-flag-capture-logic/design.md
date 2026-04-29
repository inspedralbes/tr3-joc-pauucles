## Context

The "Capture the Flag" objective is currently impossible because the flags do not respond to player interaction. This design provides a simple yet effective way to handle flag capture and carrying using Unity's trigger system and relative positioning.

## Goals / Non-Goals

**Goals:**
- Implement trigger-based capture logic for flags.
- Ensure flags only react to players from the opposing team.
- Provide a smooth "carrying" visual effect by making the flag follow the player.

**Non-Goals:**
- Implementing flag return logic (returning to base).
- Advanced carrying animations (static offset is sufficient for now).

## Decisions

### 1. Team Identification Strategy
Since `Player.cs` uses `idJugador` (1 or 2) and `Bandera.cs` expects `equipPropietari` (likely "A" or "B"), we will perform a simple mapping inside `OnTriggerEnter2D`:
- Player `idJugador == 1` maps to Team "A".
- Player `idJugador == 2` maps to Team "B".
- **Rationale**: This matches the instantiation logic seen in `GameManager.cs`.

### 2. Follow Mechanism
We will use a direct position update in the `Update` loop with a fixed offset.
- **Offset**: `new Vector3(-1f, 0.5f, 0f)` (behind and slightly above the player).
- **Rationale**: A direct update is simpler than a physics-based joint for a 2D platformer and prevents the flag from getting stuck in terrain while being carried.

### 3. Capture State Persistence
The `esCapturada` flag will prevent multiple players from "capturing" the same flag simultaneously and will be used to gate the following logic.

## Risks / Trade-offs

- **[Risk]** Team strings might not match perfectly if changed in the future.
- **[Mitigation]** We will use the same string mapping used in `GameManager.InstanciarBanderes`.
- **[Risk]** The flag might clip through walls if the player is very close to an edge.
- **[Mitigation]** The offset is small, and since it's purely visual (following a player), it won't break gameplay physics.
