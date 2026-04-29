## ADDED Requirements

### Requirement: Room state reset
The system SHALL provide a mechanism to explicitly clear room-specific data in the `MenuManager`.

#### Scenario: Clearing state on reentry
- **WHEN** `NetejarEstatTornada()` is called
- **THEN** the internal `currentRoomId` is set to an empty string and `currentRoomData` is set to null.

### Requirement: Post-match data hygiene
The system SHALL ensure no stale match data persists after a player exits the match.

#### Scenario: Returning from match
- **WHEN** a player clicks the return button in `GameManager`
- **THEN** the `MenuManager` state is cleared BEFORE the menu scene is loaded.
