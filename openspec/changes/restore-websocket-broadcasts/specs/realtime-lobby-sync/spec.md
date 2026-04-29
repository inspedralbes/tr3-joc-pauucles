## ADDED Requirements

### Requirement: Lobby Update on Room Creation
The system SHALL broadcast a `room_list` update to all connected clients immediately after a room is successfully created via the REST API.

#### Scenario: Real-time lobby update after creation
- **WHEN** a client successfully creates a room via POST `/games/create`
- **THEN** all connected WebSocket clients SHALL receive a message with `type: "room_list"` containing the updated list of waiting rooms.

### Requirement: Lobby Update on Room Deletion
The system SHALL broadcast a `room_list` update to all connected clients whenever a room is deleted (e.g., when a host leaves).

#### Scenario: Real-time lobby update after room removal
- **WHEN** a game room is deleted from MongoDB
- **THEN** all connected WebSocket clients SHALL receive a message with `type: "room_list"` reflecting the removal of the room.
