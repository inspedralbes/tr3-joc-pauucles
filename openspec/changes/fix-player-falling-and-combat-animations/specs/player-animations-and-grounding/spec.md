## ADDED Requirements

### Requirement: Grounding Safety Check
The system SHALL ensure the player is not marked as grounded if their vertical velocity exceeds a threshold (0.1f) and they are not currently climbing.

#### Scenario: Player falling at high speed
- **WHEN** the player's vertical velocity absolute value is greater than 0.1f and `isClimbing` is false
- **THEN** `isGrounded` MUST be set to false

### Requirement: Collision Exit Grounding Reset
The system SHALL explicitly set the player's grounding state to false when they exit a collision with another object.

#### Scenario: Player leaves a platform
- **WHEN** `OnCollisionExit2D` is triggered
- **THEN** `isGrounded` MUST be set to false

### Requirement: Hurt Animation Trigger
The system SHALL trigger a "hurt" animation when the player loses a combat encounter.

#### Scenario: Combat lost
- **WHEN** the `LoseCombat()` method is called and lives are decremented
- **THEN** the "hurt" trigger MUST be set in the Animator

### Requirement: Death and Respawn Animation State
The system SHALL manage a persistent "isDead" animation state during the entire duration of the player's respawn process.

#### Scenario: Player respawning
- **WHEN** the respawn process starts
- **THEN** the "isDead" boolean MUST be set to true in the Animator
- **WHEN** the respawn process completes
- **THEN** the "isDead" boolean MUST be set to false in the Animator
