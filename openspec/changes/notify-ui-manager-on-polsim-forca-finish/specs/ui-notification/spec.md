## ADDED Requirements

### Requirement: Notify UI Manager on Minigame End
The `MinijocPolsimForcaLogic` MUST notify the `MinijocUIManager` when the "Polsim de Força" minigame concludes.

#### Scenario: Successful notification
- **WHEN** the `FinalitzarMinijoc` method is called
- **THEN** the system SHALL call `MinijocUIManager.Instance.FinalitzarCombat(guanyador)`
