## ADDED Requirements

### Requirement: Networked Game Termination
The game foundation SHALL support networked termination where one client's victory state is synchronized with others' defeat states.

#### Scenario: Synchronized match end
- **WHEN** one player captures the flag and wins
- **THEN** all other players in the session are notified and their game sessions end simultaneously
