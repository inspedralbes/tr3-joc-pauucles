## MODIFIED Requirements

### Requirement: UI Component Persistence
The `MinijocUIManager` SHALL NOT deactivate the `UIDocument` component or the `GameObject` during the hiding process AND SHALL hide the root visual element.

#### Scenario: Persistent UI hiding with root lock
- **WHEN** the `HideUI()` method is called
- **THEN** the system SHALL set the `style.display` of its root element to `DisplayStyle.None`
- **THEN** it SHALL call `AmagarTotsElsContenidors()` to ensure all sub-containers are also hidden
