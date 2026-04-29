## 1. User Model Update

- [x] 1.1 Add `gamesPlayed` (Number, default: 0) to `backend/src/models/User.js`
- [x] 1.2 Add `wins` (Number, default: 0) to `backend/src/models/User.js`
- [x] 1.3 Add `losses` (Number, default: 0) to `backend/src/models/User.js`

## 2. Game Model & Repositories

- [x] 2.1 Ensure `backend/src/models/Game.js` includes `roomId`, `host`, `teamAColor`, `teamBColor`, `players`, `status`, and `winner`
- [x] 2.2 Verify/Complete `GameRepositoryInMemory` in `backend/src/repositories/inMemory/GameRepositoryInMemory.js`
- [x] 2.3 Verify/Complete `GameRepositoryMongo` in `backend/src/repositories/mongo/GameRepositoryMongo.js`

## 3. Result Model Implementation

- [x] 3.1 Create `backend/src/models/Result.js` with `gameId`, `duration`, `winningTeam`, and `finalScores`
- [x] 3.2 Implement `ResultRepositoryInMemory` in `backend/src/repositories/inMemory/ResultRepositoryInMemory.js` with `create` and `findByGameId`
- [x] 3.3 Implement `ResultRepositoryMongo` in `backend/src/repositories/mongo/ResultRepositoryMongo.js` with `create` and `findByGameId`
