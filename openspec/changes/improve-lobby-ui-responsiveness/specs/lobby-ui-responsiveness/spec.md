## ADDED Requirements

### Requirement: Responsive Lobby UI
The Lobby UI containers MUST be responsive to different screen resolutions and window sizes.

#### Scenario: Display on large screens
- **WHEN** the application window width is greater than 750px
- **THEN** the main UI containers (Login, Lobby, PopUp, Waiting Room) SHALL have a maximum width of 600px.

#### Scenario: Display on small screens
- **WHEN** the application window width is less than 750px
- **THEN** the main UI containers SHALL occupy 80% of the screen width.

### Requirement: Room Code Identifier
The waiting room UI MUST have a dedicated label for the room code that is easily accessible by scripts.

#### Scenario: Room code label identification
- **WHEN** querying the UI hierarchy for "codeLabel"
- **THEN** the system SHALL return the Label element intended to display the room code in the "pantallaSalaEspera" section.

### Requirement: Improved Readability
UI text elements, especially buttons and informational labels, MUST have a font size sufficient for readability in standalone builds.

#### Scenario: Button font size check
- **WHEN** inspecting the UI styles for buttons in the menu
- **THEN** the font size SHALL be at least 16px.
