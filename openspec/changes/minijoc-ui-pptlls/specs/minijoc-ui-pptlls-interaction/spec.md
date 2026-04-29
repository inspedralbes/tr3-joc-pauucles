## ADDED Requirements

### Requirement: PPTLLS UI Activation
The system SHALL activate the PPTLLS UI for exactly two players when they collide, ensuring no global game pause occurs.

#### Scenario: Collision triggers UI
- **WHEN** two players collide
- **THEN** the `UIDocument` for PPTLLS SHALL be enabled for those players
- **THEN** the background SHALL be semi-transparent black
- **THEN** both players' `potMoure` property SHALL be set to `false`

### Requirement: PPTLLS UI Button Mapping
The `MinijocUIManager.cs` SHALL dynamically find and map the five required action buttons in the UI Toolkit document.

#### Scenario: UI Button Search
- **WHEN** the `MinijocUIManager` is initialized
- **THEN** it SHALL find buttons named "BtnPedra", "BtnPaper", "BtnTisora", "BtnLlangardaix", and "BtnSpock"
- **THEN** it SHALL register click events for each button to trigger the `MinijocPPTLLS.cs` logic

### Requirement: PPTLLS Combat Resolution Flow
The system SHALL process the combat results using `MinijocPPTLLS.cs` and handle outcomes accordingly.

#### Scenario: Combat Tie
- **WHEN** both players select options that result in a tie
- **THEN** the UI SHALL remain active
- **THEN** the players SHALL be prompted to select again

#### Scenario: Combat Victory/Loss
- **WHEN** a player wins the confrontation
- **THEN** the UI SHALL be closed for both players
- **THEN** the winner SHALL receive the `GuanyaCombat()` consequence
- **THEN** the loser SHALL receive the `PerdCombat()` consequence
- **THEN** both players' `potMoure` property SHALL be restored to `true`
