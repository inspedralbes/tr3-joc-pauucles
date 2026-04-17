## ADDED Requirements

### Requirement: Session Data Persistence
The system SHALL parse the `PARTIDA_INICIADA` message and store the `username`, `team`, and `color` in the `WebSocketClient` static fields before transitioning to the game scene.

#### Scenario: Successful data persistence
- **WHEN** a `PARTIDA_INICIADA` message is received for the local player
- **THEN** the system SHALL extract `username`, `team`, and `color`
- **AND** store them in `WebSocketClient.Username`, `WebSocketClient.Team`, and `WebSocketClient.ColorName`

### Requirement: Immediate Scene Transition
The system SHALL trigger an explicit scene load for "Bosque" immediately after hiding the lobby UI when a game starts.

#### Scenario: Reliable scene transition
- **WHEN** the `PARTIDA_INICIADA` event is processed on the main thread
- **THEN** the system SHALL hide the lobby UI
- **AND** call `SceneManager.LoadScene("Bosque")`
