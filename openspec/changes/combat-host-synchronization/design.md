## Context

Minigame selection is currently decentralized, leading to visual desynchronization where two players in the same combat see different minigames. To resolve this, we adopt a "Combat Host" pattern where the participant with the lexicographically smaller username takes responsibility for selecting the game and broadcasting it to the other participant.

## Goals / Non-Goals

**Goals:**
- Ensure both participants in a combat play the exact same minigame.
- Implement a deterministic host selection process that requires no server-side logic (only message relay).
- Maintain player movement restriction during the handshaking phase.

**Non-Goals:**
- Modifying the server logic.
- Changing the actual minigame mechanics (only the initiation is changed).

## Decisions

### 1. Deterministic Host Assignment
- **Decision**: Use `string.Compare(p1, p2)` on usernames.
- **Rationale**: Both clients have access to both usernames during a collision. A lexicographical comparison is a simple, stateless way to ensure one and only one client becomes the "Host".

### 2. Synchronized Initiation Protocol
- **Decision**: The Host generates the `gameIndex` and broadcasts `MINIJOC_START`.
- **Implementation Flow**:
    1.  Collision detected. Both players set `potMoure = false`.
    2.  Comparison determines Host.
    3.  Host opens `MinijocUIManager` locally with random index.
    4.  Host sends WebSocket message.
    5.  Client receives message, identifies if it's a participant, and opens `MinijocUIManager` with the received index.

### 3. New WebSocket Message Type
- **Decision**: `MINIJOC_START` message structure.
- **Fields**:
    - `type`: "MINIJOC_START"
    - `gameIndex`: integer (1-6)
    - `p1`: Initiator username
    - `p2`: Target username

## Risks / Trade-offs

- **[Risk] Message Latency** → The non-host player might be frozen for a short duration while the message travels.
    - *Mitigation*: This is acceptable for a "Combat Start" effect. We can add a "Waiting for rival..." UI if necessary, but immediate freezing feels natural for combat.
- **[Risk] Missing Local Names** → If `WebSocketClient.Username` is null.
    - *Mitigation*: Fallback to generic comparison or ensure session data is populated before allowing combat.
