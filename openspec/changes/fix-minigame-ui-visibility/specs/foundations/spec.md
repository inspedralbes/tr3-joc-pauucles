## ADDED Requirements

### Requirement: Standardized UI Lifecycle Management
The application SHALL follow a standardized lifecycle for transient UI elements, ensuring they are explicitly shown before interaction and hidden after use.

#### Scenario: UI lifecycle enforcement
- **WHEN** a transient UI element (like a minigame) is requested
- **THEN** its root visibility must be explicitly managed by its corresponding manager script.

### Requirement: Debug Feedback for UI State
All major UI state transitions SHALL be accompanied by diagnostic logs.

#### Scenario: Diagnostic logging
- **WHEN** a UI root visibility state changes
- **THEN** a log entry must be generated to assist in runtime verification.
