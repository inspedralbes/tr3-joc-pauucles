## MODIFIED Requirements

### Requirement: Combat Triggering
The system SHALL trigger a minigame when two opposing players collide, ensuring that both participants are synchronized using the "Combat Host" pattern.

#### Scenario: Combat initiation with leader selection
- **WHEN** combat begins between two players
- **THEN** the system MUST use the lexicographical smaller username to determine the leader
- **AND** the leader SHALL dictate the active minigame to the target via a network message
