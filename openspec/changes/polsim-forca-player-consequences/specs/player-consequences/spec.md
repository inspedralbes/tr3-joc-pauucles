## ADDED Requirements

### Requirement: Apply Player Consequences
The `MinijocPolsimForcaLogic` MUST apply winning and losing consequences to the players when the minigame finishes with a winner.

#### Scenario: Jugador 1 wins
- **WHEN** `puntuacioJ1 > 50` and the minigame ends
- **THEN** the system SHALL call `p1.WinCombat()` and `p2.LoseCombat()`

#### Scenario: Jugador 2 wins
- **WHEN** `puntuacioJ2 > 50` and the minigame ends
- **THEN** the system SHALL call `p2.WinCombat()` and `p1.LoseCombat()`
