## Context

<!-- Background and current state -->
The current multiplayer system relies on a simple position relay with no prediction. Clients send their position every 100ms (10Hz). Remote players interpolate to the last known position using `SmoothDamp`, which results in visible "rubber-banding" or stuttering when packets are delayed or infrequent. The message payload is also redundant, sending the same metadata (skin, username) in every frame.

## Goals / Non-Goals

**Goals:**
- Eliminate stuttering in remote player movement through Dead Reckoning and improved interpolation.
- Reduce network overhead by optimizing the message payload.
- Improve connection stability via Nginx and GameManager configuration.
- Standardize the network update frequency to 20Hz (50ms).

**Non-Goals:**
- Implementation of server-side physics validation (authoritative server).
- Refactoring the entire WebSocket architecture (sticking to the current `ws` implementation).
- Adding new game features (focus is purely on performance and configuration).

## Decisions

### 1. Dead Reckoning and Interpolation
- **Rationale**: Predicting where a player will be based on their velocity significantly reduces the visual impact of latency.
- **Implementation**:
    - `NetworkSync` will now include `velocity` in its messages.
    - Remote clients will calculate `predictedPosition = lastReceivedPosition + (lastReceivedVelocity * (currentTime - lastPacketTime))`.
    - A small buffer (interpolated delay) of ~50-100ms will be used to smooth out jitter.
- **Alternative**: Prediction with server rollback. *Discarded* due to complexity and lack of authoritative server.

### 2. Delta Messaging Protocol
- **Rationale**: Metadata like skins and usernames don't change frequently.
- **Implementation**:
    - Introduce a `isHandshake` or `isFullUpdate` flag.
    - Handshake packets (sent once on connect or every 2s) include all metadata.
    - Standard `PLAYER_MOVE` packets will only include `id`, `x`, `y`, `vx`, `vy`, and animation states.
- **Alternative**: Protobuf or binary serialization. *Discarded* to keep debugging simple with JSON for now.

### 3. Connection Persistence (Infrastructure)
- **Rationale**: Default Nginx timeouts can close idle or long-running WebSocket connections.
- **Implementation**:
    - Update `nginx_default.conf` to include:
      ```nginx
      proxy_read_timeout 3600s;
      proxy_send_timeout 3600s;
      ```
- **Alternative**: Client-side keep-alive pings. *Already implemented* but Nginx timeouts provide a second layer of safety.

### 4. GameManager Optimization
- **Rationale**: Frequent `Find` calls and aggressive cleanup cause CPU spikes.
- **Implementation**:
    - Refactor `NetejaQuirurgica` to run only once after scene load + 5 seconds.
    - Optimize `UpdateRemotePlayer` to prioritize dictionary lookup and early exit.

## Risks / Trade-offs

- **[Risk] Prediction overshoot** → If a player suddenly changes direction, the prediction will "overshoot" until the next packet arrives. 
    - *Mitigation*: Cap the prediction distance and use a strong damping factor when correcting to the new real position.
- **[Risk] State Desync** → If metadata packets are lost, a client might not know the skin of a new player.
    - *Mitigation*: Use a reliable initial handshake and periodic full-state rebroadcasts.
- **[Risk] Increased CPU usage** → Calculating prediction for many players every frame.
    - *Mitigation*: Keep the math simple (linear) and only calculate for players within a certain range if needed (though 10-20 players should be fine).
