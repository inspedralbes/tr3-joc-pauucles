## ADDED Requirements

### Requirement: Player Name Usage in Results
The system SHALL use the GameObject names of the players instead of generic identifiers in the result messages.

#### Scenario: Display Winner Name
- **WHEN** a combat minigame is resolved with a winner
- **THEN** the system SHALL include the `name` property of the winning player in the "TextResultat" message (e.g., "[PlayerName] ha guanyat!")
