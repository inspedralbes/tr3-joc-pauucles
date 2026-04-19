## ADDED Requirements

### Requirement: Local Victory Trigger
The system SHALL ensure that only the local player instance can trigger the victory sequence (capturing the flag and ending the match).

#### Scenario: Remote player collides with base
- **WHEN** a remote player (enemy clone) enters the base trigger
- **THEN** the system MUST NOT trigger the victory UI or send the game-over broadcast on the local client.

#### Scenario: Local player collides with base
- **WHEN** the local player enters the base trigger with the flag
- **THEN** the system MUST trigger the victory UI and broadcast the game-over event.
