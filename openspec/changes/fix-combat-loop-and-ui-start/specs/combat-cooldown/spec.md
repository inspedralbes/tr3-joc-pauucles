## ADDED Requirements

### Requirement: Combat Availability Control
The system SHALL maintain a `potCombatre` flag for each player to control their availability for minigame enfrontaments.

#### Scenario: Default combat availability
- **WHEN** a player is initialized
- **THEN** their `potCombatre` flag SHALL be set to `true`

### Requirement: Combat Cooldown Mechanism
The system SHALL implement a 4-second cooldown period after a combat is finished during which the player cannot enter another combat.

#### Scenario: Combat finishes triggers cooldown
- **WHEN** `FinalitzarCombat()` is called on a player
- **THEN** their `potCombatre` flag SHALL be set to `false`
- **THEN** their movement (`potMoure`) SHALL be restored to `true`
- **THEN** after 4 seconds, their `potCombatre` flag SHALL be set back to `true`

### Requirement: Collision-based Combat Trigger
The system SHALL only trigger a combat minigame if both colliding players are available for combat.

#### Scenario: Collision with available players
- **WHEN** two players collide
- **THEN** the system SHALL check if both players have `potCombatre == true`
- **THEN** the combat SHALL only start if the condition is met
