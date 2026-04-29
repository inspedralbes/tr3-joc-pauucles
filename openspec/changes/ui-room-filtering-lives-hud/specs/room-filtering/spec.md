## ADDED Requirements

### Requirement: Filter Stale Waiting Rooms
The system SHALL filter the list of rooms received from the server to exclude any room that is in the "waiting" state and was created more than 10 minutes before the current time.

#### Scenario: Stale room is excluded
- **WHEN** the room list is received and contains a room in "waiting" state created 11 minutes ago
- **THEN** that room is not displayed in the room list UI
