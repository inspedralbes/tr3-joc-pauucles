## Why

The current "Combat Host" implementation is hybrid, where the Host opens the UI locally while the Client waits for the network message. This can lead to minor timing offsets and visual glitches. By adopting a strict synchronization pattern where both participants wait for the confirmed broadcast from the server, we achieve perfect parity in combat startup.

## What Changes

- **Passive Host Logic**: Update `Player.cs` so the Host player broadcasts the `MINIJOC_START` message but does NOT open the local UI manager immediately.
- **Network-Driven UI Activation**: Centralize all minigame UI startup in the network receiver. Both the Host (upon receiving their own broadcast reflection) and the Client will trigger the UI simultaneously.
- **Robust UI Recovery**: Implement a fail-safe UI lookup using `Resources.FindObjectsOfTypeAll` in the network handler to handle disabled GameObjects in builds.
- **Authoritative Container Management**: Refactor `MinijocUIManager.cs` to ensure that only the container matching the network-provided `gameIndex` is enabled, while all others are strictly disabled.

## Capabilities

### New Capabilities
- `strict-network-initiation`: Protocol where all local UI transitions are gated by network message arrival.

### Modified Capabilities
- `combat-host-selection`: Refine the host logic to remove local-only side effects.

## Impact

- `Player.cs`: Removal of local `MinijocUIManager` calls during collision.
- `MenuManager.cs` / Networking: Updated `MINIJOC_START` handler as the sole entry point for UI activation.
- `MinijocUIManager.cs`: Refactored initialization to handle strict container management by index.
