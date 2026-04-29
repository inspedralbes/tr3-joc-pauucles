## ADDED Requirements

### Requirement: Game Room Creation
The system SHALL allow users to create new game rooms with specific host and team color configurations.

#### Scenario: Successful room creation
- **WHEN** a valid creation request is received with host, team colors, and max players
- **THEN** the system SHALL generate a unique room ID
- **AND** the system SHALL persist the room in 'waiting' status

### Requirement: Available Room Listing
The system SHALL provide a list of game rooms that are currently in the 'waiting' status.

#### Scenario: Listing waiting games
- **WHEN** a list request is received
- **THEN** the system SHALL return all games where status is 'waiting'

### Requirement: Joining a Game Room
The system SHALL allow users to join an existing game room if it hasn't reached its maximum capacity.

#### Scenario: Successfully joining a room
- **WHEN** a join request is received for a room with available slots
- **THEN** the system SHALL add the player to the room's player list
- **AND** the system SHALL return the updated room data

#### Scenario: Joining a full room
- **WHEN** a join request is received for a room that has reached `maxPlayers`
- **THEN** the system SHALL reject the request with an error message
