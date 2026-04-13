## ADDED Requirements

### Requirement: Lobby Close Transition
The system MUST allow the user to return to the login screen from the lobby.

#### Scenario: User clicks close button
- **WHEN** user clicks `btnTancarLobby`
- **THEN** system MUST hide `pantallaLobby` and MUST show `pantallaLogin`

### Requirement: Room Creation Initiation
The system SHOULD signal when a room creation process has started.

#### Scenario: User clicks create button
- **WHEN** user clicks `btnCrearPartida`
- **THEN** system MUST log `Iniciant creació de sala...` to the console

### Requirement: Room Joining Initiation
The system SHOULD signal when a room joining attempt has started.

#### Scenario: User clicks join button
- **WHEN** user clicks `btnUnirsePartida`
- **THEN** system MUST log `Intentant unir-se a la sala seleccionada...` to the console

### Requirement: Login Transition
The system MUST maintain the ability to transition from login to lobby.

#### Scenario: User clicks login button
- **WHEN** user clicks `btnLogin` with a valid name
- **THEN** system MUST hide `pantallaLogin` and MUST show `pantallaLobby`
