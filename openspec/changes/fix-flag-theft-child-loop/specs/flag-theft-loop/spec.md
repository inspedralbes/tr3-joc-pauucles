## ADDED Requirements

### Requirement: Flag Detection within Loser's Hierarchy
The system MUST iterate through all child transforms of the loser player to locate the flag object.

#### Scenario: Successful flag detection
- **WHEN** a combat is resolved and a winner is declared
- **AND** the loser player's transform contains a child object with the "Bandera" tag
- **THEN** the system SHALL identify this child as the flag to be transferred

### Requirement: Reliable Flag Reparenting
The system MUST detach the flag from the loser player and attach it to the winner player.

#### Scenario: Successful reparenting
- **WHEN** the flag is detected within the loser player's hierarchy
- **THEN** the system SHALL set the flag's parent to the winner player's transform

### Requirement: Precise Flag Placement
The system MUST reset the flag's local transform properties immediately after reparenting.

#### Scenario: Reset local transform
- **WHEN** the flag is reparented to the winner player
- **THEN** the system SHALL set its `localPosition` to `(-0.8, 0, 0)`
- **AND** the system SHALL set its `localScale` to `(1, 1, 1)`

### Requirement: Completion Traceability
The system MUST log a confirmation message when a flag theft occurs.

#### Scenario: Log theft confirmation
- **WHEN** the flag is successfully stolen and positioned on the winner player
- **THEN** the system SHALL display a `Debug.Log` message indicating the theft has been completed
