## MODIFIED Requirements

### Requirement: Global Container Hiding
The `MinijocUIManager` SHALL implement a method `AmagarTotsElsContenidors()` that sets `style.display = DisplayStyle.None` for all known minigame containers, including the new "AturaBarra" container.

#### Scenario: Pre-game hiding
- **WHEN** a new minigame is about to be shown
- **THEN** the system SHALL call `AmagarTotsElsContenidors()` to ensure a clean state

#### Scenario: Post-game hiding
- **WHEN** a minigame ends and the UI is hidden
- **THEN** the system SHALL call `AmagarTotsElsContenidors()` to reset visibility
