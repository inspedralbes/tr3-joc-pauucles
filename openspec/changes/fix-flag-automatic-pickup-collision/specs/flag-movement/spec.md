## MODIFIED Requirements

### Requirement: Recollida automàtica de la bandera sense desactivació física
El sistema HA DE garantir que la bandera, en ser recollida automàticament pel jugador, no perdi la seva capacitat de col·lisionar amb el terra per evitar caigudes del mapa.

#### Scenario: Recollida amb IgnoreCollision
- **WHEN** El jugador entra en contacte amb la bandera i s'executa `AgafarBanderaAutomàticament`.
- **THEN** El sistema HA D'ignorar la col·lisió entre el jugador i la bandera (`Physics2D.IgnoreCollision` amb `ignore = true`) i NO HA DE desactivar el collider de la bandera.
