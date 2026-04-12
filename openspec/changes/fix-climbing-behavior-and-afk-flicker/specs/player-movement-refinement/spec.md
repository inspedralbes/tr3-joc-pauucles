## ADDED Requirements

### Requirement: AFK Flicker Suppression during Climbing
The system MUST suppress the AFK flicker effect when the player is in the climbing state, even if they are not providing horizontal movement input.

#### Scenario: Player climbing without horizontal input
- **WHEN** the player is climbing (escalant) and `moveInput` is 0
- **THEN** the AFK timer should not trigger the flicker effect

### Requirement: Continuous Vertical Movement via Jump Button
The system MUST allow the player to move upwards continuously on a ladder by holding the "Jump" button (Space).

#### Scenario: Holding Jump button while climbing
- **WHEN** the player is climbing (escalant) and the "Jump" button is held down
- **THEN** the vertical velocity should be set to `climbSpeed` continuously
