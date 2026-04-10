## ADDED Requirements

### Requirement: Directional Flag Offset
The system SHALL update the horizontal offset of the flag based on the player's movement direction to create a "trailing" effect.

#### Scenario: Moving Right
- **WHEN** the player carries the flag
- **AND** the player's horizontal input is positive (moving right)
- **THEN** the system SHALL set the flag's `localPosition` to `(-0.8, 0, 0)`

#### Scenario: Moving Left
- **WHEN** the player carries the flag
- **AND** the player's horizontal input is negative (moving left)
- **THEN** the system SHALL set the flag's `localPosition` to `(0.8, 0, 0)`
