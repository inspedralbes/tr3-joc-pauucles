## ADDED Requirements

### Requirement: Filtratge de col·lisions per equip (Restaurat)
El sistema SHALL impedir que un jugador interactuï amb una bandera que pertany al seu mateix equip.

#### Scenario: Col·lisió amb bandera aliada
- **WHEN** Un jugador col·lisiona amb una bandera on `equipPropietari` coincideix amb el seu propi equip.
- **THEN** El mètode de col·lisió de la bandera retorna immediatament sense realitzar cap acció.
