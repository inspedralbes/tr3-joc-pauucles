## ADDED Requirements

### Requirement: Reliable Opponent Identification
The system SHALL retrieve the opponent's unique username from a dedicated synchronization component during combat initiation.

#### Scenario: Collision with a remote player
- **WHEN** a local player collides with another player
- **THEN** the system MUST extract the `username` from the `RemotePlayer` component of the collision partner
- **AND** if the component or the username is missing, the system MUST abort the minigame initiation

### Requirement: Host Immediate Response
The system SHALL prioritize the Host's local experience by activating the UI immediately upon deterministic leadership confirmation.

#### Scenario: Host starts combat
- **WHEN** the local player is designated as the Host
- **THEN** the system MUST immediately find and activate the `MinijocUIManager`
- **AND** it MUST initialize the UI with a random `gameIndex` before broadcasting the network message
