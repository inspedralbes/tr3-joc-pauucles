## ADDED Requirements

### Requirement: Flag Pickup on Collision
The system SHALL allow a player to pick up the flag when they collide with it, provided the flag is currently on the ground (no parent).

#### Scenario: Player picks up the flag
- **WHEN** a player collides with an object tagged "Bandera"
- **THEN** the flag SHALL become a child of the player's transform
- **AND** the flag's `localPosition` SHALL be set to `(-0.8, 0, 0)`
