## ADDED Requirements

### Requirement: Unified Networking Messages
The system SHALL support universal WebSocket messages for minigame synchronization, including `MINIJOC_UPDATE` for continuous data and `MINIJOC_RESULT` for termination outcomes.

#### Scenario: Sending an update
- **WHEN** a minigame logic script needs to synchronize state (score, choice)
- **THEN** it SHALL call the `EnviarMinijocUpdate` method with a JSON payload
- **AND** the message MUST be broadcasted to other participants in the room

#### Scenario: Receiving a result
- **WHEN** a `MINIJOC_RESULT` message is received from a rival
- **THEN** the local minigame MUST terminate immediately
- **AND** the rival MUST be declared the winner

### Requirement: State-Specific Synchronization
The system SHALL implement specific synchronization patterns based on the active minigame category.

#### Scenario: Continuous score syncing
- **WHEN** the active minigame is "Polsim de Força"
- **THEN** every score change MUST be synchronized via `MINIJOC_UPDATE`
- **AND** both clients MUST reflect the combined state

#### Scenario: Discrete choice resolution
- **WHEN** the active minigame is "PPTLLS" (Rock-Paper-Scissors)
- **THEN** choices MUST be hidden until both players have submitted via `MINIJOC_UPDATE`
- **AND** resolution SHALL only occur once both data points are available locally
