## Context

El sistema de red actual sufre de interferencias cuando el Host y el Cliente intentan computar la IA del dron simultáneamente, o cuando los scripts de red de la bandera luchan contra la jerarquía impuesta por el dron al capturarlo.

## Goals / Non-Goals

**Goals:**
- Implementar un estado de reposo suave e inactivo para el dron.
- Garantizar que solo el Host ejecute la lógica de IA.
- Eliminar interferencias de red del dinosaurio mientras es transportado.

**Non-Goals:**
- Cambiar el sistema de transporte basado en `SetParent`.
- Modificar el protocolo de comunicación base (Socket.io).

## Decisions

- **Supresión de Acciones**: En `DroneAI.OnActionReceived`, se insertará una guarda: `if (currentState == DroneState.A_Salvo) return;`. Esto evitará que la red neuronal intente mover al dron mientras reposa.
- **Suavizado de Reposo**: Se utilizará `Vector3.Lerp` hacia la base en `Update()` del Host cuando el estado sea `A_Salvo`, combinado con `rb.linearVelocity = Vector2.zero` para evitar derivas físicas.
- **Limpieza de Componentes en Clientes**: En `DroneNetworkSync`, se usará `Destroy` o desactivación forzada de `DroneAI`, `BehaviorParameters` y `DecisionRequester`. Esto ahorra recursos y evita conflictos de autoridad.
- **Supresión de Red en Bandera**: Se buscará el script `NetworkSync` (o equivalente) en el objeto `Bandera` y se desactivará al emparentar, reactivándolo al soltar. Esto previene que la bandera envíe sus propios mensajes de movimiento que contradigan la posición del dron.

## Risks / Trade-offs

- [Riesgo] → Que el dron nunca salga del modo reposo.
- [Mitigación] → `DeterminarEstadoActual()` seguirá ejecutándose para actualizar el `currentState` y salir de la guarda cuando la bandera sea robada.
- [Riesgo] → Pérdida definitiva de sincronización de la bandera si no se reactiva el componente.
- [Mitigación] → Asegurar que la reactivación ocurra en el bloque de "Entrega" en base.
