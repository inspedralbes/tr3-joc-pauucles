## Context

The backend uses a WebSocket server (`wss`) to push real-time updates to the Unity frontend. Currently, `GameController` methods responsible for these updates are failing because they cannot access the `wss` instance (`this.wss` is `undefined`). This breaks the lobby list updates and room state synchronization.

## Goals / Non-Goals

**Goals:**
- Restore real-time synchronization by ensuring `GameController` has access to the `wss` instance.
- Standardize broadcast formats for `ACTUALITZAR_SALES` and `ROOM_UPDATED`.
- Provide clear logs for debugging WebSocket delivery issues.

**Non-Goals:**
- Implementing a persistent socket-to-user mapping (broadcast to all is acceptable for now).
- Refactoring the entire WebSocket architecture.

## Decisions

- **Dependency Injection Enforcement**: We will verify that `server.js` correctly passes the `wss` instance through `gameRoutes` to the `GameController` constructor. If the instance is somehow lost or detached, we will add guards.
- **Explicit Logging**: Every broadcast attempt will log `Estat wss: true/false` and `Enviant broadcast a X clients` to immediately identify if the issue is instance availability or connection count.
- **Message Standardization**:
    - Room list: `{ type: 'ACTUALITZAR_SALES', sales: llistaSales }`
    - Room details: `{ type: 'ROOM_UPDATED', room: salaData }`

## Risks / Trade-offs

- **[Risk] Broadcast to all clients**: Sending room updates to every connected client (even those in other rooms) might be inefficient as the player base grows.
- **[Mitigation]**: For the current development stage (emergency fix), this is acceptable. Future optimizations can implement room-specific broadcasting.
