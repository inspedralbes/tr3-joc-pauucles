## MODIFIED Requirements

### Requirement: Detecció i recollida de la bandera amb fills
El sistema HA DE permetre la detecció de la bandera fins i tot si el collider que rep l'esdeveniment és un objecte fill del Prefab principal, i HA DE gestionar la ignorància de col·lisions per a tots els seus components físics.

#### Scenario: Recollida mitjançant Hitbox (Fill)
- **WHEN** El jugador col·lideix amb un Trigger que té el tag "Bandera".
- **THEN** El sistema HA DE buscar el component `Bandera` en els pares de la col·lisió i iniciar el procés de recollida.

#### Scenario: Ignorància de col·lisions recursiva
- **WHEN** El jugador recull la bandera.
- **THEN** El sistema HA D'ignorar la col·lisió amb TOTS els colliders trobats en la bandera i els seus fills.
