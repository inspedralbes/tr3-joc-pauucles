## ADDED Requirements

### Requirement: Reliable UI Toolkit Navigation
The "Back to Menu" button in the end-game screen MUST be correctly registered to its click handler to allow users to exit the match.

#### Scenario: User clicks back to menu
- **WHEN** the match is over and the end-game screen is displayed
- **THEN** clicking any button with the name "BotoTornar" MUST trigger the `TornarAlMenu` logic and navigate the user back to the main menu scene.
