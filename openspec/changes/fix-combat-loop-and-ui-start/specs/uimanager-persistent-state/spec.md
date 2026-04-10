## MODIFIED Requirements

### Requirement: UI Component Persistence
The `MinijocUIManager` SHALL NOT deactivate the `UIDocument` component or the `GameObject` during the hiding process AND SHALL delegate movement restoration to the players.

#### Scenario: Persistent UI hiding
- **WHEN** the `HideUI()` method is called
- **THEN** the system SHALL NOT call `gameObject.SetActive(false)`
- **THEN** the system SHALL NOT set `_uiDocument.enabled = false`
- **THEN** the system SHALL call `AmagarTotsElsContenidors()` to handle visibility
- **THEN** the system SHALL call `FinalitzarCombat()` on both participating players
