## MODIFIED Requirements

### Requirement: AturaBarra Scoring and Resolution
The system SHALL resolve the "AturaBarra" minigame by validating the arrow's final position against the target zone.

#### Scenario: AturaBarra interactive resolution
- **WHEN** the user clicks "BtnAturar"
- **THEN** the system SHALL stop the arrow movement
- **THEN** it SHALL perform the spatial validation against "ZonaObjectiu"
- **THEN** it SHALL update "TextResultat" with the outcome
- **THEN** it SHALL wait 2.5 seconds before calling `ProcessarResultatCombat()`
