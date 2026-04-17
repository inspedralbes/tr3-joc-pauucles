## ADDED Requirements

### Requirement: BoxCast Ground Detection
The system SHALL determine the grounding state using a `BoxCast` query from the player's collider bounds downwards.

#### Scenario: Detection of a solid platform
- **WHEN** a `BoxCast` is projected 0.1 units downwards from the player's bounds
- **THEN** it MUST return true if a non-trigger collider other than the player's own collider is hit

### Requirement: Exclusion of Trigger Colliders
The ground detection query MUST explicitly exclude trigger colliders from being considered "ground".

#### Scenario: Player passing through a trigger
- **WHEN** the `BoxCast` hits a collider marked as `isTrigger`
- **THEN** it MUST NOT mark the player as grounded based on that hit

### Requirement: Real-time Grounding Update
The player's `isGrounded` state SHALL be updated at the beginning of each frame's update cycle to ensure input handling uses accurate state.

#### Scenario: Continuous movement
- **WHEN** the `Update()` method starts
- **THEN** the grounding state MUST be recalculated before processing jump input or animator updates
