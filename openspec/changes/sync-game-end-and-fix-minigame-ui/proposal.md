## Why

Actualmente, el final de la partida no se sincroniza entre clientes, lo que provoca que un jugador gane pero el otro no reciba la notificación de derrota. Además, el minijuego de combate se inicia pero permanece invisible, impidiendo la interacción del usuario.

## What Changes

- **Sincronización de Fin de Partida**: `GameManager.cs` enviará un mensaje de WebSocket tipo `GAME_OVER` cuando un jugador gane.
- **Recepción de Fin de Partida**: Implementación del receptor de `GAME_OVER` para forzar el estado de derrota en el cliente remoto.
- **Visibilidad del Minijuego**: `MinijocUIManager.cs` asegurará que la raíz de la UI sea visible inmediatamente al iniciar el minijuego.

## Capabilities

### New Capabilities
- `game-over-sync`: Sincronización bidireccional del estado de finalización de partida a través de WebSockets.
- `minigame-ui-visibility`: Gestión garantizada de la visibilidad de la interfaz de usuario durante el inicio del minijuego.

### Modified Capabilities
<!-- No requirement changes to existing capabilities -->

## Impact

- `GameManager.cs`: Adición de lógica de envío y recepción de mensajes de red.
- `MinijocUIManager.cs`: Ajuste en el flujo de activación de la interfaz de usuario.
- Protocolo WebSocket: Definición del nuevo tipo de mensaje `GAME_OVER`.
