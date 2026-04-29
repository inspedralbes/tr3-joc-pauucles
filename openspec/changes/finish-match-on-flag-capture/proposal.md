## Why

Actualmente, cuando un jugador llega a su base con la bandera enemiga, se inicia un minijuego genérico. Este cambio busca implementar una lógica de finalización de partida real, mostrando pantallas de victoria o derrota y deteniendo el juego, lo que proporciona una conclusión clara a la experiencia de juego.

## What Changes

- **Lógica de Captura en Player.cs**: Se reemplaza la activación del minijuego por una llamada a la finalización de la partida en el `GameManager`.
- **Nuevo Método en GameManager.cs**: Se implementa `FinalitzarPartida(bool victoria)` para gestionar el estado final del juego.
- **Control de Movimiento**: Al finalizar la partida, se bloquea el movimiento de todos los jugadores locales.
- **Interfaz de Usuario de Fin de Juego**: Se implementa la búsqueda y activación de los objetos `PantallaVictoria` y `PantallaDerrota` en la escena.

## Capabilities

### New Capabilities
- `game-termination-logic`: Implementación del flujo de fin de partida, incluyendo estados de victoria/derrota y control de UI.

### Modified Capabilities
- Ninguna.

## Impact

- `Player.cs`: Cambio en la respuesta al entregar la bandera en la base.
- `GameManager.cs`: Adición de lógica centralizada para el fin de la partida.
- UI: Requisito de tener objetos `PantallaVictoria` y `PantallaDerrota` (aunque estén inactivos) en la escena.
