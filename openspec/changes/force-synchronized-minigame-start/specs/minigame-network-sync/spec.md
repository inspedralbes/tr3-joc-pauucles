## MODIFIED Requirements

### Requirement: Combat Triggering
The system SHALL trigger a minigame when two opposing players collide, ensuring that both participants are synchronized using the "Combat Host" pattern.

#### Scenario: Combat initiation with Leader/Follower pattern
- **WHEN** combat begins between two players
- **THEN** the system MUST designate the player with the lexicographical smaller username as the Host
- **AND** the Host MUST determine the active minigame and broadcast it to the Follower
- **AND** the Follower MUST wait for the broadcast before initializing the minigame UI
