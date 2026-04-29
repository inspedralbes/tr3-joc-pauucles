## ADDED Requirements

### Requirement: Inicialització de la UI del Cable Pelat
El sistema HA D'inicialitzar els elements del minijoc mitjançant UI Toolkit, buscant les zones d'inici, meta i perill.

#### Scenario: Inicialització amb èxit
- **WHEN** Es crida a `InicialitzarUI` amb un `VisualElement` arrel que conté `#ZonaInici`, `#ZonaMeta` i `#FonsPerill`.
- **THEN** El sistema troba els elements i registra els callbacks de `PointerEnterEvent`.

### Requirement: Control del Recorregut (Estat enCurs)
El sistema HA DE gestionar una variable d'estat `enCurs` per controlar el flux del minijoc.

#### Scenario: Inici del recorregut
- **WHEN** El punter entra a `#ZonaInici`.
- **THEN** La variable `enCurs` passa a `true` i s'emet un log de depuració.

#### Scenario: Derrota per tocar el fons
- **WHEN** El punter entra a `#FonsPerill` MENTRE `enCurs` és `true`.
- **THEN** `enCurs` passa a `false` i es notifica la derrota del jugador actual (Jugador 2 guanya).

#### Scenario: Victòria per arribar a la meta
- **WHEN** El punter entra a `#ZonaMeta` MENTRE `enCurs` és `true`.
- **THEN** `enCurs` passa a `false` i es notifica la victòria del jugador actual (Jugador 1 guanya).

#### Scenario: Ignorar col·lisions si no s'ha iniciat
- **WHEN** El punter entra a `#FonsPerill` o `#ZonaMeta` MENTRE `enCurs` és `false`.
- **THEN** No es realitza cap acció ni es finalitza el combat.
