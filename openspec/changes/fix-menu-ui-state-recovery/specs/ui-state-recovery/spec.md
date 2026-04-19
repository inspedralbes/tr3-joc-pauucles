## ADDED Requirements

### Requirement: Automatic UI State Restoration
The menu system SHALL automatically restore the correct UI screen (Login or Lobby) based on the user's existing authentication data upon scene loading.

#### Scenario: Restoring Lobby for logged-in user
- **WHEN** the "MenuPrincipal" scene is loaded and the `userId` is not empty
- **THEN** the `#pantallaLobby` is set to `DisplayStyle.Flex` and `#pantallaLogin` is set to `DisplayStyle.None`

#### Scenario: Defaulting to Login for unauthenticated user
- **WHEN** the "MenuPrincipal" scene is loaded and the `userId` is empty
- **THEN** the `#pantallaLogin` is set to `DisplayStyle.Flex` and `#pantallaLobby` is set to `DisplayStyle.None`

### Requirement: Secondary Panel Reset
The system MUST ensure that all secondary or transient UI panels are hidden by default when the menu scene is loaded.

#### Scenario: Hiding secondary panels on load
- **WHEN** the "MenuPrincipal" scene is initialized
- **THEN** the panels `#popUpCrearSala`, `#pantallaSalaEspera`, and `#pantallaInventari` are explicitly set to `DisplayStyle.None`
