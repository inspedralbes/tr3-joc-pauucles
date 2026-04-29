## Context

Minigame synchronization currently relies on a Host/Client model via WebSocket messages. This introduces latency and is prone to server-side bottlenecks. A deterministic approach allows both participants to independently arrive at the same minigame choice based on shared session data (usernames) and an incremental combat counter, ensuring perfect frame-parity synchronization without initial network handshakes.

## Goals / Non-Goals

**Goals:**
- Eliminate network dependency for the initial minigame trigger.
- Guarantee both players select the same minigame at the same frame.
- Prevent rapid-fire collision events from desynchronizing local combat counters.

**Non-Goals:**
- Removing mid-game synchronization (scores/actions still need network).
- Changing the win/loss resolution logic.

## Decisions

### 1. Shared Deterministic Seed
- **Decision**: Use `string.Compare` to create a stable key regardless of which player is "this" vs "opponent".
- **Implementation**: `clau = (Compare(Local, Rival) < 0) ? Local + Rival : Rival + Local`.
- **Rationale**: Both clients have access to both names. This key is identical for both.

### 2. Synchronization Anchor
- **Decision**: Use a static `comptadorCombats` variable incremented on each valid collision.
- **Rationale**: Assuming both players participate in the same sequence of minigames, the counter stays in sync. 
- **Risk Mitigation**: A 3-second cooldown (`ultimXoc`) prevents accidental double-increments from Physics engine jitter.

### 3. Immediate UI Activation
- **Decision**: Both clients act as "Authority" and open the UI manager instantly.
- **Rationale**: Since the choice is deterministic, there is no need to wait for a leader.

## Risks / Trade-offs

- **[Risk] Counter Drift** → If Player A collides with Player B, but only Player A's client registers the collision, their counters will drift.
    - *Mitigation*: The 3s cooldown reduces physics artifacts. A "Sync Counter" message could be added in the future, but for this iteration, we rely on the robustness of collision detection.
- **[Risk] Multiple Simultaneous Combats** → If Player A fights B while C fights D.
    - *Mitigation*: The static counter is global per client. Since a client can only be in one minigame at a time, this is acceptable.
