## ADDED Requirements

### Requirement: Immediate Draw Retry
The system SHALL allow players to retry their selection immediately if a combat minigame results in a draw, without closing the UI.

#### Scenario: PPTLLS Draw
- **WHEN** the PPTLLS minigame results in a draw
- **THEN** the system SHALL display "Empat! Torneu a triar!" in the "TextResultat" label
- **THEN** the selection variables SHALL be reset to `null`
- **THEN** the minigame UI SHALL remain open and active for a new selection
