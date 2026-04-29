## ADDED Requirements

### Requirement: Horizontal Movement and Orientation
The system SHALL allow the player to move horizontally using raw input and reflect their direction visually.

#### Scenario: Moving Left
- **WHEN** user presses the left movement key (Input.GetAxisRaw("Horizontal") < 0)
- **THEN** the player moves left and the Transform's localScale.x is set to a negative value (flipped)

#### Scenario: Moving Right
- **WHEN** user presses the right movement key (Input.GetAxisRaw("Horizontal") > 0)
- **THEN** the player moves right and the Transform's localScale.x is set to a positive value (not flipped)

### Requirement: Jumping Constraints
The system SHALL allow the player to jump only when grounded and not climbing.

#### Scenario: Successful Jump
- **WHEN** user presses the "Jump" button AND the player is not climbing AND the vertical velocity is near zero
- **THEN** a vertical force (jumpForce) is applied to the Rigidbody2D

### Requirement: Stair Interaction
The system SHALL detect when the player is in contact with a ladder/stair zone.

#### Scenario: Entering Stair Zone
- **WHEN** the player's trigger collider enters a collider with the Tag "ZonaEscalera"
- **THEN** the internal state `tocantEscala` becomes true

#### Scenario: Exiting Stair Zone
- **WHEN** the player's trigger collider exits a collider with the Tag "ZonaEscalera"
- **THEN** the internal state `tocantEscala` becomes false AND `escalant` becomes false

### Requirement: Climbing Mechanics
The system SHALL allow the player to climb stairs by neutralizing gravity and applying vertical velocity.

#### Scenario: Initiating Climb
- **WHEN** the player is `tocantEscala` AND the user provides vertical input (Input.GetAxisRaw("Vertical") != 0)
- **THEN** the player enters the `escalant` state

#### Scenario: Active Climbing
- **WHEN** the player is in the `escalant` state
- **THEN** the Rigidbody2D's gravityScale is set to 0 AND vertical velocity is applied based on vertical input and `climbSpeed`
