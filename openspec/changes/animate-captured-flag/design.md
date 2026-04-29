## Context

Actualmente, el script `Bandera.cs` maneja la lógica de captura mediante el re-parentesco jerárquico (`transform.SetParent`). Sin embargo, carece de una actualización visual que refleje el movimiento cuando el jugador la transporta. El Animator de la bandera ya existe pero no se activa durante este estado.

## Goals / Non-Goals

**Goals:**
- Implementar una detección de movimiento desacoplada de la lógica del jugador.
- Activar la animación de "caminar" (`isWalking`) de forma reactiva al desplazamiento físico.
- Asegurar que la lógica sea eficiente y no interfiera con otros estados de la bandera.

**Non-Goals:**
- No se modificará la lógica de colisión ni de captura.
- No se alterará el comportamiento de retorno a la base (`Update` actual para `fugint`).

## Decisions

- **Detección de Movimiento por Delta de Posición**: En lugar de preguntar al jugador si se está moviendo, la bandera calculará su propio desplazamiento en el mundo. Esto es más robusto y funciona independientemente de quién o qué la mueva.
- **Filtrado por Jerarquía**: La lógica de animación reactiva solo se ejecutará si `transform.parent != null`, indicando que está siendo portada.
- **Umbral de Distancia**: Se utilizará un umbral de `0.001f` para la comparación de distancia para evitar "flickering" o activaciones por errores de precisión de punto flotante.
- **Actualización en Update**: Se utilizará el método `Update` estándar de Unity para garantizar que la animación sea fluida y esté sincronizada con el renderizado.

## Risks / Trade-offs

- **[Riesgo] Componente Animator nulo** → **[Mitigación]** Realizar una comprobación `if (anim != null)` antes de cada llamada a `SetBool`.
- **[Riesgo] Rendimiento por cálculos constantes** → **[Mitigación]** Los cálculos de distancia son extremadamente ligeros; sin embargo, el filtrado por `parent != null` asegura que solo se procesen cuando sea necesario.
