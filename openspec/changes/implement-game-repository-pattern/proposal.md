## Why

The system needs a structured way to manage game sessions (rooms), player lists, and game status. Implementing the Repository pattern for Games ensures that the logic for tracking active matches and their states is decoupled from the storage mechanism, allowing for flexible persistence.

## What Changes

- Create the `Game` model using Mongoose.
- Implement `GameRepositoryInMemory` for fast, non-persistent game session management.
- Implement `GameRepositoryMongo` for persistent storage of game history and active rooms.
- Define a consistent interface for managing games: `create`, `findByRoomId`, and `update`.

## Capabilities

### New Capabilities
- `game-management`: Provides the core data structures and methods to manage game sessions, players, teams, and match status.

### Modified Capabilities
- None.

## Impact

- **New Files**: `backend/src/models/Game.js`, `backend/src/repositories/inMemory/GameRepositoryInMemory.js`, `backend/src/repositories/mongo/GameRepositoryMongo.js`.
- **Architecture**: Expands the Repository pattern to cover game logic and session management.
- **Dependencies**: Uses `mongoose` for the MongoDB implementation.
