## MODIFIED Requirements

### Requirement: Immobile Penalty for Loser
The system SHALL penalize the losing player of a combat minigame by disabling their movement and making them a ghost for a significant duration.

#### Scenario: Loser becomes immobile and ghost
- **WHEN** a player loses a combat minigame
- **THEN** their `potMoure` property SHALL be set to `false`
- **THEN** their `Collider2D.isTrigger` SHALL be set to `true`
- **THEN** they SHALL remain in this state for a duration defined by the defeat penalty logic
- **THEN** their combat cooldown SHALL be initiated
- **THEN** after the duration, `potMoure` SHALL be restored to `true` and `isTrigger` SHALL be restored to `false`
