## ADDED Requirements

### Requirement: Inicio Automático de Minijuego tras Captura
El sistema DEBE activar automáticamente la interfaz de minijuegos inmediatamente después de que un jugador capture una bandera enemiga.

#### Scenario: Disparo del minijuego
- **WHEN** el `transform.parent` de la bandera se asigna a un jugador Y se valida la captura.
- **THEN** el sistema DEBE llamar al método `ShowUI` de `MinijocUIManager.Instance`.

### Requirement: Bloqueo de Movimiento del Capturador
El sistema DEBE impedir que el jugador que ha capturado la bandera se mueva mientras el minijuego esté activo.

#### Scenario: Restricción de movimiento
- **WHEN** se inicia la lógica de integración del minijuego tras la captura.
- **THEN** la variable `potMoure` del componente `Player` del capturador DEBE establecerse en falso.

### Requirement: Paso de Referencias a la Interfaz de Minijuegos
El sistema DEBE proporcionar las referencias necesarias del jugador capturador a la interfaz de minijuegos para su correcto funcionamiento.

#### Scenario: Inicialización de UI con jugador
- **WHEN** se invoca `MinijocUIManager.Instance.ShowUI`.
- **THEN** el componente `Player` del capturador DEBE pasarse como parámetro para que la UI sepa quién está participando en el desafío.
