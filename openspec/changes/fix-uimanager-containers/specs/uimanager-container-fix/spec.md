## ADDED Requirements

### Requirement: Global Container Hiding
The `MinijocUIManager` SHALL implement a method `AmagarTotsElsContenidors()` that sets `style.display = DisplayStyle.None` for all known minigame containers.

#### Scenario: Pre-game hiding
- **WHEN** a new minigame is about to be shown
- **THEN** the system SHALL call `AmagarTotsElsContenidors()` to ensure a clean state

#### Scenario: Post-game hiding
- **WHEN** a minigame ends and the UI is hidden
- **THEN** the system SHALL call `AmagarTotsElsContenidors()` to reset visibility

### Requirement: Exact Container Mapping
The `MinijocUIManager` SHALL query containers using the exact names "ContenidorPPTLLS" and "ContenidorParellsSenars".

#### Scenario: Successful mapping
- **WHEN** the script initializes
- **THEN** it SHALL perform `root.Q<VisualElement>("ContenidorPPTLLS")` and `root.Q<VisualElement>("ContenidorParellsSenars")`
- **THEN** it SHALL log a descriptive error if any of these are not found

## MODIFIED Requirements

### Requirement: Roulette ID Mapping
The minigame roulette SHALL map ID 2 to the "Parells o Senars" minigame.

#### Scenario: Selection of ID 2
- **WHEN** the roulette selects ID 2
- **THEN** the system SHALL initiate the "Parells o Senars" minigame interface
- **THEN** the system SHALL NOT resolve it as a forced tie
