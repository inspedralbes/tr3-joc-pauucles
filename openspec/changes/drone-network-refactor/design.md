## Context

El dron es un agente crítico que interactúa con la bandera (dinosaurio). En una partida multijugador, tener múltiples instancias intentando calcular la misma IA genera divergencias visuales inaceptables. Este diseño centraliza todo el "cerebro" en el Host y transforma a los Clientes en "títeres" visuales.

## Goals / Non-Goals

**Goals:**
- Asegurar que solo una máquina (Host) compute la IA y la física del dron.
- Implementar transiciones de estado deterministas para el transporte y reposo.
- Eliminar el "jitter" causado por colisiones locales en los Clientes.

**Non-Goals:**
- Modificar el sistema de sincronización de red de otros objetos (Jugadores).
- Cambiar el modelo .onnx de ML-Agents.

## Decisions

- **Autoridad Total del Host**: En `DroneNetworkSync`, los clientes que no sean Host destruirán inmediatamente `DroneAI` y `DecisionRequester`. Esto garantiza que no haya código de IA ejecutándose en segundo plano en los clientes remotos.
- **Rigidbody Kinematic en Clientes**: Al poner el RB en Kinematic, el motor de físicas de Unity dejará de intentar mover el dron basándose en colisiones o gravedad local, permitiendo que el `Vector3.Lerp` mande sobre la posición visual.
- **Estados Rígidos en el Host**:
    - Se usará `DecisionRequester.enabled` para apagar la IA durante el reposo y el retorno, ahorrando ciclos de CPU y garantizando que el dron siga las rutas matemáticas calculadas (MoveTowards).
    - Se introduce `velocidadCaza` para permitir que el dron sea mucho más agresivo cuando el objetivo está fuera de la base.
- **Sincronización de Posición**: El Host emitirá su posición pero ignorará cualquier actualización de red sobre sí mismo para evitar bucles de realimentación.

## Risks / Trade-offs

- [Riesgo] → Latencia de red. 
- [Mitigación] → Un factor de interpolación alto (15f) para que los clientes reaccionen instantáneamente a los cambios del Host.
- [Riesgo] → Que el dinosaurio se pierda durante la entrega.
- [Mitigación] → La entrega se realiza mediante `MoveTowards` hasta una distancia mínima absoluta antes de soltar el transform.
