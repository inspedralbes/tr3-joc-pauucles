## Context

The current minigame resolution system lacks a way to communicate results between participants through the existing network relay. This design introduces a "Hack Z" signaling protocol that overloads the unused Z coordinate in 2D position updates to broadcast victory/defeat states. This allows for zero-latency, zero-server-logic match synchronization while introducing gameplay consequences through a "Stun" mechanic.

## Goals / Non-Goals

**Goals:**
- Implement a 3-second immobilization (Stun) for minigame losers.
- Synchronize combat resolution using the Z coordinate as a signal channel (Sentinel value 999.0f).
- Ensure the minigame UI closes automatically on both clients upon resolution.
- Standardize the win/loss feedback methods in the player component.

**Non-Goals:**
- Modifying the Node.js server.
- Changing actual 2D depth sorting (Z is purely for signaling).

## Decisions

### 1. The Z-Hack Protocol
- **Decision**: Overload the Z field in `PlayerMoveMessage`.
- **Rationale**: Since the game is 2D, the Z coordinate is unused and already part of the transform synchronization. Sending a specific value (999.0f) is a low-bandwidth, non-intrusive way to send a "Kill Signal" to the opponent's minigame session.
- **Winner Action**: Sets local Z to 999.0f for a few frames.
- **Loser Detection**: When receiving a remote Z of 999.0f, the local client interprets it as "The other player won, I lost".

### 2. Stun via Coroutine
- **Decision**: Use `RutinaStun(float temps)` in `Player.cs`.
- **Rationale**: Clean management of the `potMoure` flag without complex state machines.

### 3. Centralized Network Handler
- **Decision**: Handle the signal detection in `MenuManager.AlRebreActualitzacioSales`.
- **Rationale**: This is the primary dispatcher for movement messages. Detecting the hack here allows for immediate UI closure and player status updates before the coordinate even reaches the `RemotePlayer` instance.

## Risks / Trade-offs

- **[Risk] Visual Glitch** → A character might momentarily jump to Z=999.
    - *Mitigation*: The receiver logic will immediately reset the target Z to 0.0f and the sender will also reset it after one sync cycle.
- **[Risk] Multiple Triggers** → Receiving the signal twice.
    - *Mitigation*: The logic will only trigger the defeat sequence if a minigame UI is currently active.
- **[Risk] Server Incompatibility** → If the server rejects JSON with an extra 'z' field.
    - *Mitigation*: The server is a standard Node.js relay; it typically passes through all JSON fields blindly.
