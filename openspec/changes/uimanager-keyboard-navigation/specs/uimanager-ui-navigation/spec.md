## ADDED Requirements

### Requirement: Keyboard-driven Selection Index
The `MinijocUIManager` SHALL maintain a selection index to track the currently focused button in the active minigame container.

#### Scenario: Selection index reset
- **WHEN** a new minigame is displayed via `ShowUI()`
- **THEN** the selection index SHALL be reset to 0 (the first available button)

### Requirement: Directional Menu Navigation
The system SHALL allow the user to navigate through minigame buttons using directional keyboard inputs.

#### Scenario: Navigation with W/S or Arrows
- **WHEN** a minigame container is active (PPTLLS or ParellsSenars)
- **AND** the user presses W, S, ArrowUp, or ArrowDown
- **THEN** the selection index SHALL increment or decrement accordingly, wrapping around if necessary
- **THEN** the system SHALL update the visual focus of the buttons

### Requirement: Visual Focus Indication
The system SHALL provide visual feedback to indicate which button is currently selected via the keyboard.

#### Scenario: Update button background
- **WHEN** the selection index changes
- **THEN** the button corresponding to the index SHALL have its `backgroundColor` changed to a highlighted state (e.g., light gray)
- **THEN** all other buttons in the same container SHALL be restored to their default background state

### Requirement: Selection Confirmation
The system SHALL allow the user to confirm their selection using the Space or Enter keys.

#### Scenario: Confirm selection
- **WHEN** a button is focused
- **AND** the user presses `KeyCode.Space` or `KeyCode.Return`
- **THEN** the system SHALL trigger the click logic associated with that button
