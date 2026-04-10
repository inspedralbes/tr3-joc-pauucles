## ADDED Requirements

### Requirement: Flag Transfer on Combat Victory
The system SHALL allow a winning player to take the flag from a losing player if the latter was carrying it.

#### Scenario: Winner steals flag
- **WHEN** a combat confrontation is resolved
- **AND** the loser was carrying the flag
- **THEN** the flag SHALL be detached from the loser
- **THEN** the flag SHALL be attached to the winner
- **THEN** the loser's flag reference SHALL be cleared
