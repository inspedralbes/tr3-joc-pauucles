## Context

The backend is being expanded to include authentication features. We already have the `User` model and repository pattern in place. To ensure proper separation of concerns, we will implement a Service layer to encapsulate business logic (like password encryption) and a Controller layer to handle HTTP interactions.

## Goals / Non-Goals

**Goals:**
- Provide a secure registration flow where passwords are hashed before storage.
- Provide a login flow that validates credentials against stored hashes.
- Expose these functionalities via HTTP endpoints.
- Maintain consistency with the existing repository pattern.

**Non-Goals:**
- Implementation of JWT or session management (this change focuses on registration and basic login logic).
- Implementation of password reset flows.

## Decisions

- **Service Layer Pattern**: We will create a `UserService` that receives a repository instance in its constructor. This allows for dependency injection and easier testing.
- **Password Encryption**: We will use `bcrypt` for hashing passwords during registration and for comparing hashes during login.
- **Controller-Service separation**: `UserController` will be responsible for extracting data from requests, calling the service, and returning appropriate HTTP responses.
- **Route Prefixing**: All user authentication routes will be prefixed with `/api/users`.

## Risks / Trade-offs

- **Risk**: Storing plain-text passwords by mistake. **Mitigation**: Ensure the service layer always hashes the password before calling the repository's `create` method.
- **Risk**: Username collisions. **Mitigation**: The service layer will check for existing usernames or handle the repository's unique constraint violation.
- **Trade-off**: Adding a Service layer increases boilerplate. **Mitigation**: This is necessary for proper architectural separation and future-proofing the auth logic.
