## ADDED Requirements

### Requirement: Envío de Notificación de Fin de Partida
El sistema SHALL enviar un mensaje WebSocket de tipo `GAME_OVER` cuando el jugador local gane la partida.

#### Scenario: Jugador Local Gana
- **WHEN** Se llama a `FinalitzarPartida(true)`
- **THEN** El sistema envía un mensaje JSON al servidor con `{ "type": "GAME_OVER", "victory": false }` para el otro jugador

### Requirement: Recepción de Notificación de Fin de Partida
El sistema SHALL reaccionar a mensajes entrantes de tipo `GAME_OVER` ejecutando la lógica de derrota.

#### Scenario: Jugador Remoto Gana
- **WHEN** Se recibe un mensaje WebSocket con `type: "GAME_OVER"`
- **THEN** El sistema llama a `FinalitzarPartida(false)` en el cliente local
