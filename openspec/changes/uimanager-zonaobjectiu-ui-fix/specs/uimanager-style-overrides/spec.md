## ADDED Requirements

### Requirement: Manual Style Overrides for Goal Zone
The `MinijocUIManager` SHALL manually override the styles of the `ZonaObjectiu` element via code to ensure its visibility and correct layout.

#### Scenario: Style override execution
- **WHEN** the "AturaBarra" minigame is initialized
- **THEN** the system SHALL set `zonaObjectiu.style.width` to 80 pixels
- **THEN** the system SHALL set `zonaObjectiu.style.height` to 50 pixels
- **THEN** the system SHALL set `zonaObjectiu.style.backgroundColor` to yellow
- **THEN** the system SHALL set `zonaObjectiu.style.display` to `DisplayStyle.Flex`
- **THEN** the system SHALL set `zonaObjectiu.style.position` to `Position.Absolute`
- **THEN** the system SHALL set `zonaObjectiu.style.top` to 0
