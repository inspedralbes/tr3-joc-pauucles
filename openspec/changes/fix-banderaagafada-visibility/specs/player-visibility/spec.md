## ADDED Requirements

### Requirement: Player flag visibility
The `Player` class SHALL expose the `banderaAgafada` variable publicly so that other systems can query the flag possession state.

#### Scenario: Querying flag state during combat initialization
- **WHEN** combat initiates and `MinijocUIManager` accesses `player.banderaAgafada`
- **THEN** it successfully retrieves the `Transform` reference without protection level errors.
