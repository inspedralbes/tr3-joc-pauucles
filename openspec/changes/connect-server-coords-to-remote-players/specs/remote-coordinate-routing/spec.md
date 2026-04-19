## ADDED Requirements

### Requirement: Positional Data Extraction
The system SHALL extract specific positional and identity fields from incoming `PLAYER_MOVE` messages to identify the target player and their new coordinates.

#### Scenario: Valid Message Processing
- **WHEN** a `PLAYER_MOVE` JSON message is received
- **THEN** the system MUST extract the `username` (or `userId`), `x`, and `y` coordinates

### Requirement: Targeted Positional Updates
The system SHALL route extracted coordinate data to the specific `RemotePlayer` instance identified in the message.

#### Scenario: Successful Routing
- **WHEN** a player with ID "User123" is found in the `remotePlayers` dictionary
- **THEN** the system MUST call `ActualitzarPosicioRemota(x, y)` on that instance with the new coordinates
