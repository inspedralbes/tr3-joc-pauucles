## ADDED Requirements

### Requirement: UI Button Response Validation
The system SHALL connect UI buttons to validation logic to process player input during minigames.

#### Scenario: Correct answer
- **WHEN** the player clicks the correct button (e.g., "Parell" for an even sum)
- **THEN** the minigame is won and `playerLocal.GuanyarMinijoc()` is called

#### Scenario: Incorrect answer
- **WHEN** the player clicks the incorrect button (e.g., "Senar" for an even sum)
- **THEN** the minigame is lost and `playerLocal.PerdreMinijoc()` is called

#### Scenario: Single interaction
- **WHEN** any response button is clicked
- **THEN** all subsequent interactions are ignored until the minigame is reset
