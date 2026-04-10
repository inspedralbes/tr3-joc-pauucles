## MODIFIED Requirements

### Requirement: Classe Principal
- **ADDED**: Integration of `IEnumerator` coroutines to manage temporary states (freeze, invulnerability).
- **ADDED**: New properties for life management (`lives`), UI reference (`livesText`), and respawn point (`respawnPoint`).
- **MODIFIED**: Movement logic SHALL respect an `isFrozen` state.

#### Scenario: Movement respects freeze
- **WHEN** the player is in an `isFrozen` state
- **THEN** input processing and movement SHALL be disabled
