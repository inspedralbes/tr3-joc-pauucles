## Context

El dron utiliza ML-Agents para su comportamiento, lo cual es computacionalmente costoso y difícil de sincronizar físicamente si varias instancias intentan simular lo mismo. Al delegar toda la simulación al Host y tratar a los clientes como visualizadores pasivos, eliminamos discrepancias de red y ahorramos recursos en los clientes.

## Goals / Non-Goals

**Goals:**
- Centralizar la IA y físicas en el Host.
- Implementar interpolación visual suave (`Lerp`) en clientes.
- Evitar que los clientes procesen componentes innecesarios.

**Non-Goals:**
- Modificar el modelo neuronal o la lógica de decisión de `DroneAI.cs`.
- Implementar predicción en el cliente.

## Decisions

- **Modo Títere en Clientes**: En lugar de apagar solo el script, desactivaremos el `DecisionRequester` y pondremos el `Rigidbody2D` en `Kinematic`. Esto asegura que las colisiones locales en el cliente no desvíen la posición sincronizada.
- **Factor de Interpolación 15f**: Se elige un valor alto para reducir el lag percibido, asegurando que el dron responda rápidamente a los movimientos del Host sin generar vibraciones excesivas.
- **Autoridad vía MenuManager**: Se utilizará `MenuManager.Instance.userId == MenuManager.Instance.currentRoomData.host` (o una propiedad simplificada si existe) para determinar el rol.

## Risks / Trade-offs

- [Riesgo] → Latencia de red provocando saltos.
- [Mitigación] → El uso de `Lerp` suaviza los saltos menores.
- [Riesgo] → Desincronización crítica por pérdida de paquetes.
- [Mitigación] → El Host envía actualizaciones periódicas constantes para forzar la convergencia.
