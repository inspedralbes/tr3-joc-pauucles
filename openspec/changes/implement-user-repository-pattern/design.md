## Context

The project is setting up a backend with Express and MongoDB. To ensure maintainability and testability, we are introducing the Repository pattern for user data management.

## Goals / Non-Goals

**Goals:**
- Define a Mongoose schema for the `User` model.
- Implement an in-memory repository for unit testing and fast development.
- Implement a MongoDB-backed repository for production persistence.
- Ensure consistent method signatures between both repository implementations.

**Non-Goals:**
- Implementing actual API endpoints or authentication logic.
- Adding complex search or filtering to the repositories.

## Decisions

- **Data Modeling**: Use **Mongoose** for the schema definition to leverage its built-in validation (unique usernames, required fields) and default values.
- **In-Memory Repository**: Use a simple JavaScript array to store user objects. This repository won't persist data between server restarts but is ideal for tests.
- **MongoDB Repository**: Use the Mongoose `User` model directly to interact with the database.
- **Pattern**: Implement the repositories as classes to encapsulate state (for in-memory) and dependencies (for MongoDB).

## Risks / Trade-offs

- [Risk] In-memory repository data loss. → **Mitigation**: This repository is only for development/testing and not for production use.
- [Risk] Divergence between repository interfaces. → **Mitigation**: Strictly implement the same method names and return types in both classes.
