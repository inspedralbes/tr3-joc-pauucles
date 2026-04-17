## 1. Model Update

- [x] 1.1 Add `maxPlayers` field to `backend/src/models/Game.js` with default 4

## 2. Service Layer Implementation

- [x] 2.1 Create `backend/src/services/GameService.js`
- [x] 2.2 Implement `createGame(host, teamAColor, teamBColor, maxPlayers)` with unique `roomId`
- [x] 2.3 Implement `listWaitingGames()` to filter for 'waiting' status
- [x] 2.4 Implement `joinGame(roomId, username, team)` with `maxPlayers` check

## 3. Controller Layer Implementation

- [x] 3.1 Create `backend/src/controllers/GameController.js`
- [x] 3.2 Implement `create` handler for POST requests
- [x] 3.3 Implement `list` handler for GET requests
- [x] 3.4 Implement `join` handler for POST requests

## 4. Routing and Integration

- [x] 4.1 Create `backend/src/routes/gameRoutes.js`
- [x] 4.2 Define `/create`, `/list`, and `/join` endpoints
- [x] 4.3 Import and register game routes in `backend/src/server.js` under `/api/games`
