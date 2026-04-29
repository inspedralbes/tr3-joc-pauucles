## ADDED Requirements

### Requirement: UI Toolkit Integration
The system SHALL use Unity UI Toolkit (`UnityEngine.UIElements`) to manage the player's HUD.

#### Scenario: UI Document reference
- **WHEN** the player is instantiated
- **THEN** it SHALL have a public reference to a `UIDocument`

### Requirement: Visual Life Tracking
The system SHALL display the player's health status using 5 visual elements named 'Vida1', 'Vida2', 'Vida3', 'Vida4', and 'Vida5'.

#### Scenario: Element discovery
- **WHEN** the game starts
- **THEN** the system SHALL search the `rootVisualElement` of the `UIDocument` for the 5 specified life elements and store them in a list or array.

### Requirement: Visual Update on Damage
The system SHALL visually hide or modify the life element corresponding to the lost life when damage occurs.

#### Scenario: Life lost
- **WHEN** the player loses a life
- **THEN** the corresponding `VisualElement` SHALL have its style set to `display = DisplayStyle.None` or its background color changed to gray.

#### Scenario: All lives lost
- **WHEN** the player reaches 0 lives
- **THEN** all 5 `VisualElement`s SHALL be hidden or grayed out.
