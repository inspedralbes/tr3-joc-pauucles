## Context

The `Player.cs` script currently manages jump and climb logic with some overlap, using the generic Unity Input Manager ("Jump" button). This causes ambiguity when the player is near or on ladders. The user wants to explicitly separate these actions using specific key codes and refined state checks.

## Goals / Non-Goals

**Goals:**
- Explicitly use `KeyCode.Space` for jumping.
- Explicitly use Vertical Axis (W/S/Arrows) for climbing activation and movement.
- Implement "Jump from Ladder" functionality.
- Ensure gravity is correctly handled during and after climbing.
- Maintain existing Animator and Trigger logic.

**Non-Goals:**
- Refactoring the entire Input System to a new package (like Input System Package).
- Changing horizontal movement or combat logic.
- Removing or changing the AFK flickering logic unless it conflicts.

## Decisions

- **Direct Key Input**: We will transition from `Input.GetButton("Jump")` to `Input.GetKeyDown(KeyCode.Space)` to fulfill the request for precise control separation.
- **Climbing Physics in FixedUpdate**: Vertical movement while climbing will be handled in `FixedUpdate` using `rb.linearVelocity` and `rb.gravityScale = 0f`, ensuring physical consistency.
- **State Priority**: Climbing will take precedence over normal gravity, and jumping from a ladder will immediately cancel the climbing state.
- **Snippet Integration**: The specific code snippets provided by the user will be the foundation of the logic, replacing the current coyote time / jump buffer implementation for simplicity and direct control as requested.

## Risks / Trade-offs

- **[Risk] Loss of Input Buffering** → The user's requested snippet `Input.GetKeyDown(KeyCode.Space)` doesn't use the existing `jumpBufferTime`. 
  - *Mitigation*: We will follow the user's specific snippet as requested. If responsiveness feels worse, we can propose re-integrating the buffer in a future change.
- **[Risk] Key Hardcoding** → Hardcoding `KeyCode.Space` makes the game less configurable via Unity's Input Manager.
  - *Mitigation*: This is a direct request from the user for this specific implementation.
