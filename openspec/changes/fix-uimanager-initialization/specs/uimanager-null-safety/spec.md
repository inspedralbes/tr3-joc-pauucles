## MODIFIED Requirements

### Requirement: Root Visual Element Safety
The `MinijocUIManager` SHALL verify that the `UIDocument` component is active and its `rootVisualElement` is not null before attempting any UQuery operation (`Q<T>`).

#### Scenario: Null Root Element or Inactive Component
- **WHEN** the `UIDocument` fails to load, is disabled, or provides a `rootVisualElement` that is null
- **THEN** the system SHALL NOT attempt to query elements
- **THEN** the system SHALL gracefully exit the UI display process without crashing
