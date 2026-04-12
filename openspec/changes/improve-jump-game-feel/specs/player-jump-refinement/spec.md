## ADDED Requirements

### Requirement: Coyote Time
The system MUST allow the player to initiate a jump for a short duration (`coyoteTime`) after leaving the ground without jumping.

#### Scenario: Jumping shortly after falling off a platform
- **WHEN** the player falls off a ledge and presses the jump button within the `coyoteTime` duration
- **THEN** the character should perform a jump as if they were still on the ground

### Requirement: Jump Buffering
The system MUST store a jump input for a short duration (`jumpBufferTime`) and execute it immediately when the player touches the ground.

#### Scenario: Pressing jump just before landing
- **WHEN** the player is in the air and presses the jump button within the `jumpBufferTime` before hitting the ground
- **THEN** the character should jump immediately upon landing

### Requirement: Variable Jump Height
The system SHOULD allow the player to control the height of their jump by releasing the jump button.

#### Scenario: Releasing jump button early
- **WHEN** the player releases the jump button while ascending
- **THEN** the vertical velocity should be reduced to half, ending the jump early
