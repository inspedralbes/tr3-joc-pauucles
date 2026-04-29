## ADDED Requirements

### Requirement: Integritat estructural de la classe MinijocUIManager
El sistema HA D'assegurar que la classe `MinijocUIManager` està correctament tancada i lliure de fragments de codi truncats al final del fitxer.

#### Scenario: Tancament correcte de la classe
- **WHEN** El mètode `HideUI` s'ha tancat.
- **THEN** S'afegeix una clau de tancament per a la classe i s'elimina qualsevol caràcter posterior.

### Requirement: Eliminació de residus sintàctics
El sistema HA D'eliminar els fragments de codi que es troben fora de l'abast de la classe (errors CS0116, CS1022, CS8803).

#### Scenario: Absència de text fora de la classe
- **WHEN** La classe `MinijocUIManager` es tanca.
- **THEN** No ha de quedar cap caràcter imprimible després de la clau de tancament final, excepte línies en blanc opcionals.
