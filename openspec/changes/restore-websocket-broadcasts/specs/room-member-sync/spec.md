## ADDED Requirements

### Requirement: Room Sync on Player Join
The system SHALL broadcast a `ROOM_UPDATED` update to all clients whenever a new player joins an existing room.

#### Scenario: Real-time notification of new member
- **WHEN** a player joins a room via POST `/games/join`
- **THEN** all connected WebSocket clients SHALL receive a message with `type: "ROOM_UPDATED"` containing the updated player list for that room.

### Requirement: Room Sync on Player Ready
The system SHALL broadcast a `ROOM_UPDATED` update to all clients immediately after a player changes their ready status.

#### Scenario: Real-time notification of ready status
- **WHEN** a player sends a `READY` message via WebSocket
- **THEN** all connected WebSocket clients SHALL receive a message with `type: "ROOM_UPDATED"` reflecting the new ready status of that player.
- **AND** this broadcast SHALL occur before the system evaluates if the game should start.

### Requirement: Room Sync on Player Departure
The system SHALL broadcast a `ROOM_UPDATED` update to all clients if a player leaves a room and the room remains active.

#### Scenario: Real-time notification of member departure
- **WHEN** a player (non-host) leaves a room
- **THEN** all connected WebSocket clients SHALL receive a message with `type: "ROOM_UPDATED"` reflecting the removal of that player.
