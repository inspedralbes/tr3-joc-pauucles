## Context

Actualmente, el sistema utiliza minijuegos para casi todas las interacciones importantes con la bandera. Sin embargo, la entrega de la bandera enemiga en la propia base debería marcar el fin de la partida. El `GameManager` ya gestiona aspectos globales de la partida pero carece de un flujo de terminación.

## Goals / Non-Goals

**Goals:**
- Implementar una transición fluida desde la entrega de la bandera hasta el fin de la partida.
- Proporcionar feedback visual inmediato (Victoria/Derrota).
- Detener el gameplay de forma segura.

**Non-Goals:**
- Implementar la lógica de red para sincronizar el fin de partida en este paso (se deja como TODO).
- Modificar el sistema de puntuación o recompensas.

## Decisions

- **Finalización Centralizada**: Se utilizará `GameManager.Instance.FinalitzarPartida(bool)` como único punto de entrada para terminar el juego. Esto permite escalar la lógica de fin de partida en un solo lugar.
- **Búsqueda de UI por Nombre**: Debido a que las pantallas pueden estar inactivas, se buscarán mediante `Resources.FindObjectsOfTypeAll` o buscando por nombre dentro de los objetos hijos de un Canvas, para asegurar que se encuentran incluso si no están activos al inicio.
- **Bloqueo de Movimiento Global**: Al terminar, se recorrerán todos los objetos con el componente `Player` para establecer `potMoure = false`.

## Risks / Trade-offs

- [Riesgo] → Si no se encuentran los objetos `PantallaVictoria` o `PantallaDerrota`, el juego podría quedar en un estado "congelado" sin feedback.
- [Mitigación] → Se añadirán logs de error descriptivos y comprobaciones de nulidad antes de intentar activar los objetos.
- [Riesgo] → Desincronización en red (un jugador ve victoria y otro sigue jugando).
- [Mitigación] → Se añade un TODO explícito para emitir el evento `GAME_OVER` vía WebSockets.
