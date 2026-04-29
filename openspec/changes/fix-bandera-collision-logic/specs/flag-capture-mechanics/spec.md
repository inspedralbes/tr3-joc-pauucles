## ADDED Requirements

### Requirement: Detección de Colisión de Bandera
La bandera DEBE detectar colisiones con objetos que tengan el tag "Player" utilizando `OnTriggerEnter2D`.

#### Scenario: Colisión con Jugador
- **WHEN** un objeto con el tag "Player" entra en el trigger de la bandera.
- **THEN** el sistema DEBE registrar un log con el nombre y tag del objeto detectado.

### Requirement: Verificación de Equipos para Captura
La bandera SOLO DEBE ser capturada si el equipo del jugador que colisiona es diferente al equipo propietario de la bandera.

#### Scenario: Jugador de Diferente Equipo
- **WHEN** un jugador de un equipo diferente al de la bandera entra en el trigger.
- **THEN** el sistema DEBE registrar los equipos de ambos y proceder con la lógica de captura.

#### Scenario: Jugador del Mismo Equipo
- **WHEN** un jugador del mismo equipo que la bandera entra en el trigger.
- **THEN** el sistema DEBE registrar los equipos pero NO DEBE proceder con la captura.

### Requirement: Mecánica de Captura (Enganche)
Al confirmarse una captura válida, la bandera DEBE convertirse en hija del objeto jugador y resetear su posición local.

#### Scenario: Enganche de Bandera al Jugador
- **WHEN** se valida que el equipo del jugador es diferente al de la bandera.
- **THEN** el `transform.parent` de la bandera DEBE asignarse al jugador, su `localPosition` DEBE establecerse en `new Vector3(-0.5f, 0.5f, 0f)` y se DEBE registrar un log de "[Bandera] CAPTURADA!".
