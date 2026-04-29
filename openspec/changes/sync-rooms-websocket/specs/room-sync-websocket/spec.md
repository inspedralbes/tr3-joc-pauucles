## ADDED Requirements

### Requirement: Real-time room list update
The system SHALL update the lobby room list automatically whenever a WebSocket message of type "room_list" is received.

#### Scenario: Successful room list update
- **WHEN** a WebSocket message with `{"type": "room_list", "games": [...]}` is received
- **THEN** the `llistaPartides` ListView MUST be updated with the new data on the main thread.

### Requirement: Main thread safety
The system SHALL ensure that all UI updates triggered by WebSocket messages are executed on Unity's main thread.

#### Scenario: Dispatching to main thread
- **WHEN** a WebSocket message is processed
- **THEN** any call to UI Toolkit elements MUST be wrapped in `EnqueueMainThread`.

### Requirement: Robust JSON parsing
The system SHALL handle malformed or unexpected JSON message structures without crashing.

#### Scenario: Malformed JSON received
- **WHEN** an invalid JSON string is received via WebSocket
- **THEN** the system MUST log an error and remain operational.
