## Context

The current minigame initiation logic has inconsistencies in identifying the rival and managing the timing of UI activation between the Host and the Client. This final design enforces a reliable identity retrieval mechanism and a strict synchronization flow to ensure both players see the same minigame simultaneously.

## Goals / Non-Goals

**Goals:**
- Reliable extraction of opponent identity from the `RemotePlayer` component.
- Zero-latency UI activation for the Host participant.
- Absolute passivity for the Client participant until the authoritative network message is received.
- Robust UI manager recovery in both scene states (active/inactive).

**Non-Goals:**
- Changing minigame logic.
- Modifying backend server logic.

## Decisions

### 1. Opponent Identity Retrieval
- **Decision**: Add a `public string username;` field to `RemotePlayer.cs` and populate it during `Configurar`.
- **Rationale**: Relying on GameObject names is risky and prone to naming collisions or truncation. A dedicated variable in the synchronization component is the industry standard.
- **Implementation**: `collision.gameObject.GetComponent<RemotePlayer>().username`.

### 2. Immediate Host UI Response
- **Decision**: The Host (smaller lexicographical username) will open the UI manager locally *before* broadcasting.
- **Rationale**: Provides immediate visual feedback to the player who triggered the action, while the other player is guaranteed to receive the message within milliseconds.

### 3. Strict Execution Branching in `Player.cs`
- **Implementation**:
    - **Host Branch**: `gameIndex` generation → `SetActive(true)` on manager → `IniciarMinijoc` → `websocket.SendText`.
    - **Client Branch**: `potMoure = false` → `Debug.Log` → `return`. This prevents the Client from executing any local UI discovery logic.

### 4. Robust Manager Recovery
- **Decision**: Use `Resources.FindObjectsOfTypeAll<MinijocUIManager>()[0]` in both `Player.cs` (Host) and `MenuManager.cs` (Client).
- **Rationale**: Ensures the manager is found even if its root object is disabled in the hierarchy, which is common in "Screen Overlay" UI designs.

## Risks / Trade-offs

- **[Risk] Null References** → If the collision partner is missing the `RemotePlayer` component.
    - *Mitigation*: The logic includes a null-check and immediate `return` to prevent runtime errors.
- **[Risk] Multiple UI Managers** → If there are multiple managers in the assets.
    - *Mitigation*: We assume a single instance per scene.
