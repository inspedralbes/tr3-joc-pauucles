## ADDED Requirements

### Requirement: Structured UI Initialization
The system SHALL follow a strict sequence of "Hide All -> Show Active" for minigame UI management to prevent visual artifacts.

#### Scenario: Switching minigames
- **WHEN** the minigame manager switches between different minigames
- **THEN** it MUST ensure the root element's state is reset before activating the new minigame container
