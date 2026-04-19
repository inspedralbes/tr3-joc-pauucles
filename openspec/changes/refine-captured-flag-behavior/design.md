## Context

El script `Bandera.cs` ya gestiona la captura mediante re-parentesco jerárquico. Actualmente, se ha implementado una detección básica de movimiento, pero carece de sincronización de orientación con el jugador y de un posicionamiento lateral dinámico que haga que la bandera se comporte como una mascota que sigue al jugador.

## Goals / Non-Goals

**Goals:**
- Sincronizar el `flipX` de la bandera con el del jugador.
- Implementar un posicionamiento lateral reactivo basado en la orientación.
- Mejorar la precisión de la detección de movimiento (umbral 0.002f).
- Mantener la bandera a ras de suelo (`Y = 0`).

**Non-Goals:**
- No se modificará la lógica de red ni de sincronización entre clientes.
- No se cambiarán los prefabs ni los recursos de animación.

## Decisions

- **Referencia a SpriteRenderer**: Se añadirá `private SpriteRenderer mySprite;` para evitar llamadas repetidas a `GetComponent` en el `Update`.
- **Sincronización Parent-Child**: Dado que la bandera es hija del jugador al ser capturada, se accederá al `SpriteRenderer` del padre mediante `transform.parent.GetComponentInChildren<SpriteRenderer>()`. Esto es robusto incluso si los visuales del jugador están en un objeto hijo.
- **Posicionamiento Ternario**: Se usará la lógica `mySprite.flipX ? 0.5f : -0.5f` para determinar el desplazamiento lateral, asegurando que la mascota siempre se sitúe "detrás" o a un lado natural del jugador según hacia dónde mire.
- **Detección de Movimiento por Delta**: Se mantiene el enfoque reactivo basado en la distancia entre frames para que la animación dependa del movimiento real del objeto en el mundo.

## Risks / Trade-offs

- **[Riesgo] Ausencia de SpriteRenderer en el padre** → **[Mitigación]** Añadir comprobación `if (parentSprite != null)` antes de intentar copiar el valor de `flipX`.
- **[Riesgo] Fluctuaciones de posición local** → **[Mitigación]** Al establecer `localPosition` cada frame, se anula cualquier desplazamiento acumulado por físicas, asegurando una posición visualmente estable.
