## ADDED Requirements

### Requirement: Placeholder Score-based Resolution
The system SHALL resolve the "AturaBarra" minigame by comparing random scores for local testing.

#### Scenario: AturaBarra score resolution
- **WHEN** the user clicks "BtnAturar"
- **THEN** the system SHALL generate random integers for both players
- **THEN** the player with the higher score SHALL be declared the winner
- **THEN** the system SHALL call `ProcessarResultatCombat()` with the results
