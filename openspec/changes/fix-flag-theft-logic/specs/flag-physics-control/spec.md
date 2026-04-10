## ADDED Requirements

### Requirement: Flag Physics Disable
The system SHALL disable the physical movement of the flag when it is carried by a player to ensure it follows the carrier precisely.

#### Scenario: Carrying flag physics state
- **WHEN** a player acquires the flag
- **AND** the flag has a `Rigidbody2D` component
- **THEN** the system SHALL set `isKinematic` to `true`
- **THEN** the system SHALL set `linearVelocity` to `Vector2.zero`
