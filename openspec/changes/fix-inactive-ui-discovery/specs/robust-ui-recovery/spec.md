## ADDED Requirements

### Requirement: Inactive Manager Discovery
The system SHALL be able to locate the `MinijocUIManager` even when its GameObject is inactive using comprehensive object search methods.

#### Scenario: Manager is found while inactive
- **WHEN** a combat collision occurs
- **AND** the `MinijocUIManager` GameObject is disabled
- **THEN** the system MUST find the manager using `Resources.FindObjectsOfTypeAll`
- **AND** it MUST set the discovered GameObject to active

### Requirement: Combat Initiation Handshake
The system SHALL pass both the local player and the opponent references to the manager to ensure synchronized movement locking.

#### Scenario: Successful combat handshake
- **WHEN** the `MinijocUIManager` is activated
- **THEN** it MUST receive the `GameObject` references of both participants
- **AND** it MUST log "[SISTEMA] UI TROBADA I ENCESA PER LA FORÇA!"
