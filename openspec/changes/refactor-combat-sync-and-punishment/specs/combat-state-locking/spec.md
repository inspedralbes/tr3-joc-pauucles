## ADDED Requirements

### Requirement: Candado de Estado de Combate
El sistema SHALL evitar que un jugador inicie múltiples instancias de minijuegos si ya se encuentra en un estado de combate o stun.

#### Scenario: Intento de colisión múltiple
- **WHEN** un jugador entra en contacto con un enemigo Y la bandera `enCombate` es `true` O el jugador está bajo efecto de stun
- **THEN** el sistema SHALL abortar inmediatamente el procesamiento de la colisión.

### Requirement: Activación Inmediata de Estado
El sistema SHALL marcar al jugador como ocupado en el instante exacto de la detección de colisión válida.

#### Scenario: Primer contacto válido
- **WHEN** un jugador detecta una colisión con un enemigo Y supera las validaciones iniciales
- **THEN** el sistema SHALL establecer `enCombate = true` antes de disparar cualquier lógica de red o UI.
