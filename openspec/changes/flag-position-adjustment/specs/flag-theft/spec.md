## MODIFIED Requirements

### Requirement: Flag Transfer on Combat Victory
The system SHALL ensure a reliable transfer of the flag from the loser to the winner by using global object detection and precise lateral positioning.

#### Scenario: Winner steals flag reliably
- **WHEN** a combat confrontation is resolved
- **THEN** the system SHALL search for the flag object using the "Bandera" tag
- **AND** if found, it SHALL detach it from any previous owner and attach it to the winner
- **THEN** the flag's `localPosition` SHALL be set to `(-0.8, 0, 0)` relative to the winner
- **THEN** the loser's internal flag reference SHALL be cleared
