## ADDED Requirements

### Requirement: User Login and Persistence
The system MUST allow a user to enter their name and save it locally for future sessions. The transition to the lobby MUST only occur if a name is provided.

#### Scenario: Successful Login
- **WHEN** the user enters a non-empty name in `inputNomJugador` and clicks `btnLogin`
- **THEN** the system MUST save the name to `PlayerPrefs` with the key `nomJugador`, hide `pantallaLogin`, and show `pantallaLobby`

### Requirement: Lobby Navigation
The system MUST allow the user to return to the login screen from the lobby.

#### Scenario: Returning to Login
- **WHEN** the user clicks `btnTancarLobby` while in the lobby
- **THEN** the system MUST hide `pantallaLobby` and show `pantallaLogin`

### Requirement: Game Management Placeholders
The system SHOULD provide placeholders for creating and joining games to verify event detection.

#### Scenario: Create Game Detection
- **WHEN** the user clicks `btnCrearPartida`
- **THEN** the system MUST log a message to the console to confirm detection

#### Scenario: Join Game Detection
- **WHEN** the user clicks `btnUnirsePartida`
- **THEN** the system MUST log a message to the console to confirm detection
