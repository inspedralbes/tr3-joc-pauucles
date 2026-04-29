## ADDED Requirements

### Requirement: Deterministic Host Selection
The system SHALL determine which player is the "Combat Host" based on lexicographical username comparison during a collision.

#### Scenario: Determining the host
- **WHEN** Player A (username "Alice") and Player B (username "Bob") collide
- **THEN** Alice MUST be designated as the Host because "Alice" < "Bob"
- **AND** Alice SHALL initiate the minigame selection
- **AND** Bob SHALL wait for Alice's network message

### Requirement: Synchronized Minigame Start
The system SHALL use a standard WebSocket message `MINIJOC_START` to synchronize the active minigame index between combat participants.

#### Scenario: Initiating synchronized combat
- **WHEN** the designated Host initiates combat
- **THEN** the Host SHALL generate a random `gameIndex`
- **AND** the Host SHALL broadcast a `MINIJOC_START` message containing the `gameIndex`, and both participants' names
- **AND** the receiving participant MUST open the minigame UI with the specified `gameIndex` upon receiving the message
