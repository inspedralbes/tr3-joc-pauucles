## ADDED Requirements

### Requirement: Visual Lives HUD
The system SHALL display the player's current health using heart icons in a dedicated UI container located at the top-left of the screen.

#### Scenario: Lives HUD updates on damage
- **WHEN** the player takes damage and their life count decreases
- **THEN** the number of heart icons in the UI container is updated to match the current life count
