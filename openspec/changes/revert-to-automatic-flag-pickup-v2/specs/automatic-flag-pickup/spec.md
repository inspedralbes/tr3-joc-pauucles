## ADDED Requirements

### Requirement: Recollida Automàtica via Trigger
El sistema del jugador HA DE recollir automàticament la bandera quan entri en contacte amb el seu collider configurat com a Trigger.

#### Scenario: Recollida per Trigger
- **WHEN** el collider d'un jugador entra en un collider Trigger amb el tag "Bandera"
- **THEN** la bandera HA DE ser emparentada al jugador, posicionada a `(-0.8, 0, 0)`, el seu collider HA DE ser desactivat i el seu estat `fugint` HA DE ser fixat a `false`.

### Requirement: Recollida Automàtica via Col·lisió
El sistema del jugador HA DE recollir automàticament la bandera quan col·lideixi físicament amb ella.

#### Scenario: Recollida per Col·lisió
- **WHEN** el collider d'un jugador xoca amb un collider no-trigger amb el tag "Bandera"
- **THEN** la bandera HA DE ser emparentada al jugador, posicionada a `(-0.8, 0, 0)`, el seu collider HA DE ser desactivat i el seu estat `fugint` HA DE ser fixat a `false`.

### Requirement: Eliminació de la Recollida Manual
La lògica de recollida manual (mitjançant les tecles E o RightControl) HA DE ser eliminada del sistema de control del jugador.

#### Scenario: Ignorar Tecles de Recollida
- **WHEN** un jugador prem 'E' o 'RightControl' estant a prop de la bandera
- **THEN** cap acció de recollida manual HA DE ser disparada, ja que la bandera s'hauria d'haver recollit automàticament o la lògica ja no és present.
