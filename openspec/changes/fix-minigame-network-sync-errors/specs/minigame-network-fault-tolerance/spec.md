## ADDED Requirements

### Requirement: Mandatory Network Interface Methods
The system SHALL ensure that all minigame logic components implement the methods required by the `MinijocUIManager` to handle networked events.

#### Scenario: Rival wins a minigame
- **WHEN** the `RebreResultatXarxa` method is called with a "RIVAL_WIN" parameter
- **AND** the minigame is currently active
- **THEN** the system MUST set the local game state to inactive
- **AND** it MUST trigger the local loss resolution logic
- **AND** it MUST close the minigame UI

### Requirement: Consistent State Management
The system SHALL maintain a clear and consistently named state variable across all minigame logic scripts to track whether the minigame is active.

#### Scenario: Variable naming consistency
- **WHEN** checking for the current game state in logic scripts
- **THEN** the system MUST use the variable `jocActiu` (or its designated internal equivalent) without causing unresolved symbol errors.
