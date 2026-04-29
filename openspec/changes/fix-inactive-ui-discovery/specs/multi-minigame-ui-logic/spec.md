## MODIFIED Requirements

### Requirement: Selective Minigame Container Activation
The system SHALL only display the container corresponding to the currently active minigame, ensuring all other containers are explicitly hidden.

#### Scenario: Combat start with container reset
- **WHEN** `IniciarMinijoc` is called
- **THEN** the system MUST first hide all potential containers (`ContenidorPPTLLS`, `ContenidorParellsSenars`, `ContenidorAturaBarra`, `ContenidorPolsForca`, `ContenidorAcaparamentMirades`)
- **AND** it MUST set the selected minigame container to visible (`DisplayStyle.Flex`)

### Requirement: Participant Movement Control
The system SHALL exclusively lock the movement of the two players involved in the combat.

#### Scenario: Locking participants
- **WHEN** combat begins
- **THEN** the system MUST obtain the `Player` components from the provided GameObjects
- **AND** it MUST set their `potMoure` flag to `false`
