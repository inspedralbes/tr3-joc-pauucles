## Why

The application needs a structured way to manage game rooms, allowing users to create, list, and join matches. This change provides the backend infrastructure to handle room lifecycles and player assignments securely and efficiently.

## What Changes

- **Model Update**: Added `maxPlayers` field to the `Game` model.
- **Game Service**: Implemented `GameService` to handle room creation (unique `roomId`, 'waiting' status), listing of available rooms, and player join logic (including capacity checks).
- **Game Controller**: Implemented `GameController` to expose room management through HTTP endpoints.
- **API Routing**: Defined `/api/games` routes for `/create`, `/list`, and `/join`.
- **Integration**: Registered game routes in the main Express server.

## Capabilities

### New Capabilities
- `game-room-management`: Enables users to create new game rooms, browse active rooms, and join specific teams within a room.

### Modified Capabilities
- `game-persistence`: Extended to support room capacity constraints.

## Impact

- **Affected Files**: `backend/src/models/Game.js`, `backend/src/server.js`.
- **New Files**: `backend/src/services/GameService.js`, `backend/src/controllers/GameController.js`, `backend/src/routes/gameRoutes.js`.
- **Architecture**: Enhances the service-oriented architecture for game session management.
