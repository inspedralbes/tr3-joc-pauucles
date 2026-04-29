## MODIFIED Requirements

### Requirement: UI State Management
The system SHALL manage the global UI state such that transitions between game and menu scenes preserve session continuity and reset transient UI elements.

#### Scenario: Transition from game to menu
- **WHEN** the user returns to the menu from a match
- **THEN** the `MenuManager` initializes the UI by resetting all panels and then displaying the Lobby screen.
