## MODIFIED Requirements

### Requirement: Leader Authoritative Broadcast
The system SHALL ensure only the designated leader broadcasts the minigame selection.

#### Scenario: Host initiates combat
- **WHEN** a player is designated as the Host
- **THEN** they SHALL generate a random `gameIndex`
- **AND** they MUST activate the local UI immediately
- **AND** they MUST broadcast a `MINIJOC_START` message to the rival via WebSocket

### Requirement: Client Synchronization Wait
The system SHALL force non-host players to wait for network synchronization before opening the UI.

#### Scenario: Client waits for host
- **WHEN** a player is designated as the Client
- **THEN** they MUST freeze their movement
- **AND** they MUST NOT execute any local UI discovery or initialization logic
- **AND** they MUST wait for a `MINIJOC_START` message to be processed by the network receiver
