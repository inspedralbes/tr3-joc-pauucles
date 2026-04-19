## ADDED Requirements

### Requirement: Minigame Timer Logic
The system SHALL implement a countdown timer for minigames that limits the time a player has to respond.

#### Scenario: Timer expiration
- **WHEN** the 5-second countdown reaches zero
- **THEN** the minigame is considered lost and `playerLocal.PerdreMinijoc()` is called

#### Scenario: Timer active
- **WHEN** the minigame starts
- **THEN** the timer starts at 5 seconds and decreases in real-time
