## MODIFIED Requirements

### Requirement: Internal UIDocument Initialization
The `MinijocUIManager` SHALL obtain its `UIDocument` reference internally using `GetComponent<UIDocument>()` during the `Awake` phase AND ensure the root visual element is completely hidden.

#### Scenario: Awake initialization and lock
- **WHEN** the `MinijocUIManager` is initialized in the scene
- **THEN** it SHALL call `GetComponent<UIDocument>()` to bind the reference
- **THEN** it SHALL set the `style.display` of its root element to `DisplayStyle.None` to ensure total invisibility
