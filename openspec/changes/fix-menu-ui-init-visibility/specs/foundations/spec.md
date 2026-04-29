## MODIFIED Requirements

### Requirement: Menu state management on reentry
The game foundations MUST include a mechanism to restore the correct UI state (Login vs. Lobby) when transitioning between game and menu scenes within the same execution session.

#### Scenario: Game session persistence
- **WHEN** the scene changes from "Bosque" back to "MenuPrincipal"
- **THEN** the `MenuManager` uses its persistent state to select the appropriate UI panel to display.
