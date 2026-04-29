## ADDED Requirements

### Requirement: Team Victory Determination
The system SHALL determine the victory or defeat of the local player based on their team's affiliation rather than just their individual username when a `GAME_OVER` message is received.

#### Scenario: Teammate wins the match
- **WHEN** a `GAME_OVER` message is received with a `winner` username
- **AND** the `winner` belongs to the same team as the local player
- **THEN** the system SHALL call `FinalitzarPartida(true)`

#### Scenario: Opponent wins the match
- **WHEN** a `GAME_OVER` message is received with a `winner` username
- **AND** the `winner` belongs to a different team than the local player
- **THEN** the system SHALL call `FinalitzarPartida(false)`
