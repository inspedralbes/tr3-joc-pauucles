## ADDED Requirements

### Requirement: Player Collision Logging
The system SHALL log every collision event triggered in `Player.cs` to the Unity console.

#### Scenario: Collision Event Logging
- **WHEN** a player object collides with any other object
- **THEN** the system SHALL output a log message: "He xocat contra: [Name] amb Tag: [Tag]"
- **THEN** the log message SHALL appear before any conditional logic (like tag comparisons)
