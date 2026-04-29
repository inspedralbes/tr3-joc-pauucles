## ADDED Requirements

### Requirement: Fugitive State Movement
The system SHALL move the flag towards its initial position when the `fugint` state is active.

#### Scenario: Flag flees to base
- **WHEN** the flag's `fugint` state is set to `true`
- **THEN** the flag MUST move towards its starting coordinates at a constant speed
- **AND** it SHALL continue moving until it is within a small threshold (0.1 units) of the target

### Requirement: Recovery of Interaction
The system SHALL re-enable the flag's physical interaction once it reaches its destination.

#### Scenario: Flag arrives at base
- **WHEN** the flag is within 0.1 units of its initial position
- **THEN** the `fugint` state MUST be set to `false`
- **AND** the flag's `Collider2D` MUST be enabled
