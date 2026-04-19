## Why

The waiting room UI in the `MenuPrincipal` scene does not consistently update when new players join or when the room state changes via WebSockets. This leads to players having an outdated view of the room's participants and their ready statuses, causing confusion and forcing manual refreshes.

## What Changes

- **Automatic UI Refresh**: Implement a dedicated `ActualitzarUIJugadorsSala()` method to reconstruct the player list information.
- **WebSocket Integration**: Ensure that every time a `ROOM_UPDATED` message is received via WebSocket, the UI is forced to redraw the player list.
- **Real-time Synchronization**: Iterate through `currentRoomData.players` to build a fresh representation of all connected players and their current state (e.g., "(Llest)" or "(Esperant)").

## Capabilities

### New Capabilities
- `waiting-room-realtime-sync`: Provides automatic, real-time updates to the waiting room player list whenever the server broadcasts room changes.

### Modified Capabilities
- `foundations`: Enhances the foundation for networked UI state synchronization.

## Impact

- `MenuManager.cs`: Primary location for the fix. The `AlRebreActualitzacioSales` method and a new helper method will be updated/added.
- End-user Experience: Players will now see room occupancy changes immediately without manual intervention.
