## Why

El juego necesita un sistema de finalización de partida claro y visual para informar al jugador si ha ganado o perdido, utilizando el sistema moderno de UI Toolkit de Unity para una mejor integración y rendimiento.

## What Changes

- Implementación de la pantalla de final de partida en `GameManager.cs` utilizando UI Toolkit.
- Control de visibilidad del panel de resultados (oculto por defecto).
- Lógica para detener el movimiento del jugador al finalizar la partida.
- Personalización del mensaje de victoria o derrota.
- Funcionalidad para desconectarse y volver al menú principal.

## Capabilities

### New Capabilities
- `game-end-ui`: Gestión del estado final del juego, visualización de resultados y navegación de retorno al menú principal.

### Modified Capabilities
<!-- No se modifican requerimientos existentes de otras capacidades -->

## Impact

- `GameManager.cs`: Se añaden dependencias de UI Toolkit y SceneManagement, nuevas variables para la UI y métodos de control de fin de partida.
- Escena de Juego: Requiere un objeto `UIDocument` configurado con los elementos "BotoTornar" y "TextResultat".
