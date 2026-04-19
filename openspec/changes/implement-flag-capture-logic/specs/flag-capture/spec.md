## ADDED Requirements

### Requirement: Enemy Flag Capture
The system SHALL detect when a player collides with a flag that does not belong to their own team and mark it as captured.

#### Scenario: Successful Enemy Capture
- **WHEN** a player with team "B" enters the trigger of a flag with `equipPropietari` = "A"
- **THEN** the flag MUST set `esCapturada` to `true` and `targetSeguiment` to the player's Transform

#### Scenario: Friendly Flag Collision
- **WHEN** a player with team "A" enters the trigger of a flag with `equipPropietari` = "A"
- **THEN** the flag SHALL NOT change its capture state
