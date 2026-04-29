## Why

The current minigame implementation lacks real-time synchronization between participants, relying solely on local logic. This leads to desynchronized match outcomes and an inconsistent multiplayer experience. By introducing a universal synchronization system using existing WebSocket channels, we can achieve parity without server-side modifications.

## What Changes

- **Global Networking Methods**: Add `EnviarMinijocUpdate` and `EnviarMinijocResult` to the main networking script (`GameManager` or `WebSocketClient`).
- **Network Message Reception**: Implement handlers for `MINIJOC_UPDATE` and `MINIJOC_RESULT` that forward data to the `MinijocUIManager`.
- **UI Bridge**: `MinijocUIManager` will act as a bridge, passing network events to the currently active minigame logic script.
- **Speed Minigame Sync**: Update "Mates", "Barra", and "Cable" logics to broadcast results upon victory and yield if a rival result is received first.
- **State-Based Minigame Sync**: 
    - `MinijocPolsimForcaLogic`: Continuous synchronization of scores.
    - `MinijocPPTLLSLogic`: Step-wise synchronization of choices (Rock-Paper-Scissors) and synchronized resolution.

## Capabilities

### New Capabilities
- `minigame-network-sync`: Protocol for exchanging real-time updates and results during minigames.

### Modified Capabilities
- `foundations`: Update base minigame requirements to include networking hooks.

## Impact

- `GameManager.cs` / `WebSocketClient.cs`: Networking infrastructure.
- `MinijocUIManager.cs`: Event routing.
- All Minigame Logic scripts (`MinijocAturaBarraLogic`, `MinijocPolsimForcaLogic`, `MinijocPPTLLSLogic`, etc.).
