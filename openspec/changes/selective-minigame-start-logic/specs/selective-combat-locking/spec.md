## ADDED Requirements

### Requirement: Targeted Movement Freeze
The system SHALL only freeze the movement of the two players involved in a combat collision. Other players SHALL remain mobile.

#### Scenario: Two players collide and start combat
- **WHEN** Player A and Player B collide and are on different teams
- **AND** a third Player C is in the vicinity
- **THEN** Player A and Player B MUST have their `potMoure` flag set to `false`
- **AND** Player C SHALL maintain their current movement status

### Requirement: Selective Movement Restoration
The system SHALL restore movement exclusively to the players who participated in the combat upon its conclusion.

#### Scenario: Combat ends
- **WHEN** the minigame between Player A and Player B concludes
- **THEN** the system MUST restore the `potMoure` flag to `true` for Player A and Player B
- **AND** the system SHALL NOT modify the movement status of any other players in the game
