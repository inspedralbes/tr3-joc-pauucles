## Context

El agente `CyborgIA` debe evolucionar de un movimiento simple en 2D a un comportamiento de plataformas que incluya gravedad activa y saltos. Se requiere integración con el sistema de animaciones para mejorar la representación visual durante el entrenamiento y ejecución.

## Goals / Non-Goals

**Goals:**
- Implementar movimiento horizontal con preservación de la velocidad vertical (gravedad).
- Añadir la capacidad de salto cuando se detecta contacto con el suelo (simulando detección simple de `linearVelocity.y`).
- Vincular parámetros del `Animator` ("Speed", "Jump") con las acciones del agente.

**Non-Goals:**
- No se implementarán sistemas complejos de `Grounded` mediante raycasts (se usará una aproximación por velocidad por simplicidad).
- No se modificarán las animaciones existentes en Unity, solo se llamarán desde el código.

## Decisions

- **Acciones Discretas (3 estados):**
  - 1: Izquierda (moveX = -1)
  - 2: Derecha (moveX = 1)
  - 3: Salto (activar fuerza vertical si la velocidad Y es cercana a cero)
- **Física de Salto:** Se usará `rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse)` para asegurar una respuesta instantánea.
- **Detección de Suelo:** Por simplicidad, se considerará que el agente está en el suelo si `Mathf.Abs(rb.linearVelocity.y) < 0.05f`.
- **Animator:** Se usará `anim.SetFloat("Speed", Mathf.Abs(moveX))` para controlar la animación de caminar/correr y `anim.SetTrigger("Jump")` para la animación de salto.

## Risks / Trade-offs

- **[Riesgo] Detección de suelo por velocidad:** Si el agente está en el punto más alto de un salto, la velocidad Y será cercana a cero, permitiendo un "doble salto" infinito.
  - **Mitigación:** Es un comportamiento aceptable para prototipos de entrenamiento básicos, si causa problemas se requerirá un flag de `isGrounded` más robusto.
- **[Riesgo] Nombres de parámetros en Animator:** Si el Animator de Unity usa nombres distintos a "Speed" o "Jump", el código no funcionará visualmente.
  - **Mitigación:** Asegurar la consistencia de nombres en el editor de Unity.
