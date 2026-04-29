## ADDED Requirements

### Requirement: Explicit UI Activation
The system MUST set the minigame UI root to visible when a minigame instance starts.

#### Scenario: Starting a minigame
- **WHEN** the `IniciarMinijoc` method is called
- **THEN** the `UIDocument` root visual element MUST have its style display set to `Flex`.

### Requirement: Explicit UI Deactivation
The system MUST hide the minigame UI root when the minigame finishes or is manually closed.

#### Scenario: Finishing a minigame
- **WHEN** the minigame logic concludes
- **THEN** the `UIDocument` root visual element MUST have its style display set to `None`.

### Requirement: Visibility Logging
The system SHALL log the visibility state changes to the console for debugging purposes.

#### Scenario: Visibility change feedback
- **WHEN** the UI display style changes between `Flex` and `None`
- **THEN** a `Debug.Log` message MUST be emitted indicating the current state.
