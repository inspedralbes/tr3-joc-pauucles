## ADDED Requirements

### Requirement: Unified Minigame Container Hiding
The system SHALL provide a centralized mechanism to hide all minigame UI containers to ensure a clean state before starting any specific minigame.

#### Scenario: Pre-minigame UI reset
- **WHEN** a minigame session is initialized (`IniciarMinijoc`)
- **THEN** all containers (PPTLLS, PolsForca, DuelMirades, AturaBarra, ParellsSenars) MUST be hidden (`DisplayStyle.None`)
- **AND** the root UI element MUST be set to visible (`DisplayStyle.Flex`)

### Requirement: Selective Minigame Container Activation
The system SHALL only display the container corresponding to the currently active minigame.

#### Scenario: Specific minigame activation
- **WHEN** a specific minigame is selected (e.g., PPTLLS)
- **THEN** only its specific container MUST be set to visible (`DisplayStyle.Flex`)
- **AND** all other minigame containers MUST remain hidden
