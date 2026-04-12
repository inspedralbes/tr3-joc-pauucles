## 1. Setup and Variables

- [x] 1.1 Declare public float variables `coyoteTime` (0.2f) and `jumpBufferTime` (0.2f) in `Player.cs`.
- [x] 1.2 Declare private float variables `coyoteTimeCounter` and `jumpBufferCounter` in `Player.cs`.

## 2. Coyote Time Implementation

- [x] 2.1 Add logic to `Update()` to reset `coyoteTimeCounter` to `coyoteTime` when `isGrounded` is true.
- [x] 2.2 Add logic to `Update()` to decrement `coyoteTimeCounter` by `Time.deltaTime` when not grounded.

## 3. Jump Buffering Implementation

- [x] 3.1 Add logic to `Update()` to set `jumpBufferCounter` to `jumpBufferTime` when `Input.GetButtonDown("Jump")` is detected.
- [x] 3.2 Add logic to `Update()` to decrement `jumpBufferCounter` by `Time.deltaTime` every frame.

## 4. Jump Execution and Game Feel

- [x] 4.1 Update the jump condition in `Update()` to check if `coyoteTimeCounter > 0` AND `jumpBufferCounter > 0`.
- [x] 4.2 Ensure the jump only happens if not climbing (`!escalant`).
- [x] 4.3 In the jump execution block, set vertical velocity directly to `jumpForce`.
- [x] 4.4 In the jump execution block, reset both `coyoteTimeCounter` and `jumpBufferCounter` to zero.

## 5. Variable Jump Height (Velocity Cut)

- [x] 5.1 Add logic to `Update()` to detect `Input.GetButtonUp("Jump")`.
- [x] 5.2 On release, if upward velocity (`linearVelocity.y > 0`), multiply it by `0.5f`.
- [x] 5.3 On release, set `coyoteTimeCounter` to zero to prevent unintentional jumps.

## 6. Verification

- [x] 6.1 Verify Coyote Time by jumping slightly after walking off a platform edge.
- [x] 6.2 Verify Jump Buffering by pressing jump just before landing.
- [x] 6.3 Verify Variable Jump Height by performing short and full height jumps.
- [x] 6.4 Verify that climbing logic is not negatively impacted.
