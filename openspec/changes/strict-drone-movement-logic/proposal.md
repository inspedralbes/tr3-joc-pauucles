## Why

Actualmente, el dron puede presentar movimientos residuales o erráticos incluso cuando no tiene una tarea activa o cuando regresa a la base. Para garantizar un comportamiento impecable y predecible, es necesario implementar un sistema de control de movimiento que anule la IA en estados de reposo y retorno, priorizando una lógica determinista sobre la red neuronal.

## What Changes

- **Bloqueo de Reposo Absoluto**: El dron quedará anclado en su base e ignorará las acciones de ML-Agents cuando el dinosaurio esté a salvo en la base.
- **Modo Caza Restringido**: Las acciones de ML-Agents solo se procesarán si el dinosaurio ha sido robado o está fuera de la base.
- **Retorno Determinista**: Cuando el dron transporte el dinosaurio, el movimiento será calculado matemáticamente en línea recta hacia la base, ignorando las decisiones de la IA para asegurar una entrega perfecta.
- **Lógica de Entrega Mejorada**: El dinosaurio se soltará automáticamente al alcanzar un umbral de proximidad crítico a la base.

## Capabilities

### New Capabilities
- `drone-strict-movement`: Implementación de una jerarquía de control de movimiento que prioriza estados de reposo y retorno sobre el sistema de IA.

### Modified Capabilities
- Ninguna.

## Impact

- `DroneAI.cs`: Refactorización del método `OnActionReceived` y el bucle `Update`.
- Comportamiento del Juego: El dron será mucho más estable y visualmente coherente, eliminando derivas innecesarias.
