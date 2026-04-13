## 1. Setup and Directory Structure

- [x] 1.1 Create the directory for models: `backend/src/models`.
- [x] 1.2 Create the directory for repositories: `backend/src/repositories`.
- [x] 1.3 Create subdirectories for in-memory and mongo repositories: `backend/src/repositories/inMemory` and `backend/src/repositories/mongo`.

## 2. Model Implementation

- [x] 2.1 Implement the Mongoose user schema in `backend/src/models/User.js`.
- [x] 2.2 Define `username` (String, unique, required), `password` (String, required), `coins` (Number, default 0), and `skins` (Array, default ['base']).

## 3. Repository Implementation

- [x] 3.1 Create `backend/src/repositories/inMemory/UserRepositoryInMemory.js`.
- [x] 3.2 Implement `create(user)` and `findByUsername(username)` in the in-memory repository.
- [x] 3.3 Create `backend/src/repositories/mongo/UserRepositoryMongo.js`.
- [x] 3.4 Implement `create(user)` and `findByUsername(username)` in the MongoDB repository using the User model.

## 4. Verification

- [x] 4.1 Verify that the in-memory repository stores users in a local array and can retrieve them.
- [x] 4.2 Verify that the MongoDB repository correctly interacts with the database (connection status must be checked first).
