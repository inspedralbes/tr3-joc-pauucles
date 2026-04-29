## MODIFIED Requirements

### Requirement: Internal UIDocument Initialization
The `MinijocUIManager` SHALL obtain its `UIDocument` reference internally using `GetComponent<UIDocument>()` during the `Awake` phase AND ensure a clean initial state during `Start`.

#### Scenario: Awake initialization
- **WHEN** the `MinijocUIManager` is initialized in the scene
- **THEN** it SHALL call `GetComponent<UIDocument>()` to bind the reference
- **THEN** it SHALL ensure the reference is not null before proceeding

#### Scenario: Start clean state
- **WHEN** the `Start` method is called
- **THEN** the system SHALL call `AmagarTotsElsContenidors()` to ensure no UI elements are visible on play
