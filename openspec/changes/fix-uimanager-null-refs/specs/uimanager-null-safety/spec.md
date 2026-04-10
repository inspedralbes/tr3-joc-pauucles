## ADDED Requirements

### Requirement: Root Visual Element Safety
The `MinijocUIManager` SHALL verify that the `rootVisualElement` is not null before attempting any UQuery operation (`Q<T>`).

#### Scenario: Null Root Element
- **WHEN** the `UIDocument` fails to load or provide a `rootVisualElement`
- **THEN** the system SHALL NOT attempt to query elements
- **THEN** the system SHALL gracefully exit the UI display process without crashing

### Requirement: UI Container Verification
The `MinijocUIManager` SHALL ensure that container references (`ContenidorPPTLLS`, `ContenidorParellsSenars`) are successfully obtained before attempting to access their properties (like `style.display`).

#### Scenario: Missing Containers in UXML
- **WHEN** a container name specified in the script is missing from the UXML file
- **THEN** the system SHALL verify the nullity of the reference
- **THEN** the system SHALL log an error and NOT attempt to access its style property
- **THEN** the system SHALL prevent an `ArgumentNullException` from occurring
