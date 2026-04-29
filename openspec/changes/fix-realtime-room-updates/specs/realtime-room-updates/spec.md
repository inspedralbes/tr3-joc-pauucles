## ADDED Requirements

### Requirement: Real-time Lobby Updates on Creation
The system SHALL broadcast an updated list of all "waiting" rooms to all connected clients immediately after a new room is successfully created.

#### Scenario: New room visible in lobby
- **WHEN** a user creates a new game room via POST `/api/games/create`
- **THEN** all connected WebSocket clients SHALL receive a `room_list` message containing the new room.

### Requirement: Real-time Room Member Updates
The system SHALL broadcast the updated room state (members and their ready status) to all clients whenever a player joins or changes their ready status.

#### Scenario: Member joined notification
- **WHEN** a user joins a game room via POST `/api/games/join`
- **THEN** all connected WebSocket clients SHALL receive a `ROOM_UPDATED` message with the updated member list.

#### Scenario: Ready status synchronization
- **WHEN** a user sends a `READY` message via WebSocket
- **THEN** all connected WebSocket clients SHALL receive a `ROOM_UPDATED` message reflecting the changed ready status.
