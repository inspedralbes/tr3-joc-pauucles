## Context

Actualmente, `Player.cs` utiliza `Input.GetAxisRaw("Vertical")` para detectar si el jugador quiere empezar a escalar. Una vez en estado `escalant`, la velocidad vertical depende directamente de esta entrada. El salto está desacoplado pero puede ocurrir accidentalmente si el jugador está en la base de una escalera.

## Goals / Non-Goals

**Goals:**
- Unificar la entrada de escalada para permitir el uso de la tecla de Salto (Espacio) como activador y propulsor hacia arriba.
- Evitar el salto físico (`jumpForce`) cuando el jugador está en el área de una escalera para prevenir comportamientos erráticos.
- Permitir que el jugador se quede estático en la escalera si no hay entrada de dirección, mejorando el control.

**Non-Goals:**
- No se modificará la detección de colisiones (`OnTriggerEnter2D`/`Exit2D`) que establece `tocantEscala`.
- No se cambiarán las velocidades base `moveSpeed` o `climbSpeed`.

## Decisions

### 1. Modificación de la activación en `Update`
- **Decisión**: Cambiar la condición de `escalant = true` para incluir `Input.GetButton("Jump")`.
- **Razón**: Permite una respuesta inmediata tanto a la dirección Arriba como al botón de Salto.

### 2. Restricción de salto en `Update`
- **Decisión**: Añadir `!tocantEscala` a la condición de salto.
- **Razón**: Evita que el `jumpForce` se aplique cuando el jugador está en una escalera, permitiendo que el Espacio se use exclusivamente para escalar en esa zona.

### 3. Lògica de velocidad en `FixedUpdate`
- **Decisión**: Calcular la velocidad vertical final basándose en prioridades:
  1. Si (Salto o Arriba) -> `climbSpeed`.
  2. Si (Abajo) -> `-climbSpeed`.
  3. Si nada -> `0`.
- **Razón**: Implementa el comportamiento de "parada" en la escalera, que es más intuitivo para juegos de plataformas 2D.

## Risks / Trade-offs

- **[Riesgo]**: El jugador podría sentirse "atrapado" si quiere saltar cerca de una escalera pero el sistema lo interpreta como escalada.
- **[Mitigación]**: La zona de la escalera (`ZonaEscalera`) debe estar bien ajustada visualmente para que el jugador entienda por qué no salta.
