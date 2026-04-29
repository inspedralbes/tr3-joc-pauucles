## ADDED Requirements

### Requirement: Combat Movement Restriction
The system SHALL ensure that when two players are involved in a combat minigame, their movement is disabled until the confrontation is resolved.

#### Scenario: Combat start movement freeze
- **WHEN** two players collide and trigger the PPTLLS minigame
- **THEN** both players' `potMoure` property SHALL be set to `false`
- **THEN** the players SHALL remain stationary at their current positions

#### Scenario: Combat resolution movement restoration
- **WHEN** the PPTLLS confrontation is resolved with a winner and a loser
- **THEN** both players' `potMoure` property SHALL be restored to `true`
