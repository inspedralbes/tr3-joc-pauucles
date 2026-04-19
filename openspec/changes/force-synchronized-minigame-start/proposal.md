## Why

Currently, when two players collide, both clients independently attempt to start a minigame, often leading to visual desynchronization or race conditions. By implementing a deterministic "Combat Host" pattern based on username comparison, we ensure that only one client is responsible for game selection and broadcast, creating a stable and unified experience for both participants.

## What Changes

- **Deterministic Role Selection**: Update `Player.cs` to compare usernames upon collision. The player with the lexicographically smaller name acts as the Host.
- **Authoritative Game Selection**: Only the Host generates the random `gameIndex` and initializes the UI locally.
- **WebSocket Synchronization (BREAKING)**: Implement a new `MINIJOC_START` message that forces the Client to open the exact same minigame as the Host.
- **Passive Client State**: The Client player will freeze movement and wait for the network message instead of opening the UI independently.
- **Robust UI Activation**: Update the network receiver to find and activate the `MinijocUIManager` even if it is currently disabled in the scene hierarchy.

## Capabilities

### New Capabilities
- `combat-host-selection`: Implementation of the deterministic role assignment logic.

### Modified Capabilities
- `minigame-network-sync`: Update the initiation requirements to support remote-triggered startup.

## Impact

- `Player.cs`: Core collision and role logic.
- `MenuManager.cs` / Networking Script: Implementation of the `MINIJOC_START` handler.
- `MinijocUIManager.cs`: Indirectly affected by being remotely activated and initialized.
