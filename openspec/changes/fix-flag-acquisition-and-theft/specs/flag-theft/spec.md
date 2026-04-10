## ADDED Requirements

### Requirement: Flag Theft on Minigame Victory
The system SHALL transfer the flag from the loser to the winner of a minigame if the loser was carrying it.

#### Scenario: Winner steals the flag
- **WHEN** a minigame result is processed
- **AND** the loser player is the current parent of the flag
- **THEN** the flag SHALL become a child of the winner player's transform
- **AND** the flag's `localPosition` SHALL be set to `(-0.8, 0, 0)`
