## Context

The current minigame synchronization attempts to coordinate starts but lacks strict enforcement, sometimes leading to race conditions where both clients try to act as Host. This design enforces an absolute Host/Client relationship based on deterministic username comparison, ensuring only one source of truth for the random minigame selection.

## Goals / Non-Goals

**Goals:**
- Implement a rigid Host/Client split for combat initiation.
- Prevent Clients from opening the minigame UI locally under any circumstance during collision.
- Ensure the Client waits specifically for the network command before proceeding.
- Implement robust recovery of the UI manager on the receiving end.

**Non-Goals:**
- Changing minigame mechanics.
- Modifying the server (which remains a message relay).

## Decisions

### 1. Authoritative Leader Election
- **Decision**: Use `string.Compare(nomLocal, nomRival) < 0` to determine the Host.
- **Rationale**: Lexicographical comparison of unique usernames is a stateless, decentralized way to guarantee that exactly one player in any pair is the leader.

### 2. Host Responsibilities
- **Implementation**: 
    - Generate `gameIndex`.
    - Find and activate `MinijocUIManager` via `Resources.FindObjectsOfTypeAll` (to handle disabled objects).
    - Call `IniciarMinijoc` immediately.
    - Broadcast `MINIJOC_START`.

### 3. Client Responsibilities (Strict)
- **Implementation**:
    - Freeze local and opponent movement.
    - Log "Sóc client, espero la xarxa".
    - **Crucial**: Execute an immediate `return;` to bypass all local UI logic.

### 4. Remote Triggering Logic
- **Decision**: Use `Resources.FindObjectsOfTypeAll<MinijocUIManager>()[0]` in the WebSocket handler.
- **Rationale**: In build environments, singleton instances or `FindObjectOfType` might fail if the UI root is inactive. This method ensures we find the prefab/instance even if it's disabled.

## Risks / Trade-offs

- **[Risk] Packet Loss** → If the `MINIJOC_START` message is lost, the Client remains frozen indefinitely.
    - *Mitigation*: We rely on the established WebSocket reliability. In a production environment, a timeout/retry or "Request State" fallback would be needed.
- **[Risk] Multiple Managers** → `Resources.FindObjectsOfTypeAll` might find multiple instances if they exist as assets.
    - *Mitigation*: We assume a single scene instance exists. We will pick the first valid scene object found.
