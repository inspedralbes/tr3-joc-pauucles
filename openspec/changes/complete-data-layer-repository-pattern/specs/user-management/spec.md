## ADDED Requirements

### Requirement: Player statistics tracking
The system SHALL track player statistics including total games played, total wins, and total losses.

#### Scenario: Update user stats on match finish
- **WHEN** a match is completed and a user participates
- **THEN** the system SHALL increment the user's `gamesPlayed` and update `wins` or `losses` as appropriate
