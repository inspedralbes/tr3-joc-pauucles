## MODIFIED Requirements

### Requirement: Flag Release on Minigame Loss
The system SHALL release the flag from the loser and initiate its fugitive state instead of direct theft.

#### Scenario: Loser releases fugitive flag
- **WHEN** a minigame result is processed
- **AND** the loser player is the current parent of the flag
- **THEN** the flag MUST be detached from the loser (`SetParent(null)`)
- **AND** the flag's `fugint` state MUST be set to `true`
- **AND** the winner SHALL NOT automatically receive the flag
