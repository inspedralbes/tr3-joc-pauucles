## ADDED Requirements

### Requirement: Validación de Identidad en Castigo
El sistema SHALL validar la identidad del jugador local contra el perdedor especificado por la red antes de aplicar penalizaciones.

#### Scenario: Castigo segmentado
- **WHEN** se recibe un resultado de combate con un `loserUsername`
- **THEN** el sistema SHALL ejecutar la lógica de derrota únicamente si el nombre de usuario local coincide con `loserUsername`.

### Requirement: Sincronización de Empates
El sistema SHALL manejar el estado de empate de forma simétrica para todos los participantes.

#### Scenario: Manejo de Empat
- **WHEN** el resultado recibido es "Empat"
- **THEN** el sistema SHALL restaurar el movimiento de todos los participantes involucrados sin aplicar daño ni stun.
