## MODIFIED Requirements

### Requirement: Match Conclusion
The game foundation MUST handle match conclusion by notifying the server and providing UI feedback to all participants.

#### Scenario: Match finish sequence
- **WHEN** the flag is captured by the local player
- **THEN** the local client MUST send a `GAME_OVER` signal with the correct `roomId` and display the local victory screen, while remote clients display the defeat screen.
