## ADDED Requirements

### Requirement: UI Reference Refresh
The `MenuManager` MUST refresh its `UIDocument` and `VisualElement` references every time the menu scene is loaded.

#### Scenario: Returning to menu scene
- **WHEN** the "MenuPrincipal" scene is loaded
- **THEN** the `MenuManager` MUST re-fetch the `UIDocument` component from the scene before attempting to update UI visibility.

### Requirement: Reference Guarding
The system MUST verify that UI references are non-null before performing any state updates.

#### Scenario: Missing UI Document
- **WHEN** the `UIDocument` cannot be found in the current scene
- **THEN** the system MUST log a warning and abort visibility updates to prevent a `MissingReferenceException`.
