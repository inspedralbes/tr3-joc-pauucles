## Context

El sistema de drones actual envía su posición al servidor Socket.IO en cada ejecución de `Update` del `DroneNetworkSync` cuando actúa como Host. Esto genera cientos de mensajes por segundo por dron, colapsando el tráfico de red. Además, `DroneAI.cs` tiene fragmentos de código que intentan mover al dron manualmente hacia el jugador, lo que entra en conflicto con las acciones enviadas por el motor de ML-Agents.

## Goals / Non-Goals

**Goals:**
- Implementar un sistema de throttling basado en tiempo para el envío de red.
- Eliminar lógicas de movimiento manual concurrentes en el Host.
- Mejorar la detección de errores de sincronización en los clientes remotos.

**Non-Goals:**
- Implementar interpolación avanzada (ya existe un Lerp básico que se mantendrá).
- Cambiar la lógica de entrenamiento de la IA.

## Decisions

### 1. Throttling en DroneNetworkSync.cs
Se utilizará una variable `lastSendTime` y una constante `sendInterval = 0.1f` dentro del `Update` del Host.
Rationale: 10 Hz es una frecuencia suficiente para la sincronización visual suave en un juego de este tipo sin saturar el WebSocket.

### 2. Limpieza de Movimiento en DroneAI.cs
Se eliminará o comentará el método `MoureDronDirecte` y sus llamadas en `Update`. El movimiento SHALL ocurrir solo en `OnActionReceived`.
Rationale: Evitar que dos sistemas (IA y Manual) intenten modificar el transform simultáneamente, lo que causa jittering y desincronización.

### 3. Debugging en MenuManager.cs
Añadir un `Debug.LogError` específico en el bloque de procesamiento de `DRONE_MOVE`.
Rationale: Ayuda a identificar si el problema es que el dron no se ha registrado en `GameManager.Instance.dronsEscena` en el cliente remoto.

## Risks / Trade-offs

- **[Riesgo] Movimiento entrecortado**: Bajar de 60fps a 10fps en la red podría causar saltos. -> **Mitigación**: El cliente ya tiene un Lerp en `Update` que suaviza la transición hacia la `targetPosition`.
- **[Riesgo] Respuesta de la IA**: La IA podría parecer más lenta en el cliente. -> **Mitigación**: El intervalo de 0.1s es el estándar para juegos multijugador competitivos/acción rápida.
