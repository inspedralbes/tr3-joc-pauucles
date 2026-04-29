## MODIFIED Requirements

### Requirement: Flag Transfer Validation on Combat
The system SHALL verify that the loser actually carries the flag before attempting a theft, ensuring data integrity.

#### Scenario: Verify carrier before theft
- **WHEN** a combat confrontation is resolved and a winner is declared
- **AND** the flag is detected in the scene
- **THEN** the system SHALL use `IsChildOf(loser.transform)` to check if the loser is the current parent of the flag
- **AND** only if it returns true, the theft SHALL proceed

### Requirement: Precise Flag Positioning on Transfer
When a flag is transferred (stolen or picked up), it MUST be correctly positioned relative to the carrier.

#### Scenario: Stolen flag visual alignment
- **WHEN** the flag is successfully stolen from a loser
- **THEN** it SHALL be reparented to the winner using `SetParent(winner.transform)`
- **AND** its `localPosition` SHALL be set to `(-0.8, 0, 0)`
- **AND** its `localScale` SHALL be set to `(1, 1, 1)`
- **AND** a success message SHALL be logged in the console

### Requirement: Normal Flag Acquisition
When a player picks up the flag from the ground, the hierarchy MUST be correctly established.

#### Scenario: Normal pickup hierarchy
- **WHEN** a player triggers a collision with the flag on the ground (no carrier)
- **THEN** the flag MUST be made a child of the player using `SetParent(this.transform)`
