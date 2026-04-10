## ADDED Requirements

### Requirement: UI Container Management
The `MinijocUIManager` SHALL toggle visibility between `ContenidorPPTLLS` and `ContenidorParellsSenars` based on the selected minigame.

#### Scenario: Selection of Parells o Senars
- **WHEN** the minigame selection roulette chooses ID 4 (Parells o Senars)
- **THEN** the system SHALL set `display: None` for `ContenidorPPTLLS`
- **THEN** the system SHALL set `display: Flex` for `ContenidorParellsSenars`
- **THEN** the system SHALL find and bind buttons `BtnParells` and `BtnSenars`

### Requirement: Button Binding for Parells o Senars
The `MinijocUIManager` SHALL find and bind the click events of buttons `BtnParells` and `BtnSenars` to the `MinijocParellsSenarsLogic.cs`.

#### Scenario: User clicks BtnParells
- **WHEN** the user clicks `BtnParells`
- **THEN** the system SHALL assign `Parells` to the current player
- **THEN** the system SHALL assign `Senars` to the other player (for local testing)
- **THEN** the system SHALL trigger the combat resolution using `MinijocParellsSenarsLogic.cs`

### Requirement: Combat Resolution Flow for Parells o Senars
The system SHALL process the combat results using `MinijocParellsSenarsLogic.cs` and handle the outcomes.

#### Scenario: Win/Loss Resolution
- **WHEN** the combat is resolved
- **THEN** the system SHALL call `WinCombat()` for the winner
- **THEN** the system SHALL call `LoseCombat()` for the loser
- **THEN** the system SHALL close the UI and restore `potMoure = true` to both players
