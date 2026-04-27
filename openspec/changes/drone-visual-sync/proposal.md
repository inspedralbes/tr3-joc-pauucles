## Why

El sistema de red actual requiere una separación clara entre el Host (autoridad) y los Clientes para evitar conflictos de físicas e IA en el dron. Esta mejora asegura que el dron se mueva de forma fluida para todos los jugadores, centralizando la lógica en el Host y convirtiendo a los clientes en meros receptores visuales.

## What Changes

- **Roles Dinámicos**: Determinación automática de rol (Host/Cliente) al inicio.
- **Optimización de Cliente**: Desactivación de componentes pesados (`DroneAI`, `DecisionRequester`) y cambio a `Rigidbody2D` Kinematic en clientes para ahorrar CPU y evitar desincronización física.
- **Suavizado Visual**: Implementación de interpolación (`Lerp`) de alta velocidad en clientes para una experiencia visual libre de saltos.
- **Comunicación del Host**: Implementación del envío periódico de posición desde el Host hacia el resto de la sala.

## Capabilities

### New Capabilities
- `drone-visual-sync`: Sistema de replicación visual pura para agentes IA en arquitectura Host/Cliente.

### Modified Capabilities
- Ninguna.

## Impact

- `DroneNetworkSync.cs`: Refactorización completa de la lógica de red.
- Rendimiento: Mejora en el rendimiento de los clientes al eliminar cálculos innecesarios de IA.
- Estabilidad: Eliminación de jitters y discrepancias de posición entre jugadores.
