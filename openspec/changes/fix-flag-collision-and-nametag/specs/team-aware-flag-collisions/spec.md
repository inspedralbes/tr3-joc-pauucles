## MODIFIED Requirements

### Requirement: Filtratge de col·lisions per equip
El sistema de banderes SHALL ignorar les interaccions de col·lisió si el jugador pertany al mateix equip que la bandera.

#### Scenario: Col·lisió amb bandera aliada
- **WHEN** Un jugador entra en el trigger de la bandera.
- **THEN** El sistema obté l'equip del jugador (via `NetworkSync` o `MenuManager`).
- **THEN** Si l'equip del jugador coincideix amb `equipPropietari` de la bandera, el mètode retorna immediatament sense realitzar la captura.
