## MODIFIED Requirements

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
- **AND** the implementation MUST be present in all possible active minigame logic scripts
