## MODIFIED Requirements

### Requirement: Accés a dades de la sala
El `MenuManager` SHALL exposar de forma pública les dades completes de la sala actual per ser consultades per altres components.

#### Scenario: Consulta de colors des de GameManager
- **WHEN** El `GameManager` necessita saber els colors dels equips.
- **THEN** Pot accedir a `MenuManager.Instance.currentRoomData.teamAColor` i `teamBColor`.
