## ADDED Requirements

### Requirement: Deterministic Index Selection
The system SHALL independently select the same minigame index on both participating clients during a collision event without network handshakes.

#### Scenario: Simultaneous minigame choice
- **WHEN** Player A and Player B collide
- **THEN** the system MUST generate a shared key using the sorted usernames of both players
- **AND** it MUST increment a synchronized combat counter
- **AND** it MUST calculate the game index using the hash code of the key and counter
- **AND** both clients MUST arrive at the exact same index result

### Requirement: Collision Cooldown Protection
The system SHALL implement a temporal cooldown for minigame triggers to prevent physics-induced desynchronization.

#### Scenario: Rapid collision jitter
- **WHEN** a collision is detected within 3 seconds of the previous successful trigger
- **THEN** the system MUST ignore the event and NOT increment the combat counter
