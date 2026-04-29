## ADDED Requirements

### Requirement: Diagnostic Logging for Flag Collisions
The system SHALL log detailed information when a player collides with a flag to facilitate debugging of capture logic.

#### Scenario: Collision Log Output
- **WHEN** a player object enters the trigger zone of a flag
- **THEN** the system MUST log a message containing the player's team and the flag's owner team to the console

### Requirement: Team-Based Flag Capture
The system SHALL only allow a player to capture (start following) a flag if the player belongs to a different team than the flag's owner.

#### Scenario: Successful Capture
- **WHEN** a player from "EquipA" collides with a flag owned by "EquipB"
- **THEN** the flag MUST start following the player

#### Scenario: Prevent Self-Capture
- **WHEN** a player from "EquipA" collides with a flag owned by "EquipA"
- **THEN** the flag SHALL NOT follow the player

### Requirement: Synchronized Team Identification
The system SHALL use a consistent team identification format (e.g., "A" or "EquipA") across player instantiation and flag initialization.

#### Scenario: Matching Team Formats
- **WHEN** flags are instantiated in `InstanciarBanderes()`
- **THEN** their `equipPropietari` MUST match the string format used for `jugadorEquip` on the player objects
