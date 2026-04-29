## ADDED Requirements

### Requirement: Pointer Event Registration
The system SHALL register `PointerEnterEvent` callbacks for the following VisualElements by their IDs: `#ZonaInici`, `#ZonaMeta`, and `#FonsPerill`.

#### Scenario: Registration on Initialization
- **WHEN** `InicialitzarUI` is called with a root VisualElement
- **THEN** the system finds the elements by ID and attaches the `PointerEnterEvent` listeners

### Requirement: Start Zone Logic
The system SHALL set the `enCurs` state to `true` when the pointer enters the `#ZonaInici` element.

#### Scenario: Entering Start Zone
- **WHEN** the pointer enters `#ZonaInici`
- **THEN** `enCurs` is set to `true`

### Requirement: Victory Condition
The system SHALL conclude the combat with "Jugador 1" as the winner if the pointer enters `#ZonaMeta` while `enCurs` is `true`.

#### Scenario: Reaching Finish Zone
- **WHEN** the pointer enters `#ZonaMeta` and `enCurs` is `true`
- **THEN** `enCurs` is set to `false` and `MinijocUIManager.Instance.FinalitzarCombat("Jugador 1")` is called

### Requirement: Defeat Condition
The system SHALL conclude the combat with "Jugador 2" as the winner if the pointer enters `#FonsPerill` while `enCurs` is `true`.

#### Scenario: Touching Dangerous Background
- **WHEN** the pointer enters `#FonsPerill` and `enCurs` is `true`
- **THEN** `enCurs` is set to `false` and `MinijocUIManager.Instance.FinalitzarCombat("Jugador 2")` is called
