## ADDED Requirements

### Requirement: AturaBarra Arrow Movement
The system SHALL move the "Fletxa" element horizontally across the "FonsBarra" continuously using a Ping-Pong pattern.

#### Scenario: Continuous arrow movement
- **WHEN** the "AturaBarra" minigame is active
- **THEN** the system SHALL update the `style.left` property of the `Fletxa` from 0 to 490px in a Ping-Pong loop
- **THEN** the movement SHALL stop when "BtnAturar" is clicked

### Requirement: AturaBarra Scoring and Resolution
The system SHALL calculate a score based on the arrow's proximity to the center (250px) and compare it against a rival's score.

#### Scenario: Score calculation and resolution
- **WHEN** the user clicks "BtnAturar"
- **THEN** the system SHALL calculate the distance between the current arrow position and 250px
- **THEN** the system SHALL generate a score based on this distance
- **THEN** the system SHALL generate a random rival score
- **THEN** the system SHALL display the results in `TextResultat`
- **THEN** the system SHALL resolve the winner and close the UI after 2.5 seconds
