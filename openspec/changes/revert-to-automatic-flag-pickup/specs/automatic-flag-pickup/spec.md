## ADDED Requirements

### Requirement: Automatic Flag Acquisition on Trigger
The system SHALL automatically parent the flag to the player when they enter its trigger range.

#### Scenario: Contact with Flag Trigger
- **WHEN** a player's collider enters the trigger collider of an object tagged "Bandera"
- **THEN** the system SHALL set the flag as a child of the player's transform
- **AND** the flag's `localPosition` SHALL be set to `(-0.8f, 0, 0)`
- **AND** the flag's `Collider2D` SHALL be disabled
- **AND** the flag's `fugint` state SHALL be set to `false`

### Requirement: Automatic Flag Acquisition on Collision
The system SHALL automatically parent the flag to the player when they physically collide with it.

#### Scenario: Physical Contact with Flag
- **WHEN** a player's collider makes physical contact with the collider of an object tagged "Bandera"
- **THEN** the system SHALL set the flag as a child of the player's transform
- **AND** the flag's `localPosition` SHALL be set to `(-0.8f, 0, 0)`
- **AND** the flag's `Collider2D` SHALL be disabled
- **AND** the flag's `fugint` state SHALL be set to `false`
