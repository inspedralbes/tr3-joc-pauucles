## ADDED Requirements

### Requirement: Evitar procesamiento de colisiones post-captura
El sistema SHALL detener el procesamiento de colisiones en el componente `Bandera.cs` una vez que la bandera ha sido capturada por un jugador (es decir, cuando tiene un objeto padre).

#### Scenario: Colisión redundante después de captura
- **WHEN** la bandera ya tiene un objeto padre (jugador) y entra en contacto con otro trigger
- **THEN** el método `OnTriggerEnter2D` debe retornar inmediatamente sin ejecutar lógica adicional

### Requirement: Mantener autonomía de movimiento del jugador
El sistema MUST permitir que el jugador continúe moviéndose libremente después de capturar la bandera, sin bloquear su variable de estado de movimiento.

#### Scenario: Captura exitosa de bandera
- **WHEN** un jugador captura la bandera
- **THEN** la variable `potMoure` del jugador no debe cambiar su valor a `false`

### Requirement: Captura instantánea sin minijuegos
El sistema SHALL realizar la captura de la bandera de forma puramente jerárquica y visual, eliminando cualquier invocación a interfaces de minijuegos durante este proceso.

#### Scenario: Activación de captura
- **WHEN** un jugador de un equipo contrario colisiona con la bandera
- **THEN** la bandera se vincula al jugador como objeto hijo y no se muestra ninguna UI de minijuego
