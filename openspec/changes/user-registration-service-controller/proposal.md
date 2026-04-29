## Why

The application requires a secure and structured way to register new users. This change introduces the service, controller, and routing layers necessary to handle user registration requests, ensuring password encryption and clear separation of concerns.

## What Changes

- Implement `UserService` to handle business logic for user registration, including password hashing with `bcrypt`.
- Implement `UserController` to manage HTTP requests and responses for user registration.
- Create user routes in `backend/src/routes/userRoutes.js`.
- Integrate user routes into the main `server.js` under the `/api/users` prefix.

## Capabilities

### New Capabilities
- `user-registration`: Provides the logic and endpoints for creating new user accounts securely.

### Modified Capabilities
- `backend-server`: The server initialization is modified to include the new user routes.

## Impact

- **New Files**: `backend/src/services/UserService.js`, `backend/src/controllers/UserController.js`, `backend/src/routes/userRoutes.js`.
- **Modified Files**: `backend/src/server.js`.
- **Dependencies**: Requires `bcrypt` for password hashing.
