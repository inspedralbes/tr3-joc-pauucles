## Why

Currently, the game room list in the Lobby is only updated when the user enters the screen or manually refreshes. This leads to a poor user experience where new rooms created by other players are not visible in real-time. Dynamic synchronization via WebSockets will ensure the room list is always up-to-date without manual intervention.

## What Changes

- **WebSocket Integration**: Subscribe `MenuManager.cs` to real-time room update messages from the server.
- **Dynamic UI Updates**: Implement a handler to process incoming room list data and refresh the Lobby UI (`llistaPartides`) immediately.
- **JSON Processing**: Add logic to deserialize the server's room list JSON and map it to the UI elements.

## Capabilities

### New Capabilities
- `room-sync-websocket`: Real-time synchronization of the game room list using WebSocket events.

### Modified Capabilities
<!-- No requirement changes to existing specs -->

## Impact

- `DAMT3Atrapa la bandera/Assets/Scripts/MenuManager.cs`: Main script for UI and networking logic.
- `DAMT3Atrapa la bandera/Assets/UI/MenuUI.uxml`: UI structure for the lobby list.
- WebSocket server: Needs to emit room list updates to connected clients.
