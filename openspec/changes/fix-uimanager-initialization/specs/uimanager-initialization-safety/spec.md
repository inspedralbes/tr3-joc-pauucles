## ADDED Requirements

### Requirement: Internal UIDocument Initialization
The `MinijocUIManager` SHALL obtain its `UIDocument` reference internally using `GetComponent<UIDocument>()` during the `Awake` phase.

#### Scenario: Awake initialization
- **WHEN** the `MinijocUIManager` is initialized in the scene
- **THEN** it SHALL call `GetComponent<UIDocument>()` to bind the reference
- **THEN** it SHALL ensure the reference is not null before proceeding

### Requirement: Correct Singleton Pattern
The `MinijocUIManager` SHALL implement a Singleton pattern that binds to the instance already present in the scene without creating new game objects.

#### Scenario: Instance assignment
- **WHEN** the `Awake` method is called
- **THEN** it SHALL assign `Instance = this` if no instance exists
- **THEN** it SHALL NOT instantiate new GameObjects or components

### Requirement: Active State Verification
The `MinijocUIManager` SHALL verify that its GameObject is active before attempting to access the `rootVisualElement`.

#### Scenario: Displaying UI on inactive object
- **WHEN** `ShowUI` is called
- **THEN** the system SHALL check if the GameObject is active
- **THEN** the system SHALL NOT access `rootVisualElement` if the object or component is disabled
