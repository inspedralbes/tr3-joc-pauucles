## ADDED Requirements

### Requirement: Game Over Broadcast
The system MUST broadcast a `GAME_OVER` message to all players in a room when one player wins.

#### Scenario: Winning player notifies others
- **WHEN** a player calls `FinalitzarPartida(true)`
- **THEN** a `GAME_OVER` WebSocket message is sent to the server and broadcast to other clients

### Requirement: Game Over Reception
The system MUST handle incoming `GAME_OVER` messages by terminating the game for the receiving player as a loss.

#### Scenario: Losing player receives notification
- **WHEN** a client receives a `GAME_OVER` message where they are not the winner
- **THEN** the system calls `FinalitzarPartida(false)` to show the "GAME OVER" screen
