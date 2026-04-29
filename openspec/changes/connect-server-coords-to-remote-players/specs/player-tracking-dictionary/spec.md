## ADDED Requirements

### Requirement: Centrally Managed Remote Players
The system SHALL maintain a public registry of all active remote player instances to allow for rapid lookup and update during network events.

#### Scenario: Registering a Remote Player
- **WHEN** a new remote player is instantiated by the `GameManager`
- **THEN** it MUST be added to the `remotePlayers` dictionary using its `userId` (or `username`) as the key

### Requirement: Automatic Cleanup on Disconnect
The system SHOULD remove player entries from the tracking dictionary when they leave the game to prevent memory leaks and stale data.

#### Scenario: Player Leaving Room
- **WHEN** a player leaves the room (e.g., via `leave_room` message or timeout)
- **THEN** their entry MUST be removed from the `remotePlayers` dictionary
