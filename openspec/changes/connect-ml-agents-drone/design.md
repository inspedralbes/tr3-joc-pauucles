## Context

Actualmente, `DroneAI.cs` hereda de `Agent` pero no utiliza el sistema de acciones de ML-Agents para el movimiento. El movimiento se calcula manualmente en `MoureDronDirecte` y se aplica directamente al transform. Para habilitar el modelo entrenado, debemos transicionar de un modelo "Push" (lógica manual) a un modelo "Pull" (ML-Agents decide las acciones).

## Goals / Non-Goals

**Goals:**
- Deshabilitar el movimiento manual en favor de las acciones de ML-Agents.
- Implementar `OnActionReceived` para aplicar fuerzas/traslación basadas en el modelo.
- Mantener la compatibilidad con el sistema de red Socket.IO actual.

**Non-Goals:**
- Modificar el sistema de observaciones (`CollectObservations`).
- Cambiar la lógica de colisiones o captura de banderas.

## Decisions

### 1. Implementación de OnActionReceived
Se extraerán los valores de `ContinuousActions[0]` (Horizontal) y `ContinuousActions[1]` (Vertical). Estos valores suelen estar en el rango [-1, 1].
Rationale: Es el estándar de ML-Agents para control de movimiento continuo.

### 2. Aplicación del movimiento
Se utilizará `transform.Translate` o una modificación directa de `transform.position` dentro de `OnActionReceived`. 
Rationale: Como el dron es cinemático (`RigidbodyType2D.Kinematic`), el movimiento debe aplicarse mediante el transform.

### 3. Frecuencia de actualización
El movimiento se aplicará en `OnActionReceived`, que es llamado por el motor de ML-Agents en su propio ciclo de simulación (generalmente sincronizado con `FixedUpdate`).

## Risks / Trade-offs

- **[Riesgo] Fluidez del movimiento**: El modelo puede generar movimientos bruscos. -> **Mitigación**: Asegurar el uso de `Time.fixedDeltaTime` y considerar un pequeño suavizado si es necesario.
- **[Riesgo] Sincronización de Red**: `DroneNetworkSync` debe detectar los cambios de posición realizados por ML-Agents. -> **Mitigación**: `DroneNetworkSync` ya monitoriza el transform en su `Update`, por lo que debería funcionar sin cambios mayores, pero se verificará su ejecución en el Host.
