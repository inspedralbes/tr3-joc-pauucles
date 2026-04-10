## ADDED Requirements

### Requirement: Space Key Interaction for AturaBarra
The `MinijocUIManager` SHALL detect the Space key press to trigger the same logic as "BtnAturar" when the AturaBarra minigame is active.

#### Scenario: User stops arrow with space
- **WHEN** the AturaBarra minigame is active
- **AND** the user presses the `KeyCode.Space`
- **THEN** the system SHALL stop the arrow movement and resolve the combat as if "BtnAturar" was clicked
