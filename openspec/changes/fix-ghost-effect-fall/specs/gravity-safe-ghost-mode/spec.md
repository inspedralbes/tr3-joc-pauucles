## ADDED Requirements

### Requirement: Save and Restore Gravity Scale
The system SHALL store the current `gravityScale` of the player's `Rigidbody2D` before entering ghost mode and restore it exactly when the mode ends.

#### Scenario: Gravity preservation during ghost mode
- **WHEN** a player enters the defeat penalty state
- **THEN** the system SHALL save the current `rb.gravityScale` into a private variable
- **THEN** the system SHALL set `rb.gravityScale` to 0
- **THEN** when the penalty ends and `isTrigger` is set to `false`, the system SHALL restore `rb.gravityScale` to its original value

### Requirement: Motion Cancellation on Defeat
The system SHALL immediately stop all linear motion of the player when the defeat penalty is applied to prevent drifting while in ghost mode.

#### Scenario: Immediate freeze on defeat
- **WHEN** `AplicarCastigDerrota()` is called
- **THEN** the system SHALL set `rb.velocity` to `Vector2.zero`
- **THEN** the player SHALL remain hovering at their current position until the penalty expires
