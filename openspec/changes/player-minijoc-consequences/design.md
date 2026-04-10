## Context

`Player.cs` currently handles basic 2D movement and flag collection. The new requirements demand a way to handle temporary effects (freeze, invulnerability) triggered by minigame results. Unity Coroutines are ideal for this as they allow for non-blocking timers.

## Goals / Non-Goals

**Goals:**
- Manage player lives (3 lives) and update a Text UI.
- Implement `isFrozen` and `isInvulnerable` states.
- Ensure movement and jumping are disabled when `isFrozen` is true.
- Use `IEnumerator` coroutines for the 7s (loss), 5s (win), and 45s (respawn) delays.

**Non-Goals:**
- Overhauling the collision system.
- Designing complex UI (only a Text component for lives).

## Decisions

- **Coroutines over Timers**: `StartCoroutine` will be used for state management. This is the idiomatic Unity way to handle time-based state changes without polluting the `Update` method with multiple manual timers.
- **State Check in `Update`**: The movement logic in `Update` will be wrapped in a conditional check for `!isFrozen`.
- **Visual Feedback**: Temporary color changes will be applied using `SpriteRenderer.color`. `Color.blue` for frozen and `Color.yellow` for invulnerability.
- **Flag Detachment**: When losing, `banderaAgafada.SetParent(null)` will be called to drop the flag.

## Risks / Trade-offs

- [Risk: Multiple Coroutines] -> Mitigation: Ensure existing coroutines are stopped before starting new ones for the same effect (e.g., if a player gets frozen twice).
- [Risk: Respawn and UI Sync] -> Mitigation: Update the lives count and UI text immediately when a loss occurs.
