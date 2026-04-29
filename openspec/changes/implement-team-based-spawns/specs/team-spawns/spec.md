## ADDED Requirements

### Requirement: Team Spawn Identification
The system SHALL identify the correct spawn point for the local player based on the value of `WebSocketClient.Team`.

#### Scenario: Spawn for Team 1 (Red)
- **WHEN** `WebSocketClient.Team` matches "1", "A", "Rojo", or "Vermell" (case-insensitive)
- **THEN** the system SHALL select "PuntSpawn_Equip1" as the target spawn point

#### Scenario: Spawn for Team 2 (Blue)
- **WHEN** `WebSocketClient.Team` matches "2", "B", "Azul", or "Blau" (case-insensitive)
- **THEN** the system SHALL select "PuntSpawn_Equip2" as the target spawn point

### Requirement: Player Teleportation
The system SHALL teleport the local player to the identified spawn point's position upon match start.

#### Scenario: Successful teleportation
- **WHEN** the "Bosque" scene starts and a target spawn point is found
- **THEN** the local player's position SHALL be set to the target spawn point's position
- **AND** a debug message SHALL confirm the operation
