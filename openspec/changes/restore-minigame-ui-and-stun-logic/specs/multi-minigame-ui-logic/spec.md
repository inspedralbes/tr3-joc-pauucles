## MODIFIED Requirements

### Requirement: Authoritative Combat Resolution
The system SHALL resolve combat by closing the UI and notifying the local player component of the outcome.

#### Scenario: Combat resolution with local feedback
- **WHEN** a minigame concludes
- **THEN** the system MUST deactivate the `MinijocUIManager` GameObject
- **AND** it MUST call `GuanyarMinijoc()` if the local player won
- **AND** it MUST call `PerdreMinijoc()` if the local player lost
