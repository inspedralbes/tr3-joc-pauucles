## MODIFIED Requirements

### Requirement: Flag Pickup on Collision
The system SHALL allow a player to pick up the flag when they collide with it, provided the flag is currently on the ground (no parent) or in fugitive state.

#### Scenario: Player picks up the flag
- **WHEN** a player collides with an object tagged "Bandera"
- **THEN** the flag's `fugint` state MUST be set to `false`
- **AND** the flag SHALL become a child of the player's transform
- **AND** the flag's `Collider2D` MUST be disabled
- **AND** the flag's `localPosition` SHALL be set to `(-0.8, 0, 0)`
