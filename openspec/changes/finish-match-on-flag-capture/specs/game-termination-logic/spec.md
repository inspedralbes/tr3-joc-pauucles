## ADDED Requirements

### Requirement: Disparador de Fin de Partida
El sistema SHALL activar el flujo de fin de partida cuando un jugador con una bandera capturada entra en su propia base.

#### Scenario: Entrega de bandera en base propia
- **WHEN** el jugador entra en el trigger de su base teniendo `banderaAgafada != null`
- **THEN** se debe llamar a `GameManager.Instance.FinalitzarPartida(true)`

### Requirement: Bloqueo de Gameplay
Al finalizar la partida, el sistema MUST impedir cualquier movimiento o acción adicional de los jugadores locales.

#### Scenario: Partida finalizada
- **WHEN** `FinalitzarPartida` es invocado
- **THEN** todos los jugadores en la escena deben tener su variable `potMoure` establecida en `false`

### Requirement: Feedback de Resultado
El sistema SHALL mostrar la pantalla correspondiente al resultado de la partida (Victoria o Derrota).

#### Scenario: Victoria local
- **WHEN** `FinalitzarPartida(true)` es invocado
- **THEN** el objeto `PantallaVictoria` debe activarse y `PantallaDerrota` debe permanecer inactivo

#### Scenario: Derrota local
- **WHEN** `FinalitzarPartida(false)` es invocado
- **THEN** el objeto `PantallaDerrota` debe activarse y `PantallaVictoria` debe permanecer inactivo
