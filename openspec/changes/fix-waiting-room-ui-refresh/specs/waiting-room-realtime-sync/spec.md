## ADDED Requirements

### Requirement: Real-time Player List Updates
The system SHALL automatically refresh the player list in the waiting room UI whenever a `ROOM_UPDATED` WebSocket message is received.

#### Scenario: Another player joins
- **WHEN** the server broadcasts a `ROOM_UPDATED` message including a new player
- **THEN** the local UI MUST immediately update its player list display to include the new player and their status.

#### Scenario: Player changes ready status
- **WHEN** a `ROOM_UPDATED` message indicates a change in a player's `isReady` state
- **THEN** the local UI MUST update the corresponding text to reflect the new status (e.g., from "(Esperant)" to "(Llest)").

### Requirement: Robust UI Component Discovery
The refresh logic SHALL dynamically find and update the UI element responsible for displaying the player list.

#### Scenario: Scene reload recovery
- **WHEN** the player returns to the waiting room scene
- **THEN** the refresh logic MUST re-fetch the latest `UIDocument` and `VisualElement` references to avoid `MissingReferenceException`.
