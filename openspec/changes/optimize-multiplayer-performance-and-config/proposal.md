## Why

<!-- Explain the motivation for this change. What problem does this solve? Why now? -->
The current multiplayer experience suffers from significant lag and "stuttery" movement of remote players. This is caused by a low network update frequency (10Hz) and a lack of sophisticated movement interpolation or prediction (Dead Reckoning). Additionally, the multiplayer configuration lacks stability in connection persistence and efficient state synchronization.

## What Changes

<!-- Describe what will change. Be specific about new capabilities, modifications, or removals. -->
- **Network Synchronization Update**: Increase the update rate from 10Hz to 20Hz (0.05s interval) in `NetworkSync.cs`.
- **Implementation of Dead Reckoning**: Use velocity to predict remote player positions between network packets, reducing perceived lag.
- **Interpolation Smoothing**: Replace simple `SmoothDamp` with a more robust linear interpolation and jitter buffer logic.
- **Message Payload Optimization**: Reduce the size of `PLAYER_MOVE` messages by omitting static data (skin, username) in high-frequency updates after the initial handshake.
- **Nginx Stability Improvements**: Update `nginx_default.conf` with appropriate timeouts for WebSocket connections to prevent unexpected disconnections.
- **GameManager Robustness**: Refactor `UpdateRemotePlayer` and `NetejaQuirurgica` in `GameManager.cs` to reduce overhead and improve consistency when spawning/removing players.

## Capabilities

### New Capabilities
<!-- Capabilities being introduced. Replace <name> with kebab-case identifier (e.g., user-auth, data-export, api-rate-limiting). Each creates specs/<name>/spec.md -->
- `network-dead-reckoning`: Implements velocity-based position prediction for remote players to mask latency.
- `optimized-payload-sync`: Implements a two-tier synchronization protocol (full state vs. minimal delta) to reduce bandwidth.

### Modified Capabilities
<!-- Existing capabilities whose REQUIREMENTS are changing (not just implementation).
     Only list here if spec-level behavior changes. Each needs a delta spec file.
     Use existing spec names from openspec/specs/. Leave empty if no requirement changes. -->
- `minigame_sync`: Enhance synchronization reliability by ensuring player state (potMoure) is strictly enforced during minigame transitions.

## Impact

<!-- Affected code, APIs, dependencies, systems -->
- **Frontend (Unity)**: `NetworkSync.cs`, `RemotePlayer.cs`, `GameManager.cs`, `WebSocketClient.cs`.
- **Backend (Node.js)**: `game-service.js` (minor message handling updates).
- **Infrastructure**: `nginx_default.conf` (timeout configurations).
