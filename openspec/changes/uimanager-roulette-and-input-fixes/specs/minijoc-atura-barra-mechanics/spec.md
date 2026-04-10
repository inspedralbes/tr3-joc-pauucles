## MODIFIED Requirements

### Requirement: Random Target Zone Positioning
The system SHALL position the "ZonaObjectiu" element at a random location within the bar at the start of Minigame 3, ensuring it is vertically aligned.

#### Scenario: Goal zone initialization
- **WHEN** the AturaBarra minigame starts
- **THEN** the system SHALL set the `style.left` property of "ZonaObjectiu" to a random value between 10 and 400 pixels
- **THEN** it SHALL set the `style.top` property to 0 to ensure visibility
