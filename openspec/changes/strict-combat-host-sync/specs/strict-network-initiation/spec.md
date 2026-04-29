## ADDED Requirements

### Requirement: Network-Gated UI Activation
The system SHALL ensure that the minigame UI is only activated upon receiving a confirmed network message, even for the player who initiated the combat.

#### Scenario: Host waits for network reflection
- **WHEN** a player is designated as the Host
- **AND** they broadcast a `MINIJOC_START` message
- **THEN** they MUST NOT activate the local `MinijocUIManager` until the message is received back from the WebSocket server

### Requirement: Centralized Robust UI Discovery
The system SHALL use a fail-safe discovery mechanism to locate and activate the UI manager regardless of its hierarchy state.

#### Scenario: Discovering disabled UI manager
- **WHEN** a `MINIJOC_START` message is received
- **THEN** the system MUST use `Resources.FindObjectsOfTypeAll` to find the `MinijocUIManager`
- **AND** it MUST explicitly set the discovered GameObject to active
