## ADDED Requirements

### Requirement: Refresc de la Llista de Partides
El sistema HA DE refrescar la llista de partides visibles al lobby immediatament després de crear-ne una de nova.

#### Scenario: Refresc automàtic
- **WHEN** s'ha confirmat la creació d'una sala amb èxit.
- **THEN** el sistema HA DE llançar la corrutina `ObtenirPartides()`.

### Requirement: Neteja de la Llista Prèvia
El mètode d'obtenció de partides HA DE garantir que la llista visual es neteja o actualitza correctament sense duplicats ni dades obsoletes.

#### Scenario: Actualització del ListView
- **WHEN** s'executa `ObtenirPartides`.
- **THEN** el `ListView` `llistaPartides` s'HA D'actualitzar amb el nou `itemsSource` obtingut del backend.
