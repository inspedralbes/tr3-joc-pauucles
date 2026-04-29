## Context

El `DroneAI` utiliza un modelo neuronal que fue entrenado para perseguir objetivos basándose en coordenadas relativas. Al mantener ML-Agents activo permanentemente, podemos delegar el cálculo del movimiento al modelo tanto para la caza (perseguir al portador) como para el retorno (moverse hacia la base), siempre que las observaciones se actualicen dinámicamente.

## Goals / Non-Goals

**Goals:**
- Centralizar la lógica de IA en un flujo continuo sin desactivaciones de componentes.
- Implementar guardas lógicas pesadas para forzar el reposo absoluto.
- Asegurar que la velocidad de caza sea suficiente para interceptar jugadores rápidos.

**Non-Goals:**
- Modificar el sistema de red Socket.io.
- Cambiar la estructura de observaciones (el número de inputs debe ser constante).

## Decisions

- **Observaciones Dinámicas**: En `CollectObservations`, se utilizará una referencia de "Objetivo Actual". Si `portantDino` es false, el objetivo es el portador enemigo. Si es true, el objetivo es la base. Esto "engaña" a la red neuronal para que use su lógica de persecución para volver a casa.
- **Velocidad de Caza (10f)**: Se aumenta la velocidad de vuelo base para eliminar dudas en el movimiento del agente, asegurando que las acciones continuas de ML-Agents se traduzcan en un movimiento decidido.
- **Reposo forzado en OnActionReceived**: Al insertar una guarda al inicio del método de acciones, evitamos que pequeñas oscilaciones de la red neuronal muevan al dron cuando el dinosaurio está a salvo.
- **IsKinematic en Clientes**: Al mantener `DroneAI` encendido en clientes remotos pero poner el Rigidbody en `Kinematic`, permitimos que el componente siga existiendo para depuración o lógica visual menor, mientras que el `Vector3.Lerp` de red manda sobre la posición real.

## Risks / Trade-offs

- [Riesgo] → Que la red neuronal no converja bien con el objetivo de la base.
- [Mitigación] → La base es un punto estático, lo cual es más sencillo de procesar para la IA que un jugador en movimiento.
- [Riesgo] → Conflictos de posición entre `Lerp` e IA en clientes.
- [Mitigación] → `isKinematic = true` en clientes anula el impacto de cualquier fuerza aplicada por la IA local.
