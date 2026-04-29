## MODIFIED Requirements

### Requirement: Leader Authoritative Broadcast
The system SHALL ensure only the designated leader broadcasts the minigame selection.

#### Scenario: Host initiates combat
- **WHEN** a player is designated as the Host
- **THEN** they SHALL generate a random `gameIndex`
- **AND** they MUST broadcast a `MINIJOC_START` message to the rival via WebSocket
- **AND** they MUST NOT trigger local UI initialization side effects in the collision handler
