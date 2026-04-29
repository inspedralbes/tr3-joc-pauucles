## ADDED Requirements

### Requirement: Sentinel Z-Coordinate Signaling
The system SHALL use a specific sentinel value (999.0f) in the Z coordinate of position updates to signal minigame victory to opponents.

#### Scenario: Victorious player signal
- **WHEN** a local player is declared the winner of a minigame
- **THEN** the system MUST set the local player's Z coordinate to 999.0f
- **AND** it MUST broadcast this value through the movement synchronization channel

#### Scenario: Remote player defeat detection
- **WHEN** a position update is received for a remote player with a Z coordinate equal to 999.0f
- **THEN** the local system MUST interpret this as a local defeat
- **AND** it MUST immediately close any active minigame UI
- **AND** it MUST apply the "Defeat" penalty (Stun) to the local player
- **AND** it MUST reset the remote player's Z coordinate to 0.0f locally
