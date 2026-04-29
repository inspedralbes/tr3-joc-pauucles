## Context

El sistema de juego requiere una sincronización estricta del fin de partida y una interfaz de usuario fiable para los minijuegos. Actualmente, el flujo de red para el fin de partida es inexistente, y la UI de los minijuegos presenta problemas de visibilidad inicial.

## Goals / Non-Goals

**Goals:**
- Implementar el envío del mensaje `GAME_OVER` desde el ganador al perdedor.
- Implementar la recepción de `GAME_OVER` para disparar la pantalla de derrota localmente.
- Asegurar que el `Background` y los contenedores de los minijuegos en `MinijocUIManager` se activen correctamente al inicio.

**Non-Goals:**
- No se modificará el servidor de WebSockets, solo el cliente Unity.
- No se cambiarán las reglas de victoria/derrota, solo su comunicación.

## Decisions

- **Protocolo de Red**: Se utilizará una estructura JSON para el mensaje `GAME_OVER`.
  ```json
  { "type": "GAME_OVER", "victory": false }
  ```
- **Integración en GameManager**: `FinalitzarPartida` será el punto central para el envío. La recepción se integrará en el bucle de mensajes de `WebSocketClient` o se delegará desde allí al `GameManager`.
- **Visibilidad de UI**: En `MinijocUIManager.ShowUI`, se asegurará de activar el `_backgroundOverlay` antes de entrar en el `switch` de minijuegos.

## Risks / Trade-offs

- **[Risk]** Pérdida de paquetes WebSocket.
  - **Mitigation** El protocolo TCP subyacente de WebSockets garantiza la entrega, pero se registrará en consola para depuración.
- **[Risk]** Doble llamada a `FinalitzarPartida`.
  - **Mitigation** Añadir un flag `isGameOver` en `GameManager` para evitar procesar el fin de partida más de una vez.
