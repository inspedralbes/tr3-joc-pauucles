## ADDED Requirements

### Requirement: Hierarchical Flag Capture
The system SHALL attach the flag to the player's hierarchy upon capture to automate positional tracking.

#### Scenario: Capturing the Flag
- **WHEN** a player collides with a flag belonging to a different team
- **THEN** the system MUST set the player as the flag's parent (`transform.SetParent`)
- **AND** the system MUST set the flag's `localPosition` to `(-0.5, 0.5, 0)`

### Requirement: Removal of Manual Follow
The system SHALL NOT use manual position updates in the `Update` loop for carrying a flag once captured.

#### Scenario: Carrying the Flag
- **WHEN** the flag is captured
- **THEN** it MUST move with the player automatically via Unity's transform hierarchy without explicit code in `Update`
