## Context

Currently, the data flow for remote player movement is fragmented. `MenuManager.cs` receives WebSocket messages, and `GameManager.cs` maintains a private list of players. This design formalizes the connection between these components to ensure smooth and reliable coordinate routing.

## Goals / Non-Goals

**Goals:**
- Provide a centralized, public registry for remote player instances.
- Standardize the method for injecting external coordinates into a player object.
- Decouple WebSocket message parsing from direct object manipulation.

**Non-Goals:**
- Implementing server-side verification of coordinates.
- Changing the existing JSON message format (`PlayerMoveMessage`).

## Decisions

### 1. Public Registry for Remote Players
In `GameManager.cs`, we will change the visibility of `remotePlayers` to `public`.
- **Key**: `string username` (matching the `username` field in network messages).
- **Value**: `RemotePlayer` script reference.
- **Rationale**: Public visibility allows `MenuManager` or other network controllers to quickly check for player existence without complex callbacks.

### 2. Standardized Update Method
We will implement/refine `GameManager.UpdateRemotePlayer(moveMsg)` to act as the primary entry point for network coordinates.
- **Logic**:
    1. Check if `username` exists in `remotePlayers`.
    2. If it exists, call `rp.UpdateStatus(msg)`.
    3. `rp.UpdateStatus(msg)` then calls `ns.RebrePosicio(msg.x, msg.y)` on the `NetworkSync` component.
- **Rationale**: This preserves the existing "instantiate on first move" logic while ensuring subsequent moves are handled by the optimized `NetworkSync` interpolation.

### 3. Routing Responsibility
`MenuManager.cs` will remain the message dispatcher but will delegate all visual updates to `GameManager`.
- **Rationale**: Separates network concerns (MenuManager) from game state/visual concerns (GameManager).

## Risks / Trade-offs

- **[Risk]** Dictionary key mismatch if names are changed server-side.
- **[Mitigation]** Use `msg.username` consistently as the source of truth for identification.
- **[Risk]** Stale entries in the dictionary if players leave abruptly.
- **[Mitigation]** Implement a `RemoveRemotePlayer(string username)` method to be called upon receipt of disconnect/leave messages.
