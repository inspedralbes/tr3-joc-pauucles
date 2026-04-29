## Context

The `Player.cs` script handles both movement and visual feedback states like AFK flickering. Currently, these systems overlap in ways that create visual glitches (flickering while climbing) and non-intuitive movement (lack of continuous climbing with the Jump button).

## Goals / Non-Goals

**Goals:**
- Prevent the AFK flicker from triggering while the player is climbing.
- Enable continuous upward movement on ladders when the "Jump" button (Space) is held.
- Simplify the climbing velocity logic in `FixedUpdate`.

**Non-Goals:**
- Changing the overall movement speed or jump force.
- Modifying the combat or UI systems.
- Adding new player states.

## Decisions

### Decision 1: AFK Logic Conditional Guard
**Rationale**: The AFK state should only be considered when the player is truly "idle". Climbing, even without horizontal input, is an active state.
**Implementation**: Update the `Update()` loop's AFK check to include `&& !escalant`.

### Decision 2: Simplified Climbing Input in FixedUpdate
**Rationale**: Using `Input.GetButton("Jump")` instead of `Input.GetButtonDown` (implied by previous behavior or just cleaner logic) allows for continuous polling of the button state during `FixedUpdate`. Using a single `vInput` variable makes the code more readable and easier to maintain.
**Implementation**: 
- Read `Vertical` axis raw.
- Override with `1f` if `Jump` is pressed.
- Apply directly to `linearVelocity.y` using `climbSpeed`.

## Risks / Trade-offs

- **[Risk]** Overriding `Vertical` axis with `Jump` might prevent moving downwards if both are pressed.
- **[Mitigation]** This is standard platformer behavior where "Jump" often defaults to "Up" in climbing contexts.
