## Context

The backend is being built following the Repository Pattern to decouple business logic from storage details. For the TR3 final version, we need a robust and complete data layer that covers all aspects of the application: users (with stats), game sessions, and match results.

## Goals / Non-Goals

**Goals:**
- Implement all Mongoose models with the exact TR3 field requirements.
- Implement both `InMemory` and `Mongo` repositories for all three entities (`User`, `Game`, `Result`).
- Ensure all repositories implement a consistent interface (at least `create` and `findBy[Key]`).

**Non-Goals:**
- Implementation of higher-level services or controllers.
- Implementation of front-end components.
- Advanced data analytics or complex reporting beyond basic stats.

## Decisions

- **Consistent Interface**: All repositories for a given model will have the same methods to allow interchangeable usage.
- **In-Memory Default Values**: The `InMemory` repositories will manually handle default values to mirror Mongoose's behavior.
- **Model Organization**: We will keep the models in `backend/src/models/` and repositories in `backend/src/repositories/`.

## Risks / Trade-offs

- **Synchronization Risk**: If `InMemory` and `Mongo` repositories are used simultaneously in different parts of the app without care, data will diverge. Mitigation: Ensure that the app uses a single repository instance per entity, typically via dependency injection or a central factory.
- **Redundancy**: Having both `InMemory` and `Mongo` versions for all entities adds boilerplate. Mitigation: This is necessary for the TR3 project requirements which emphasize flexibility and testing.
