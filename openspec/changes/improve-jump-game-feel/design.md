## Context

The current jumping logic in `Player.cs` relies on a simple `isGrounded` check and `Input.GetButtonDown("Jump")`. This implementation is prone to "missed" jumps when the player is slightly off a platform or when they press jump slightly before landing.

## Goals / Non-Goals

**Goals:**
- Implement Coyote Time (grace period after leaving ground).
- Implement Jump Buffering (grace period for early inputs).
- Implement Variable Jump Height (cutting velocity on button release).
- Maintain compatibility with climbing and combat states.

**Non-Goals:**
- Changing the physics engine or using a different collision detection method.
- Modifying other movement parameters like `moveSpeed`.

## Decisions

### Decision 1: Timer-Based Grace Periods
**Rationale**: Using simple float timers that decrement every frame is a standard and robust way to handle these mechanics in Unity.
**Implementation**:
- `coyoteTimeCounter`: Reset to `coyoteTime` when `isGrounded` is true, otherwise decrement.
- `jumpBufferCounter`: Set to `jumpBufferTime` on `GetButtonDown("Jump")`, otherwise decrement.

### Decision 2: Jump Condition Logic
**Rationale**: By checking both counters against zero, we decouple the input timing from the grounding state, allowing for the intended "forgiveness".
**Implementation**:
- Jump occurs IF `coyoteTimeCounter > 0` AND `jumpBufferCounter > 0` AND `!escalant`.
- Velocity is set directly to `jumpForce` (e.g., `rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce)`).
- Counters are reset to zero immediately after jumping to prevent double jumps.

### Decision 3: Vertical Velocity Cut
**Rationale**: Cutting the upward velocity when the jump button is released allows for better platforming control.
**Implementation**:
- Check `Input.GetButtonUp("Jump")`.
- IF `rb.linearVelocity.y > 0`, multiply `rb.linearVelocity.y` by `0.5f`.
- Reset `coyoteTimeCounter` to zero to prevent a delayed coyote jump if the player immediately leaves the ground.

## Risks / Trade-offs

- **[Risk]** Coyote time might allow players to "jump on air" for too long if not tuned correctly.
- **[Mitigation]** Use a conservative default (0.2s) and keep it as a public variable for easy tuning in the inspector.
- **[Risk]** Jump buffering might lead to accidental jumps if the buffer is too long.
- **[Mitigation]** Use a conservative default (0.2s) and ensure it's reset after a successful jump.
