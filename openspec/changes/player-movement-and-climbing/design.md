## Context

El script `Player.cs` actual ya cuenta con variables de movimiento y lógica de salto básica. Sin embargo, carece de la capacidad de subir escaleras y el movimiento no utiliza `Input.GetAxisRaw()`, lo cual puede generar una sensación de movimiento menos precisa. La implementación debe integrarse con el sistema de física `Rigidbody2D` existente y respetar los estados de inmovilidad (`potMoure`, `isFrozen`).

## Goals / Non-Goals

**Goals:**
- Implementar un sistema de escalado que neutralice la gravedad.
- Mejorar el feedback visual de la orientación del personaje (flip horizontal).
- Asegurar que el salto solo sea posible en condiciones controladas.

**Non-Goals:**
- No se modificará el sistema de combate ni la gestión de vidas.
- No se alterará el sistema de AFK (parpelleig), aunque se integrará con el nuevo movimiento.

## Decisions

- **Control de Gravedad**: Se usará `rb.gravityScale` para alternar entre el estado normal (1f) y el estado de escalado (0f). Esto evita que el jugador caiga mientras está en una escalera sin necesidad de fuerzas constantes.
- **Movimiento de Escalado en FixedUpdate**: Toda la manipulación directa de la velocidad del `Rigidbody2D` durante el escalado se realizará en `FixedUpdate` para garantizar la consistencia física, mientras que la detección de entrada se mantendrá en `Update`.
- **Orientación Visual**: Se modificará `transform.localScale` en lugar de `spriteRenderer.flipX` para asegurar que los objetos hijos (como la bandera o futuros nametags) también giren correctamente con el personaje.

## Risks / Trade-offs

- **[Riesgo: Atrapado en escaleras]** → Si el jugador sale de la zona de escalera lateralmente sin soltar el mando vertical, podría quedar flotando si `OnTriggerExit2D` no se dispara correctamente o si hay solapamiento. **Mitigación**: `OnTriggerExit2D` forzará siempre `escalant = false` y reseteará la gravedad.
- **[Riesgo: Salto Infinito]** → El uso de `rb.linearVelocity.y` cercano a 0 para permitir el salto podría fallar en pendientes. **Mitigación**: Se mantendrá la validación de `isGrounded` si ya existe, reforzada por la comprobación de velocidad.
