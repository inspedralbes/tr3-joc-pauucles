## ADDED Requirements

### Requirement: Automatic UI Event Rebinding
The system SHALL automatically re-discover and re-bind UI event listeners when the main menu scene is loaded.

#### Scenario: Re-entering the menu
- **WHEN** the `MenuPrincipal` scene is loaded
- **THEN** the `MenuManager` re-fetches references to buttons (`btnCrearPartida`, `btnUnirsePartida`, etc.) and attaches click events.

### Requirement: Default Lobby Display
The system SHALL ensure the Lobby screen is the default active panel when returning from a match.

#### Scenario: Navigating back to lobby
- **WHEN** the user returns to the menu after an authenticated session
- **THEN** the `#pantallaLobby` is displayed and other secondary panels are hidden.
