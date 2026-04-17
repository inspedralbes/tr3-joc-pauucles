## ADDED Requirements

### Requirement: Jump Control Restriction
The system SHALL only allow the player to jump when the **Space** key is pressed AND the player is **grounded** AND the player is **NOT climbing**.

#### Scenario: Normal Jump from ground
- **WHEN** the user presses the Space key while the player is on the ground and not near a ladder.
- **THEN** the player executes a jump and is no longer grounded.

#### Scenario: Jump blocked while climbing
- **WHEN** the user presses the Space key while the player is currently in the climbing state.
- **THEN** the climbing state is cancelled, and a jump is executed (Jump from ladder).

### Requirement: Climbing Activation
The system SHALL activate the climbing state ONLY when the player is **near a ladder** AND providing **vertical input** (W, S, Up Arrow, or Down Arrow).

#### Scenario: Start climbing
- **WHEN** the player is within the trigger zone of a ladder and the user presses 'W' or 'Up Arrow'.
- **THEN** the player enters the climbing state and gravity is disabled.

### Requirement: Climbing Physics and Movement
The system SHALL disable gravity for the player while in the climbing state and set the vertical velocity proportional to the vertical input.

#### Scenario: Climbing movement
- **WHEN** the player is climbing and the user holds 'W'.
- **THEN** the player moves upwards with a constant `climbSpeed`.

### Requirement: Jumping from Ladder
The system SHALL allow the player to jump while climbing by pressing the **Space** key, which MUST cancel the climbing state.

#### Scenario: Jump from ladder
- **WHEN** the player is climbing and the user presses the Space key.
- **THEN** the player's `isClimbing` state is set to false, and the player performs a jump.

### Requirement: Gravity Restoration
The system SHALL restore the player's default gravity scale whenever the player exits the climbing state.

#### Scenario: Exit ladder trigger
- **WHEN** the player exits the ladder trigger zone.
- **THEN** `isClimbing` is set to false and `gravityScale` returns to its original value.
