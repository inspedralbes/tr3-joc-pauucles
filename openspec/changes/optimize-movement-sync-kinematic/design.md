## Context

Currently, remote player movement is managed by `RemotePlayer.cs`, but inconsistencies in how physics and synchronization interact (especially gravity) lead to jittery visuals. By unifying this logic in `NetworkSync.cs` and enforcing kinematic rigidbodies for remote players, we can achieve smoother transitions and more reliable state synchronization.

## Goals / Non-Goals

**Goals:**
- Eliminate gravity-induced jitter on remote players.
- Unify network synchronization logic in a single component (`NetworkSync.cs`).
- Provide smooth movement via positional interpolation.

**Non-Goals:**
- Refactoring the entire character controller or local player movement.
- Implementing complex server-authoritative physics.

## Decisions

### 1. Kinematic Enforcement for Remote Players
In `NetworkSync.Start()`, we will identify if the instance belongs to a remote player (e.g., checking if it's NOT the `GameManager.Instance.localPlayer`).
- **Implementation**: `GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;`
- **Rationale**: This prevents local Unity gravity from pulling the remote object down while we are trying to interpolate it to network-received positions.

### 2. Unified State Management in NetworkSync
`NetworkSync.cs` will be updated with:
- `private bool isRemote;` (set at Start).
- `private Vector2 posicioObjectiu;` (used for interpolation).
- **Rationale**: Having one script handle both roles (local/remote) makes debugging and synchronization logic much simpler.

### 3. Immediate Visual Sync
Orientation (`flipX`) and animation parameters will still be updated immediately upon receiving a message, even as position is interpolated.
- **Rationale**: This maintains visual responsiveness and avoids animation lag.

## Risks / Trade-offs

- **[Risk]** Complexity of unified script.
- **[Mitigation]** Use clear conditional blocks (`if (isRemote) ... else ...`) to separate local transmission from remote interpolation.
- **[Risk]** Breaking existing `RemotePlayer.cs` dependencies.
- **[Mitigation]** Carefully transition `RemotePlayer.UpdateStatus` to call the new `NetworkSync` methods or merge the logic entirely.
