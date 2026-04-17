## Why

The application needs a secure and structured way to handle user registration and login. By implementing a Service layer and a Controller, we decouple the business logic (password encryption and validation) from the HTTP handling and data persistence, following best practices for a scalable backend.

## What Changes

- Create `backend/src/services/UserService.js` to handle business logic (hashing, validation).
- Create `backend/src/controllers/UserController.js` to manage HTTP requests and responses.
- Create `backend/src/routes/userRoutes.js` to define endpoints for `/register` and `/login`.
- Update `backend/src/server.js` to include the user routes under the `/api/users` prefix.

## Capabilities

### New Capabilities
- `user-auth`: Provides endpoints and logic for user registration and authentication.

### Modified Capabilities
- None.

## Impact

- **Affected Code**: `backend/src/server.js`.
- **New Files**: `backend/src/services/UserService.js`, `backend/src/controllers/UserController.js`, `backend/src/routes/userRoutes.js`.
- **Dependencies**: Requires `bcrypt` for password hashing.
