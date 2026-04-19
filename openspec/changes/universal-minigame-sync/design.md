## Context

Minigames in the project currently run purely on the local client, leading to synchronization issues where both players might think they won or the game outcomes don't match. To fix this without modifying the backend server logic (which only relays messages), we need a standardized way to exchange minigame-specific updates and final results using the existing WebSocket infrastructure.

## Goals / Non-Goals

**Goals:**
- Implement a universal communication bridge for minigames.
- Ensure speed-based minigames (AturaBarra, Mates, Cable) yield to the first winner's broadcast.
- Synchronize continuous states like scores in `PolsimForca`.
- Synchronize discrete choices like Rock-Paper-Scissors in `PPTLLS`.

**Non-Goals:**
- Modifying the Node.js backend.
- Changing the core minigame rules (just how they sync).

## Decisions

### 1. Networking Infrastructure in `MenuManager.cs`
- **Decision**: Add standardized message types and sending methods to `MenuManager.cs`.
- **Rationale**: `MenuManager` already holds the active WebSocket connection.
- **Messages**:
    - `MINIJOC_UPDATE`: For continuous data (scores, choices).
    - `MINIJOC_RESULT`: For final outcome (winner name).

### 2. Event Routing in `MinijocUIManager.cs`
- **Decision**: `MinijocUIManager` will act as a central dispatcher for minigame network events.
- **Implementation**: Methods `RebreActualitzacioXarxa` and `RebreResultatXarxa` will call methods on the specific active logic component via an interface or type-checking.

### 3. Minigame-Specific Sync Strategies
- **Speed Minigames**: Local winner sends `MINIJOC_RESULT`. If a `MINIJOC_RESULT` is received from the rival first, the local game ends in defeat immediately.
- **PolsimForca**: Every input click or score change sends a `MINIJOC_UPDATE` with the new score. Both clients lerp/sync based on these values.
- **PPTLLS**: Choice selection sends a `MINIJOC_UPDATE`. Local resolution only happens when both `localChoice` and `rivalChoice` are set.

## Risks / Trade-offs

- **[Risk] Latency** → In speed games, two players might win at nearly the same time.
    - *Mitigation*: The first message received by the server and broadcasted back effectively determines the global winner.
- **[Risk] Cheating** → Since logic is client-side, a player could forge winning messages.
    - *Mitigation*: Out of scope for this project; we assume cooperative/honest clients for now.
