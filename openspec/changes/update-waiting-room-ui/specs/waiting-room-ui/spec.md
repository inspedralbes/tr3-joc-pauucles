## ADDED Requirements

### Requirement: Dynamic Room Code Display
The system SHALL display the current room ID in the waiting room's code label.

#### Scenario: Successful code display
- **WHEN** the player joins or creates a room
- **THEN** the `codeLabel` element SHALL show the text "CODI: " followed by the room ID.

### Requirement: Centered Waiting Room Layout
The waiting room container MUST be centered within its parent element.

#### Scenario: Layout alignment
- **WHEN** the "pantallaSalaEspera" is active
- **THEN** it SHALL be centered horizontally and vertically using a column-based flex layout.

### Requirement: Stable Action Buttons
The "INVENTARI" and "LLEST" buttons MUST remain in a fixed relative position regardless of other content.

#### Scenario: Button positioning
- **WHEN** the UI is rendered
- **THEN** the action buttons SHALL be contained in a non-expanding VisualElement.
