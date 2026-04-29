## ADDED Requirements

### Requirement: Authoritative Leader Election
The system SHALL determine a single authoritative leader for minigame selection when two players collide.

#### Scenario: Determining the host
- **WHEN** two players collide and are on different teams
- **THEN** the player with the lexicographically smaller username MUST be designated as the Host
- **AND** the player with the lexicographically larger username MUST be designated as the Client

### Requirement: Leader Authoritative Broadcast
The system SHALL ensure only the designated leader broadcasts the minigame selection.

#### Scenario: Host initiates combat
- **WHEN** a player is designated as the Host
- **THEN** they SHALL generate a random `gameIndex`
- **AND** they MUST broadcast a `MINIJOC_START` message to the rival via WebSocket

### Requirement: Client Synchronization Wait
The system SHALL force non-host players to wait for network synchronization before opening the UI.

#### Scenario: Client waits for host
- **WHEN** a player is designated as the Client
- **THEN** they MUST freeze their movement
- **AND** they MUST log "Sóc client, espero la xarxa"
- **AND** they MUST NOT open the minigame UI locally until a `MINIJOC_START` message is received
