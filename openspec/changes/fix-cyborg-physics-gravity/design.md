## Context

El agente `CyborgIA` utiliza acciones discretas de ML-Agents para el movimiento. El sistema de físicas de Unity (Rigidbody2D) calcula la gravedad automáticamente, pero esta fuerza se pierde si el script del agente sobrescribe el vector de velocidad completo en cada paso de simulación.

## Goals / Non-Goals

**Goals:**
- Separar el control de la velocidad horizontal (proporcionada por el agente) de la velocidad vertical (influenciada por la gravedad).
- Permitir que el agente caiga de plataformas de forma natural incluso mientras se mueve hacia los lados.

**Non-Goals:**
- No se implementará salto ni propulsión vertical activa en este cambio (el eje Y es pasivo).
- No se modificarán los parámetros globales de gravedad de Unity.

## Decisions

- **Asignación de Velocidad Parcial:** Se dejará de usar `rb.linearVelocity = dir * moveSpeed;`. En su lugar, se construirá un nuevo `Vector2` donde la componente X se calcula a partir de la acción del agente y la componente Y mantiene el valor actual de `rb.linearVelocity.y`.
- **Acciones Discretas:** Las acciones 1 (Arriba) y 2 (Abajo) se mantendrán mapeadas pero no tendrán efecto vertical directo si el agente no está en un modo de vuelo/escalada, para preservar la coherencia física. El foco principal es el movimiento lateral (acciones 3 y 4).

## Risks / Trade-offs

- **[Riesgo] Falta de control vertical:** Si el agente cae, no tiene medios activos para subir de nuevo.
  - **Mitigación:** Asegurar que el entorno de entrenamiento tenga rampas o suelos continuos si se requiere navegación compleja.
- **[Riesgo] Inercia lateral:** Al usar velocidad directa en X, el movimiento es instantáneo y se detiene en seco.
  - **Mitigación:** Es el comportamiento esperado para un agente de ML-Agents básico, facilita el aprendizaje en tareas de transporte.
