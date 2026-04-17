## ADDED Requirements

### Requirement: Broadcast on Room Creation
The system SHALL broadcast the updated list of waiting rooms to all connected clients immediately after a room is successfully created in MongoDB.

#### Scenario: Real-time update after room creation
- **WHEN** a new room is created via the REST API
- **THEN** the system SHALL broadcast a message with `type: "ACTUALITZAR_SALES"` and a `sales` key containing the list of rooms.
- **AND** a console log "Broadcast CREAR_SALA enviat" SHALL be emitted.

### Requirement: Broadcast on Room Join
The system SHALL broadcast the updated room data and the global list of rooms after a player successfully joins a room.

#### Scenario: Real-time update after player joins
- **WHEN** a player joins a room via the REST API
- **THEN** the system SHALL broadcast a message with `type: "ROOM_UPDATED"` and a `room` key containing the updated room data.
- **AND** the system SHALL broadcast a message with `type: "ACTUALITZAR_SALES"` to all clients.
- **AND** a console log "Broadcast JOIN_ROOM enviat" SHALL be emitted.

### Requirement: Broadcast on Player Ready
The system SHALL broadcast the updated room data immediately after a player changes their ready status, before evaluating game start conditions.

#### Scenario: Real-time update after player is ready
- **WHEN** a `READY` message is received via WebSocket and processed
- **THEN** the system SHALL broadcast a message with `type: "ROOM_UPDATED"` and a `room` key containing the updated room data.
