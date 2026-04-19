## ADDED Requirements

### Requirement: Temporary Stun Effect
The system SHALL support a temporary immobilization effect (Stun) that prevents the player from moving for a specified duration.

#### Scenario: Losing a minigame triggers stun
- **WHEN** the player is declared the loser of a minigame
- **THEN** the system MUST set the `potMoure` flag to `false`
- **AND** it MUST automatically restore `potMoure` to `true` after 3 seconds

### Requirement: Movement Restoration on Victory
The system SHALL ensure that winning a minigame immediately validates the player's mobile state.

#### Scenario: Winning a minigame restores mobility
- **WHEN** the player is declared the winner of a minigame
- **THEN** the system MUST set the `potMoure` flag to `true`
