## ADDED Requirements

### Requirement: Full User data storage
The system SHALL store comprehensive user data including username, password, coins, skins, games played, wins, and losses.

#### Scenario: Register new user with default stats
- **WHEN** a user is registered with valid credentials
- **THEN** the system SHALL initialize coins to 0, skins to ['base'], gamesPlayed to 0, wins to 0, and losses to 0
