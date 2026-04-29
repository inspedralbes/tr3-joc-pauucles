## 1. Model Implementation

- [x] 1.1 Create `backend/src/models/Game.js` with Mongoose schema
- [x] 1.2 Configure `roomId` as unique and required
- [x] 1.3 Configure `host` as required
- [x] 1.4 Set default colors: `teamAColor: 'red'`, `teamBColor: 'blue'`
- [x] 1.5 Define `players` array with `username`, `team`, and `isReady`
- [x] 1.6 Set `status` enum: `['waiting', 'playing', 'finished']` with default `'waiting'`
- [x] 1.7 Add `winner` field with default `null`

## 2. In-Memory Repository

- [x] 2.1 Create `backend/src/repositories/inMemory/GameRepositoryInMemory.js`
- [x] 2.2 Implement `create(game)` method
- [x] 2.3 Implement `findByRoomId(roomId)` method
- [x] 2.4 Implement `update(roomId, data)` method

## 3. MongoDB Repository

- [x] 3.1 Create `backend/src/repositories/mongo/GameRepositoryMongo.js`
- [x] 3.2 Implement `create(game)` using the Mongoose model
- [x] 3.3 Implement `findByRoomId(roomId)` using the Mongoose model
- [x] 3.4 Implement `update(roomId, data)` using the Mongoose model
