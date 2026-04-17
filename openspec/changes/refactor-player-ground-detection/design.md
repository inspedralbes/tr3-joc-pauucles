## Context

The current grounding logic relies on `OnCollisionEnter2D` and `OnCollisionExit2D`, supplemented by manual velocity checks. This is prone to edge-case failures, such as when sliding down slopes or during multi-collider interactions.

## Goals / Non-Goals

**Goals:**
- Implement a centralized `CheckGrounded()` method using `Physics2D.BoxCast`.
- Remove all distributed grounding logic (collision handlers, velocity checks).
- Improve jump reliability on non-flat surfaces.

**Non-Goals:**
- Changing the physics material or friction of the player.
- Implementing a full state machine for movement (though this lays the groundwork).

## Decisions

- **Physics2D.BoxCast**: Chosen over `Raycast` because it covers the full width of the player's base, preventing grounding loss when standing on an edge.
- **Continuous Update**: Grounding is checked at the start of `Update()` rather than `FixedUpdate()` to ensure that input handling (Jump) uses the most up-to-date physics state relative to the frame being rendered.
- **Trigger Filtering**: Explicitly filter out triggers to avoid being "grounded" on invisible detection zones.

## Risks / Trade-offs

- **[Risk]** `BoxCast` performance overhead. **[Mitigation]** Negligible for a single player character; Physics2D queries are highly optimized.
- **[Risk]** Casting too far (0.1f) might cause "hovering" grounding. **[Mitigation]** This value is standard for 2D platformers to account for minor floating point inaccuracies in physics simulation.
