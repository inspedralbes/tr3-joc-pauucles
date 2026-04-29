## MODIFIED Requirements

### Requirement: Global Keyboard Interaction
The `MinijocUIManager` SHALL detect keyboard inputs to provide an alternative interaction method for all active minigames.

#### Scenario: Input detection in Update
- **WHEN** any minigame interface is active
- **THEN** the system SHALL monitor for navigation keys (W/S/Arrows) and action keys (Space/Enter)
- **THEN** it SHALL delegate the interaction to the specific minigame logic based on the input detected
