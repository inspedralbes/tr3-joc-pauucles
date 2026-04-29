## 1. Project Setup

- [x] 1.1 Install `bcrypt` dependency: `npm install bcrypt`.
- [x] 1.2 Create the directory structure for services, controllers, and routes: `backend/src/services`, `backend/src/controllers`, `backend/src/routes`.

## 2. Service Implementation

- [x] 2.1 Implement `backend/src/services/UserService.js` with the `register` method.
- [x] 2.2 Add password hashing logic using `bcrypt.hash()`.
- [x] 2.3 Implement the check for existing usernames via the repository.

## 3. Controller and Routing Implementation

- [x] 3.1 Implement `backend/src/controllers/UserController.js` with the `register` handler.
- [x] 3.2 Implement the removal of the password field in the response.
- [x] 3.3 Implement `backend/src/routes/userRoutes.js` and define the POST `/register` route.

## 4. Server Integration

- [x] 4.1 Import user routes into `backend/src/server.js`.
- [x] 4.2 Add `app.use('/api/users', userRoutes)` middleware to the Express application.

## 5. Verification

- [x] 5.1 Test user registration with a POST request to `/api/users/register` and verify the response status (201) and body (no password).
- [x] 5.2 Test registration with an existing username and verify the error response.
