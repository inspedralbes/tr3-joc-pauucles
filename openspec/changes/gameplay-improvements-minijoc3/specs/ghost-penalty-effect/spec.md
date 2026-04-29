## ADDED Requirements

### Requirement: Trigger State on Defeat
The system SHALL change the player's collider to a trigger state while they are under the defeat penalty to allow others to pass through.

#### Scenario: Loser becomes ghost
- **WHEN** a player receives the defeat penalty via `AplicarCastigDerrota()`
- **THEN** their `Collider2D` SHALL have `isTrigger` set to `true`
- **THEN** when the penalty duration ends, `isTrigger` SHALL be restored to `false`
