## MODIFIED Requirements

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
  - `maxPlayers`: Number (Default: 4)
