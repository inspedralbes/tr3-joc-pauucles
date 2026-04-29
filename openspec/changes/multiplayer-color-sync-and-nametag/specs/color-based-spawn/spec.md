## ADDED Requirements

### Requirement: Selecció de prefab per color
El `GameManager` SHALL instanciar el prefab de jugador que correspongui al color assignat al seu equip a la sala actual.

#### Scenario: Spawn de jugador vermell
- **WHEN** Un jugador de l'equip A té assignat el color "rojo" (o vermell).
- **THEN** El sistema instancia el `prefabVermell` configurat al `GameManager`.

#### Scenario: Spawn de jugador verd
- **WHEN** Un jugador té assignat el color "verde" (o verd).
- **THEN** El sistema instancia el `prefabVerd`.
