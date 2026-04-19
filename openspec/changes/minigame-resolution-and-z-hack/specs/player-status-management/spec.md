## MODIFIED Requirements

### Requirement: Temporary Stun Effect
The system SHALL support a temporary immobilization effect (Stun) that prevents the player from moving for a specified duration.

#### Scenario: Losing a minigame triggers stun
- **WHEN** the player is declared the loser of a minigame (locally or via Z-Hack signal)
- **THEN** the system MUST set the `potMoure` flag to `false`
- **AND** it MUST automatically restore `potMoure` to `true` after 3 seconds
