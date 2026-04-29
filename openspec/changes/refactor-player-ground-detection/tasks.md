## 1. Cleanup Old Logic

- [x] 1.1 Remove grounding safety check from `Update()` based on `linearVelocity.y`.
- [x] 1.2 Remove `isGrounded = true` from `OnCollisionEnter2D()`.
- [x] 1.3 Remove `isGrounded = false` from `OnCollisionExit2D()`.

## 2. Implement BoxCast Grounding

- [x] 2.1 Add `CheckGrounded()` private method to `Player.cs` using `Physics2D.BoxCast`.
- [x] 2.2 Call `CheckGrounded()` at the beginning of `Update()` to set `isGrounded`.

## 3. Verification

- [x] 3.1 Verify consistent jumping behavior on flat surfaces.
- [x] 3.2 Verify jump ability on ramps/slopes.
- [x] 3.3 Ensure jumping is NOT possible when airborne (e.g., falling).
- [x] 3.4 Confirm no regressions in trigger-based interactions (e.g., ladders, base, flags).
