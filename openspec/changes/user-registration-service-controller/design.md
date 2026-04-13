## Context

The backend is organized with a repository pattern. We now need to implement the service and controller layers for user management, starting with registration.

## Goals / Non-Goals

**Goals:**
- Implement a `UserService` that encapsulates business logic.
- Implement a `UserController` that handles HTTP interactions.
- Ensure passwords are encrypted before storage.
- Register routes in the Express application.

**Non-Goals:**
- Implementing user login (this will be handled in a separate change).
- Adding complex validation beyond basic existence checks.

## Decisions

- **Password Hashing**: Use **bcrypt** to securely hash passwords. It's an industry standard for password protection.
- **Service Dependency**: The `UserService` will receive the repository as a constructor dependency. This allows for easier testing (dependency injection).
- **Controller Dependency**: The `UserController` will receive the `UserService` as a constructor dependency.
- **Response Format**: The controller will return the created user object but MUST remove the `password` field before sending the response.

## Risks / Trade-offs

- [Risk] Brute force or rainbow table attacks on passwords. → **Mitigation**: Use `bcrypt` with a strong salt factor (e.g., 10).
- [Risk] Duplicate usernames if concurrent registration requests occur. → **Mitigation**: Rely on the MongoDB unique index on the `username` field as a final guardrail.
