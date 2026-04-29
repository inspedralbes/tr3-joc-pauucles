## ADDED Requirements

### Requirement: UI Component Persistence
The `MinijocUIManager` SHALL NOT deactivate the `UIDocument` component or the `GameObject` during the hiding process.

#### Scenario: Persistent UI hiding
- **WHEN** the `HideUI()` method is called
- **THEN** the system SHALL NOT call `gameObject.SetActive(false)`
- **THEN** the system SHALL NOT set `_uiDocument.enabled = false`
- **THEN** the system SHALL call `AmagarTotsElsContenidors()` to handle visibility

### Requirement: Robust Visibility Reset
The `AmagarTotsElsContenidors()` method SHALL ensure all known minigame containers are hidden using `DisplayStyle.None`.

#### Scenario: Clean UI state
- **WHEN** `AmagarTotsElsContenidors()` is executed
- **THEN** all `VisualElement` references for minigame containers SHALL have their `style.display` property set to `DisplayStyle.None`
- **THEN** the UI arrel (rootVisualElement) SHALL remain active and accessible
