## 1. Service Layer Implementation

- [x] 1.1 Create `backend/src/services/UserService.js`
- [x] 1.2 Implement `register(username, password)` in `UserService` with `bcrypt` hashing
- [x] 1.3 Implement `login(username, password)` in `UserService` with `bcrypt.compare`

## 2. Controller Layer Implementation

- [x] 2.1 Create `backend/src/controllers/UserController.js`
- [x] 2.2 Implement `register` handler in `UserController`
- [x] 2.3 Implement `login` handler in `UserController`

## 3. Routes and Integration

- [x] 3.1 Create `backend/src/routes/userRoutes.js`
- [x] 3.2 Define POST `/register` and POST `/login` routes
- [x] 3.3 Import and use `userRoutes` in `backend/src/server.js` under `/api/users`
