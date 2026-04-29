## ADDED Requirements

### Requirement: Velocity-Based Position Prediction
The system MUST calculate the predicted position of remote players using their last received velocity and the time elapsed since the last packet was received.

#### Scenario: Remote player movement prediction
- **WHEN** a packet is received with position (10, 0) and velocity (5, 0)
- **THEN** after 50ms, the system SHALL predict the player position to be at (10.25, 0)

### Requirement: Position Error Correction (Snap/Lerp)
The system MUST smoothly interpolate the remote player's visual representation towards the predicted position, and perform a hard "snap" if the divergence exceeds 4 units.

#### Scenario: Smooth correction of prediction error
- **WHEN** a new real position is received that differs slightly from the predicted position
- **THEN** the system SHALL use linear interpolation to converge the visual position to the real position over a maximum of 100ms

#### Scenario: Hard snap on major divergence
- **WHEN** a new real position is received that is more than 4 units away from the current visual position
- **THEN** the system SHALL immediately teleport the remote player to the real position to avoid excessive desync
