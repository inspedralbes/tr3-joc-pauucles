## ADDED Requirements

### Requirement: Recolección Segura de Observaciones
El sistema SHALL garantizar que la recolección de observaciones de la IA no falle ante la ausencia de objetos físicos en la escena.

#### Scenario: Objetivo en posesión de un jugador
- **WHEN** un jugador rival tiene la bandera (`isCarryingDino` o equivalente)
- **THEN** la IA SHALL incluir la posición de dicho jugador en su vector de observaciones.

#### Scenario: Objetivo ausente o nulo
- **WHEN** el objeto bandera/dinosaurio de suelo es nulo o no está instanciado
- **THEN** la IA SHALL realizar un null-check y, en caso de fallo absoluto, SHALL enviar `Vector3.zero` como observación para evitar excepciones.

### Requirement: Prevención de Estado IDLE Infinito
El sistema SHALL asegurar que la IA intente retomar su comportamiento de búsqueda incluso después de un error de sensor.

#### Scenario: Recuperación tras null-check
- **WHEN** el sensor detecta un objeto nulo y aplica el fallback
- **THEN** el componente `Agent` SHALL continuar procesando el modelo de decisión sin bloquear el hilo principal ni entrar en un estado de pausa permanente.
