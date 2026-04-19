## ADDED Requirements

### Requirement: Filtratge de col·lisions per equip
El sistema de banderes SHALL ignorar les interaccions de col·lisió si el jugador pertany al mateix equip que la bandera.

#### Scenario: Jugador de l'equip A xoca amb la seva pròpia bandera
- **WHEN** Un jugador de l'equip A entra en el trigger de la bandera de l'equip A.
- **THEN** El sistema no inicia cap procés de captura ni minijoc.

#### Scenario: Jugador de l'equip B xoca amb la bandera de l'equip A
- **WHEN** Un jugador de l'equip B entra en el trigger de la bandera de l'equip A.
- **THEN** El sistema inicia el procés de captura o minijoc corresponent.
