## ADDED Requirements

### Requirement: Random Target Zone Positioning
The system SHALL position the "ZonaObjectiu" element at a random horizontal location within the bar at the start of Minigame 3.

#### Scenario: Goal zone initialization
- **WHEN** the AturaBarra minigame starts
- **THEN** the system SHALL set the `style.left` property of "ZonaObjectiu" to a random value between 10 and 400 pixels

### Requirement: Accuracy-based Winner Determination
The system SHALL determine the winner based on whether the arrow is inside the goal zone when the player stops it.

#### Scenario: Player stops arrow inside zone
- **WHEN** the user clicks "BtnAturar"
- **AND** the current `left` position of the arrow is greater than or equal to the zone's `left` position
- **AND** the current `left` position of the arrow is less than or equal to the zone's `left` position plus its width
- **THEN** Jugador 1 SHALL be declared the winner
- **THEN** the system SHALL display the victory in "TextResultat"

#### Scenario: Player stops arrow outside zone
- **WHEN** the user clicks "BtnAturar"
- **AND** the arrow position is outside the defined zone boundaries
- **THEN** the opponent SHALL be declared the winner
- **THEN** the system SHALL display the failure in "TextResultat"
