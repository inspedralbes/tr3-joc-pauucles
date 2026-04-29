## MODIFIED Requirements

### Requirement: Random Minigame Selection
The system SHALL select one minigame at random from the 3 currently implemented minigames when a combat confrontation starts.

#### Scenario: Selection of implemented minigames
- **WHEN** a combat confrontation starts
- **THEN** the system SHALL choose a random ID between 1 and 3 (inclusive)
- **THEN** it SHALL NOT select IDs 4, 5, or 6
