## ADDED Requirements

### Requirement: Networked Room Identification
The game MUST include a valid and accurate `roomId` in all `GAME_OVER` WebSocket messages to ensure the backend can correctly identify which session to terminate.

#### Scenario: Match termination broadcast
- **WHEN** the match ends and a `GAME_OVER` message is prepared
- **THEN** the system MUST retrieve the current `roomId` from the persistent `MenuManager` session data and include it in the message payload.
