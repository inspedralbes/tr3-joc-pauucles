## Context

The system currently tracks game sessions but lacks a high-level service to manage room creation, availability, and capacity. This design introduces a dedicated `GameService` and `GameController` to handle room lifecycles and ensure that player assignments adhere to specified limits.

## Goals / Non-Goals

**Goals:**
- Extend the `Game` model to support player limits.
- Implement a service to generate unique room IDs and manage room states.
- Expose endpoints for listing waiting games and joining existing rooms.
- Ensure capacity checks are performed before allowing a player to join.

**Non-Goals:**
- Real-time room updates via WebSockets (this change focuses on the REST API).
- Complex matchmaking algorithms (joining is currently manual/direct).
- Advanced team balancing logic beyond simple capacity checks.

## Decisions

- **Room ID Generation**: Room IDs will be generated as unique strings (e.g., short UUIDs or random alphanumeric codes) to ensure session distinctness.
- **Service-Repository Pattern**: The `GameService` will depend on a `GameRepository` instance, following the project's established dependency injection pattern.
- **Status-based Filtering**: Listing available games will specifically filter for the 'waiting' status to ensure users only see rooms that haven't started.
- **Capacity Enforcement**: The `joinGame` logic will strictly verify if `players.length < maxPlayers` before persisting the update.

## Risks / Trade-offs

- **Concurrency Risk**: Multiple join requests for the same room could lead to overfilling if not handled atomically. [Risk] → Mitigation: Use Mongoose's findOneAndUpdate with conditional queries or transactional logic if high volume is expected.
- **Room ID Collisions**: While unlikely with long enough strings, collisions could happen. [Risk] → Mitigation: The repository's unique constraint on `roomId` will prevent duplicate storage, and the service will handle retries or errors.
