## Why

Winning or losing a minigame currently has no impact on gameplay mobility, and there is no simple way to notify the opponent of their defeat through the existing WebSocket relay without modifying the server. By implementing a "Z Hack" (using the unused Z coordinate in 2D position updates) as a signal, we can synchronize match resolution with zero server overhead and introduce a tangible "Stun" penalty for the loser.

## What Changes

- **Immobilization Logic**: Implement a `RutinaStun` coroutine in `Player.cs` to temporarily disable movement.
- **Minigame Resolution Bridge**: Add `GuanyarMinijoc` and `PerdreMinijoc` methods to the player component to handle post-combat effects.
- **Z-Coordinate Signaling (Hack)**: Overload the character's Z position with a sentinel value (999f) to broadcast victory to the opponent.
- **Authoritative Defeat Trigger**: Update the network receiver (`GameManager` or movement sync) to detect the Z-999 signal and force the local player into the "Losing" state, closing the UI automatically.

## Capabilities

### New Capabilities
- `z-hack-synchronization`: Protocol for signaling binary states (like win/loss) through existing position synchronization channels.

### Modified Capabilities
- `player-status-management`: Update mobility requirements to support temporary stun states.

## Impact

- `Player.cs`: Implementation of stun and signaling methods.
- `GameManager.cs` / Networking: Update to movement processing to handle sentinel Z values.
- `MinijocUIManager.cs`: Indirectly affected by the remote UI closure trigger.
