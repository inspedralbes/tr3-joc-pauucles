## ADDED Requirements

### Requirement: Game session storage
The system SHALL store game session data including room ID, host, team colors, player list, and status.

#### Scenario: Successful game creation
- **WHEN** a new game is created with valid host and room ID
- **THEN** the system SHALL persist the game with default colors and 'waiting' status

### Requirement: Game retrieval by room ID
The system SHALL allow retrieving a game session using its unique room ID.

#### Scenario: Find game by room ID
- **WHEN** a retrieval request is made with an existing room ID
- **THEN** the system SHALL return the corresponding game session data

### Requirement: Game session update
The system SHALL allow updating the status, players, and other fields of an existing game session.

#### Scenario: Update game status
- **WHEN** a request is made to change the status of an existing game
- **THEN** the system SHALL update the status and persist the change
