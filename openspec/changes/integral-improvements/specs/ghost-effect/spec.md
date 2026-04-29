## ADDED Requirements

### Requirement: Ghost Effect During Defeat
The system SHALL set the player's `Collider2D` to `isTrigger = true` while the defeat penalty is active.

#### Scenario: Player becomes ghost on defeat
- **WHEN** `AplicarCastigDerrota()` is called on a player
- **THEN** the system SHALL set their `Collider2D.isTrigger` to `true`
- **THEN** the system SHALL restore `isTrigger` to `false` once the penalty duration ends
