## MODIFIED Requirements

### Requirement: Combat Triggering
The system SHALL trigger a minigame when two opposing players collide, ensuring that both participants enter the minigame state at the same time using local deterministic logic.

#### Scenario: Combat initiation without network
- **WHEN** combat begins between two players
- **THEN** the system MUST NOT wait for a network message to open the UI
- **AND** it MUST NOT broadcast a startup message to the server
- **AND** it MUST proceed immediately with the determined game index
