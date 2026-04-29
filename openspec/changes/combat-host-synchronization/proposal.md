## Why

Currently, when two players collide, each client independently selects a random minigame. This leads to desynchronization where both players see different minigames on their screens. By implementing a "Combat Host" pattern, we ensure that both participants play the exact same minigame, synchronized via WebSocket messages.

## What Changes

- **Deterministic Host Selection**: Update `Player.cs` to compare usernames during a collision. The player with the lexicographically smaller name becomes the "Host".
- **Synchronized Combat Initiation**: The Host generates the `gameIndex` and broadcasts a `MINIJOC_START` message to the other participant.
- **Passive Participant Waiting**: Non-host players will freeze their movement but wait for the WebSocket message before opening the minigame UI.
- **WebSocket Event Handling**: Update the network message receiver (`GameManager` or `MenuManager`) to handle `MINIJOC_START` and trigger the UI with the received index for the relevant players.

## Capabilities

### New Capabilities
- `combat-host-protocol`: Protocol for deterministic leader selection and minigame state synchronization between two participants.

### Modified Capabilities
- `minigame-network-sync`: Update the synchronization requirements to include the initial game selection phase.

## Impact

- `Player.cs`: Update collision logic to include host comparison and message sending.
- `MenuManager.cs` / `GameManager.cs`: Implement handling for the new `MINIJOC_START` WebSocket message.
- `MinijocUIManager.cs`: Ensure `IniciarMinijoc` can accept a pre-determined game index.
