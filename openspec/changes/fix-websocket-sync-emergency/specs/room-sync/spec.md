## ADDED Requirements

### Requirement: Broadcast Room List Updates
The system MUST broadcast the full list of available games to all connected WebSocket clients whenever a room is created or a player's join/leave status changes the room's availability.

#### Scenario: Update lobby on room creation
- **WHEN** a new room is successfully created and saved to the database
- **THEN** the system MUST send a message with `type: 'ACTUALITZAR_SALES'` and the list of waiting games to all connected clients

### Requirement: Broadcast Room Detail Updates
The system MUST broadcast the updated room state to all connected WebSocket clients whenever a player joins, leaves, or changes their ready status within a specific room.

#### Scenario: Update room on player join
- **WHEN** a player successfully joins a room and the state is saved to the database
- **THEN** the system MUST send a message with `type: 'ROOM_UPDATED'` and the updated room data to all connected clients

### Requirement: Broadcast Ready State Changes
The system MUST broadcast the updated room state when a player marks themselves as ready via a WebSocket message.

#### Scenario: Update room on ready status change
- **WHEN** a `READY` message is received via WebSocket and the player's status is updated in the database
- **THEN** the system MUST send a message with `type: 'ROOM_UPDATED'` and the updated room data to all connected clients

### Requirement: WebSocket Health Logging
The system MUST log the status of the WebSocket server instance and the number of active clients during broadcast operations to facilitate debugging.

#### Scenario: Log broadcast health
- **WHEN** a broadcast operation is initiated
- **THEN** the system MUST log `Estat wss: true/false` and the number of clients being reached
