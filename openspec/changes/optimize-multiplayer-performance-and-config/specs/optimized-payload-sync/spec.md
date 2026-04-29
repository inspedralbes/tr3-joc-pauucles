## ADDED Requirements

### Requirement: Multi-tier Synchronization Protocol
The system MUST support two types of network packets: Full State (Handshake) and Delta (Movement). Full state packets MUST be sent every 2 seconds or when metadata changes.

#### Scenario: Sending a Full State Handshake
- **WHEN** a player joins a room or 2 seconds have passed since the last full update
- **THEN** the system SHALL send a packet including username, skin, team, and current position/velocity

### Requirement: Minimal Movement Delta
The movement delta packet MUST only contain position, velocity, and animation flags to minimize bandwidth usage.

#### Scenario: Efficient movement update
- **WHEN** the player is moving and a full update is not required
- **THEN** the system SHALL send a message excluding the username, skin, and team fields if the server already knows them
