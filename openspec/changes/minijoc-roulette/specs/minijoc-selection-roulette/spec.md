## ADDED Requirements

### Requirement: Random Minigame Selection
The system SHALL select one minigame at random from the 6 available minigames when a combat confrontation starts.

#### Scenario: Selection of PPTLLS
- **WHEN** the random selection result is 1 (PPTLLS)
- **THEN** the system SHALL enable the PPTLLS UI components
- **THEN** the combat SHALL proceed according to the PPTLLS specification

#### Scenario: Selection of Unimplemented Minigame
- **WHEN** the random selection result is any value from 2 to 6
- **THEN** the system SHALL output a `Debug.Log` message indicating the name of the selected minigame
- **THEN** the system SHALL resolve the combat as a Tie (`Empat`)
- **THEN** the system SHALL close the UI and restore player movement (`potMoure = true`)
