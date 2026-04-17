## ADDED Requirements

### Requirement: Screen Transition on Login Success
The system SHALL transition the UI from the Login screen to the Lobby screen when a login request is successful.

#### Scenario: Successful Login Transition
- **WHEN** a POST request to `/login` returns a success result
- **THEN** the system SHALL set `pantallaLogin.style.display` to `DisplayStyle.None`
- **AND** the system SHALL set `pantallaLobby.style.display` to `DisplayStyle.Flex`
