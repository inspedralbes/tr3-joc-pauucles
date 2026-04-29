## MODIFIED Requirements

### Requirement: Delayed UI Feedback
The system SHALL display the combat result in a `Label` named `TextResultat` using player names and wait 2.5 seconds before hiding the UI.

#### Scenario: Visual feedback after combat with names
- **WHEN** any minigame is resolved
- **THEN** the system SHALL update the `TextResultat` label with the winner's name and the reason
- **THEN** the system SHALL start a 2.5-second delay
- **THEN** after the delay, the system SHALL call `HideUI()` and apply the combat consequences (rewards/penalties)
