## Context

La sincronización de red en Unity con WebSockets (Socket.io) requiere una gestión manual de la autoridad. Dado que el dron es una IA, el Host (quien creó la sala) debe ser el único responsable de calcular su movimiento para evitar discrepancias. Los clientes deben limitarse a interpolar la posición recibida.

## Goals / Non-Goals

**Goals:**
- Centralizar la lógica de IA en el Host.
- Asegurar una interpolación fluida en los clientes remotos.
- Sincronizar la posición del dron mediante eventos de Socket.io existentes.

**Non-Goals:**
- Implementar un sistema de predicción en el cliente.
- Cambiar el protocolo de comunicación (Socket.io).

## Decisions

- **Asignación de Autoridad**: Se utilizará `GameManager.Instance.IsHost()` o una comprobación similar para determinar el rol en `Start()`. Esto asegura que el estado sea inmutable durante la sesión.
- **Interpolación en el Cliente**: Se utilizará `Vector3.Lerp` en el `Update()` de los clientes remotos con un factor de suavizado configurable para compensar la latencia.
- **Transmisión del Host**: El Host enviará la posición en `Update()` solo si el dron se ha movido significativamente o con un temporizador (throttle) para no saturar el socket. Se utilizará `MenuManager.Instance.EnviarMovimientoDron()`.
- **Física en el Cliente**: Establecer `Rigidbody2D.bodyType = RigidbodyType2D.Kinematic` en clientes remotos previene que colisiones locales desincronicen visualmente al dron.

## Risks / Trade-offs

- [Riesgo] → Latencia de red provocando "teletransporte".
- [Mitigación] → El uso de `Lerp` suaviza la transición visual entre actualizaciones.
- [Riesgo] → Saturación de mensajes en el socket.
- [Mitigación] → Implementar un intervalo mínimo (ej. 50ms) entre envíos de posición del dron.
