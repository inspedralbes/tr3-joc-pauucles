## MODIFIED Requirements

### Requirement: Combat Triggering
The system SHALL trigger a minigame when two opposing players collide, ensuring that the resulting UI and logic components are ready to receive networking hooks.

#### Scenario: Combat initiation with networking
- **WHEN** combat begins between two players
- **THEN** the `MinijocUIManager` MUST be initialized as the primary network event handler for the session
