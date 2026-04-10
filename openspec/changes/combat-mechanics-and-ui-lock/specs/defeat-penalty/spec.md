## ADDED Requirements

### Requirement: Immobile Penalty for Loser
The system SHALL penalize the losing player of a combat minigame by disabling their movement for a significant duration.

#### Scenario: Loser becomes immobile
- **WHEN** a player loses a combat minigame
- **THEN** their `potMoure` property SHALL be set to `false`
- **THEN** they SHALL remain immobile for a duration defined by the defeat penalty logic (e.g., until respawn or a long cooldown)
- **THEN** their combat cooldown SHALL be initiated
