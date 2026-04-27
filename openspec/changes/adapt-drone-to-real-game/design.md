## Context

El `DroneAI` actual está diseñado para entrenamiento intensivo. Para su despliegue en el juego real, debe actuar como un agente persistente que interactúa físicamente con los objetos del mundo (Dinosaurio y Jugadores) y sigue un bucle de juego basado en estados en lugar de episodios.

## Goals / Non-Goals

**Goals:**
- Convertir el agente reactivo en un bot con estado persistente (`portantDino`).
- Implementar la lógica de captura mediante jerarquía de transformaciones (`SetParent`).
- Asegurar que la red neuronal siga recibiendo las observaciones necesarias para la navegación, pero redirigidas dinámicamente.

**Non-Goals:**
- Modificar el modelo neuronal (`.onnx`).
- Alterar la lógica de `OnActionReceived` que traduce las salidas del modelo en movimiento.

## Decisions

- **Manejo del Dinosaurio**: Se utilizará `SetParent(transform)` para que el dinosaurio se mueva solidariamente con el dron. Esto simplifica enormemente la lógica de transporte al evitar tener que actualizar la posición del dinosaurio manualmente en cada frame.
- **Redirección de Objetivo**: En `GetTargetPosition()`, se insertará una condicional: `if (portantDino) return baseEquipo.position;`. Esto garantiza que `CollectObservations` proporcione al modelo las coordenadas de la base como "target", forzando al dron a regresar.
- **Detección de Entrega**: Se implementará en `Update()` o `FixedUpdate()` para comprobar la distancia a `baseEquipo`. Se elige una distancia de `< 1.0f` como umbral de éxito.

## Risks / Trade-offs

- [Riesgo] → El dinosaurio puede quedar "atrapado" como hijo del dron si la lógica de entrega falla.
- [Mitigación] → Implementar una comprobación robusta en `Update` que siempre intente liberar al dinosaurio si se está cerca de la base y `portantDino` es true.
- [Riesgo] → Incompatibilidad con el modelo `.onnx` si se alteran las observaciones.
- [Mitigación] → Se mantendrá el número y tipo de observaciones intactos, cambiando únicamente los valores de entrada.
