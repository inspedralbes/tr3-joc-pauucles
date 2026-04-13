## ADDED Requirements

### Requirement: Game Model Definition
The system SHALL define a Game model to track session state, players, and match outcomes.

#### Scenario: Game session structure
- **WHEN** a game object is initialized
- **THEN** it SHALL contain:
  - `roomId`: String (Unique, Required)
  - `host`: String (Required)
  - `teamAColor`: String (Default: 'red')
  - `teamBColor`: String (Default: 'blue')
  - `players`: Array of Objects ({username: String, team: String, isReady: Boolean})
  - `status`: String (Enum: ['waiting', 'playing', 'finished'], Default: 'waiting')
  - `winner`: String (Default: null)

### Requirement: Persist Game Session
The Game repository SHALL provide a method to create and persist a new game session.

#### Scenario: Create a game room
- **WHEN** the `create(gameData)` method is called with valid session data
- **THEN** the system SHALL store the game session and return the created object.

### Requirement: Retrieve Game by Room ID
The Game repository SHALL provide a method to retrieve a game session by its unique Room ID.

#### Scenario: Find an active room
- **WHEN** `findByRoomId(roomId)` is called with an existing Room ID
- **THEN** the system SHALL return the corresponding game session object.

### Requirement: Update Game Session
The Game repository SHALL provide a method to update the state of an existing game session.

#### Scenario: Update room status or players
- **WHEN** `update(roomId, data)` is called with updated session information
- **THEN** the system SHALL apply the changes to the session identified by the Room ID and return the updated object.
