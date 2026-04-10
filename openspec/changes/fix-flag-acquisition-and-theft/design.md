## Context

The project is a "Capture the Flag" style game in Unity. Currently, players cannot reliably interact with the flag object. The interaction must happen during normal gameplay (picking it up from the ground) and after combat (stealing it from a defeated opponent).

## Goals / Non-Goals

**Goals:**
- Implement a reliable flag pickup mechanic.
- Implement a flag theft mechanic triggered by minigame results.
- Ensure consistent visual positioning of the flag when carried by any player.

**Non-Goals:**
- Implement animations for picking up or stealing.
- Change the core combat resolution logic (minigames).

## Decisions

- **Collision-Based Pickup**: Use `OnCollisionEnter2D` in `Player.cs` to detect objects tagged "Bandera".
- **Reparenting for Carrying**: The flag will become a child of the carrying player's transform. This ensures it follows the player automatically.
- **Fixed Offset**: A fixed local position of `(-0.8f, 0, 0)` will be used to place the flag consistently on one side of the player.
- **Post-Minigame Theft**: Flag theft will be handled in `MinijocUIManager.cs` during the `ProcessarResultatCombat` flow, ensuring it only happens when a winner and loser are clearly defined.

## Risks / Trade-offs

- **[Risk] Multiple Banderas**: If there are multiple objects tagged "Bandera", the logic might be ambiguous. -> **Mitigation**: Ensure only one active flag exists or is interactable at a time.
- **[Risk] Visual Clipping**: The fixed offset might cause clipping with walls or other objects. -> **Mitigation**: Offset is small enough that it should generally be safe within the expected player collider.
