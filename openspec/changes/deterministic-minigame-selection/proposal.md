## Why

The current minigame initiation relies on WebSocket handshakes which are prone to server-side blocking, latency desync, or message loss. This can leave one player frozen while the other is in a minigame, or cause visual desynchronization. By implementing a pure deterministic seed algorithm, both clients can independently but identically decide which minigame to start at the exact same frame of collision, eliminating network dependency for the trigger phase.

## What Changes

- **Removal of Network Triggers**: Remove all code in `Player.cs` and networking scripts that sends or receives `MINIJOC_START` messages.
- **Deterministic Seed Algorithm**: Implement a collision-based selection logic using a shared key (sorted usernames) and a combat counter.
- **Collision Cooldown**: Add a static cooldown timer to prevent rapid-fire collision events from desynchronizing counters.
- **Immediate Authoritative UI**: Both clients will now act as "Authoritative" locally, opening the UI manager instantly upon collision detection.

## Capabilities

### New Capabilities
- `deterministic-combat-trigger`: Logic for independent but identical state selection based on shared session data.

### Modified Capabilities
- `minigame-network-sync`: Simplify requirements to only cover mid-game synchronization, removing the initiation handshake.

## Impact

- `Player.cs`: Complete rewrite of `OnCollisionEnter2D` logic.
- `MenuManager.cs` / Networking: Removal of `MINIJOC_START` message handling.
- `MinijocUIManager.cs`: No changes required to its API, but will be called differently.
