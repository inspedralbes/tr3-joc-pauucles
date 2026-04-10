## ADDED Requirements

### Requirement: Disable Flag Collider on Acquisition
The system SHALL disable the `Collider2D` component of the flag object immediately when a player picks it up (either via collision or trigger).

#### Scenario: Player picks up flag from ground
- **WHEN** a player collides with the "Bandera" object
- **AND** the player acquires ownership (SetParent)
- **THEN** the system SHALL set `enabled = false` on the flag's `Collider2D` component

### Requirement: Enable Flag Collider on Release (Optional/Future-proofing)
Although not explicitly requested, for system integrity, the system SHOULD be capable of re-enabling the collider if the flag is ever dropped back to the ground.

#### Scenario: Flag is dropped
- **WHEN** the flag is detached from a player (parent set to null)
- **THEN** the system SHALL set `enabled = true` on the flag's `Collider2D` component
