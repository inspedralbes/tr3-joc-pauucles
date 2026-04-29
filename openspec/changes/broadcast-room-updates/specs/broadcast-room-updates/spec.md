## ADDED Requirements

### Requirement: Broadcast Room Updates
The system SHALL broadcast the current list of pending rooms to all connected WebSocket clients whenever a new room is successfully created.

#### Scenario: Successful room list broadcast
- **WHEN** a new room is created via the HTTP API
- **THEN** all connected WebSocket clients SHALL receive a message of type "ACTUALITZAR_SALES" containing the full list of waiting rooms.

### Requirement: Accurate Data Retrieval
The system SHALL ensure the broadcasted room list matches the current state of the database.

#### Scenario: Data consistency
- **WHEN** the broadcast is triggered
- **THEN** the system MUST fetch the most recent list of rooms with "waiting" status from MongoDB before sending.

### Requirement: Fault-tolerant Broadcasting
The system SHALL skip broadcasting to clients that are no longer connected or are in a non-open state.

#### Scenario: Handling disconnected clients
- **WHEN** iterating over connected clients
- **THEN** the system MUST only attempt to send messages to clients whose `readyState` is `OPEN`.
