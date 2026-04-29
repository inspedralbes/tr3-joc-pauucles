## MODIFIED Requirements

### Requirement: Combat Triggering
The system SHALL trigger a minigame when two opposing players collide, passing explicit references of both participants to the UI manager.

#### Scenario: Combat initiation with dual references
- **WHEN** a collision occurs between two players of different teams
- **THEN** the system MUST identify both the initiator and the target
- **AND** it MUST pass both `Player` references to the `IniciarMinijoc` method
