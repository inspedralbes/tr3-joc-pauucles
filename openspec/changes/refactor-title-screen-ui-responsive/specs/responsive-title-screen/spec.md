## ADDED Requirements

### Requirement: Responsive Title Layout
The system SHALL use a Flexbox-based layout for the title screen (`#PantallaTitol`) to ensure content is centered across various screen resolutions and aspect ratios.

#### Scenario: Content centering on resolution change
- **WHEN** the game window resolution or aspect ratio is modified
- **THEN** the main content container SHALL remain perfectly centered within the screen boundaries.

### Requirement: Fixed Aspect Ratio Content Frame
The system SHALL utilize a designated container (`#CapsaMaquina`) with a fixed size of 800x600px to house title screen elements, using appropriate scaling modes to fit the screen.

#### Scenario: Aspect ratio preservation
- **WHEN** the window is resized
- **THEN** the `#CapsaMaquina` container SHALL scale to fit the available space while maintaining its internal layout and centered position.

### Requirement: Transparent Action Buttons
The system SHALL implement action buttons (`btnStartGame`, `btnExitGame`) that are visually integrated into the background by being transparent and borderless.

#### Scenario: Button visual style
- **WHEN** the title screen is rendered
- **THEN** the buttons SHALL not display default solid backgrounds or borders, showing only their labels and background images if assigned.
