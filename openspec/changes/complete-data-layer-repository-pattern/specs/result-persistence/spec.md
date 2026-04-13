## ADDED Requirements

### Requirement: Match outcome recording
The system SHALL record the outcome of a completed match, including game ID, duration, winning team, and final scores.

#### Scenario: Successful result storage
- **WHEN** a match is finished and valid outcome data is provided
- **THEN** the system SHALL persist the match result

### Requirement: Result retrieval by game ID
The system SHALL allow retrieving match results using the associated game ID.

#### Scenario: Find result by game ID
- **WHEN** a retrieval request is made with an existing game ID
- **THEN** the system SHALL return the match outcome data
