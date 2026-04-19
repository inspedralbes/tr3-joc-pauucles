## Context

The current multiplayer movement feels jittery because remote players are simply teleported to new positions. Additionally, the local client sends updates blindly at a fixed rate, which can be inefficient when the player is stationary.

## Goals / Non-Goals

**Goals:**
- Smooth movement for remote players using interpolation.
- Reduce unnecessary network traffic for stationary local players.
- Maintain accurate visual states (animations, flip) for all players.

**Non-Goals:**
- Server-side authoritative movement (this remains client-side).
- Lag compensation techniques like client-side prediction for remote players (beyond basic interpolation).

## Decisions

### 1. Throttled Transmission with Threshold
In `NetworkSync.cs`, we will implement a dual-check for sending updates:
- **Time Check**: A fixed maximum update rate (e.g., 10Hz or 0.1s).
- **Distance Check**: A minimum distance threshold (e.g., 0.05 units).
- **Rationale**: This prevents spamming updates when a player is barely moving but ensures the server is eventually updated if the player stops or moves very slowly.

### 2. Smooth Positional Interpolation
In `RemotePlayer.cs`, we will store the last received position as a `targetPosition`:
- **Implementation**: In the `Update()` loop, use `transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * interpolationSpeed)`.
- **Rationale**: `Lerp` provides a smooth visual transition, masking the discrete nature of network updates.

### 3. Immediate Visual State Updates
While position is interpolated, orientation (`flipX`) and animation parameters will be applied immediately upon receipt of a message.
- **Rationale**: Jitter in position is noticeable, but delayed animation states feel "laggy" in a different way. Immediate visual feedback for state changes is preferred.

## Risks / Trade-offs

- **[Risk]** Interpolation lag: Remote players will appear slightly behind their actual position on the local client (by approximately one network tick).
- **[Mitigation]** This is a standard trade-off in multiplayer games for visual smoothness.
- **[Risk]** Large teleports (e.g., respawn) might look weird with interpolation.
- **[Mitigation]** If the distance to `targetPosition` is very large (e.g., > 5 units), we can snap the position instead of lerping.
