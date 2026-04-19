## ADDED Requirements

### Requirement: Immediate UI State Transition
The system MUST transition the UI from the Login state to the Lobby state immediately upon receipt of a successful authentication response.

#### Scenario: Successful Login
- **WHEN** the server returns a successful login response
- **THEN** the system MUST hide the `#pantallaLogin` and show the `#pantallaLobby` without delay.

### Requirement: Transition Diagnostic
The system SHALL provide diagnostic feedback to confirm the UI state change after authentication.

#### Scenario: Transition logging
- **WHEN** the UI state changes to Lobby after a successful login
- **THEN** the system MUST emit a `Debug.Log` message indicating the change.
