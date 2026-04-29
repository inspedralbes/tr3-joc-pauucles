## ADDED Requirements

### Requirement: Client-Side Team Auto-Balancing
The system SHALL automatically assign the local player to the team with fewer players when joining a room to maintain balance.

#### Scenario: Joining a room with uneven teams
- **WHEN** the user attempts to join a room
- **AND** Team A has fewer players than Team B
- **THEN** the system SHALL assign the local player to Team A

#### Scenario: Joining a room with even teams
- **WHEN** the user attempts to join a room
- **AND** Team A and Team B have an equal number of players
- **THEN** the system SHALL assign the local player to either team (randomly or defaulting to A)
