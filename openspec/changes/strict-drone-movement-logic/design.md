## Context

El `DroneAI.cs` actual depende de las decisiones de la IA en todo momento, lo que provoca imprecisiones visuales y lógicas cuando el dron no tiene un objetivo claro o cuando debe ser extremadamente preciso en el retorno. Este diseño introduce guardas lógicas pesadas para forzar el comportamiento deseado.

## Goals / Non-Goals

**Goals:**
- Implementar guardas de salida temprana en `OnActionReceived`.
- Forzar posiciones exactas en estados de reposo.
- Sustituir el movimiento por IA por movimiento determinista durante el transporte.

**Non-Goals:**
- Modificar el modelo neuronal o sus parámetros de entrenamiento.
- Cambiar el sistema de colisiones (Triggers).

## Decisions

- **Guarda de Reposo en `OnActionReceived`**: Se insertará una comprobación al inicio del método para detectar si el dinosaurio está a salvo. Si es así, se forzará la inactividad. Esto es más eficiente que dejar que la IA tome decisiones y luego anularlas.
- **Movimiento Determinista con `MoveTowards`**: En lugar de alimentar a la IA con la posición de la base como objetivo, el dron tomará el control directo de su Transform. Esto garantiza que la trayectoria sea la más corta y rápida, sin oscilaciones de la red neuronal.
- **Umbral de Entrega Crítico (0.5f)**: Se reduce el umbral de entrega para asegurar que el dinosaurio aparezca exactamente centrado en la base al ser liberado.

## Risks / Trade-offs

- [Riesgo] → El dron puede parecer "rígido" al transicionar entre movimiento determinista e IA.
- [Mitigación] → El uso de `MoveTowards` y `Lerp` suaviza los arranques y paradas.
- [Riesgo] → Conflicto con el sistema de red si ambos intentan forzar posiciones.
- [Mitigación] → `DroneNetworkSync` debe estar sincronizado con estos estados para que los clientes no luchen contra el Host.
