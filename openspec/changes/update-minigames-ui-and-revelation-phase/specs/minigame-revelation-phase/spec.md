## ADDED Requirements

### Requirement: Standard Revelation Phase
The system SHALL provide a mandatory 3-second delay after the minigame outcome is determined and before calling `FinalitzarCombat`.

#### Scenario: Post-game results display
- **WHEN** a minigame concludes (timer ends or winning condition is met)
- **THEN** the result label MUST display the winner or outcome for exactly 3 seconds.

#### Scenario: Delayed combat finalization
- **WHEN** the 3-second revelation timer expires
- **THEN** the system MUST call `MinijocUIManager.Instance.FinalitzarCombat`.

### Requirement: PPTLLS UI Integration
The system MUST link PPTLLS buttons and labels to the new UI structure.

#### Scenario: Button linking
- **WHEN** PPTLLS minigame starts
- **THEN** "BtnPedra", "BtnPaper", "BtnTisora", "BtnLlangardaix", and "BtnSpock" MUST be functional.

### Requirement: Parells o Senars Math Logic
The system MUST generate a sum and allow players to choose if the result is even or odd.

#### Scenario: Correct guess
- **WHEN** a player clicks "BtnParells" or "BtnSenars" and the parity matches the sum
- **THEN** that player SHALL be declared the winner.

### Requirement: Physical Draw Feedback
The system MUST apply separation force in case of a draw in Acaparament de Mirades.

#### Scenario: Draw force application
- **WHEN** the result is "Empat" in Acaparament de Mirades
- **THEN** the system MUST apply a separation force to both players after the revelation phase.
