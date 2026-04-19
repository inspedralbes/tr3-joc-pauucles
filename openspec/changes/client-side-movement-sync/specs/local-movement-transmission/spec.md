## ADDED Requirements

### Requirement: Throttled Movement Updates
The system SHALL only transmit player movement data over the network if a minimum time threshold has passed or if the player has moved significantly.

#### Scenario: Movement below threshold
- **WHEN** the local player moves less than 0.05 units since the last update
- **AND** the tick rate interval (e.g., 0.1s) has not yet elapsed
- **THEN** the system SHALL NOT send a `PLAYER_MOVE` message

#### Scenario: Movement above threshold
- **WHEN** the local player moves 0.05 units or more since the last update
- **THEN** the system SHALL immediately send a `PLAYER_MOVE` message and reset the tick timer

### Requirement: Full State Transmission
The system MUST include all necessary visual and physics states in the movement message to allow accurate reconstruction on remote clients.

#### Scenario: Complete Message Payload
- **WHEN** a movement update is triggered
- **THEN** the message MUST include current X/Y coordinates, horizontal flip state, animation boolean states (isRunning, isGrounded, isClimbing), and vertical velocity
