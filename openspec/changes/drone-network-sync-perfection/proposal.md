## Why

Actualmente, la sincronización de red del dron no distingue claramente entre el Host (que controla la IA) y los Clientes (que solo ven el resultado), lo que provoca conflictos de movimiento y una experiencia visual inestable. Esta mejora establece roles claros para asegurar que el dron se mueva de forma fluida y coherente para todos los jugadores.

## What Changes

- **Roles Dinámicos**: Implementación de lógica en `Start()` para asignar automáticamente los roles `isHost` e `isRemote` basándose en el estado de la sala.
- **Modo Títere (Cliente)**: Desactivación de la IA y configuración física (Kinematic) para clientes remotos, utilizando interpolación suave (Lerp) para la posición.
- **Modo Cerebro (Host)**: Implementación de envío periódico de posición desde el Host hacia los clientes mediante `MenuManager`.
- **Sincronización de Portador**: Garantía de que los objetos emparentados (Dinosaurio) mantengan su sincronización de red cuando el dron los transporta.

## Capabilities

### New Capabilities
- `drone-network-sync`: Sistema de sincronización de red para agentes IA con soporte para arquitectura Host/Cliente.

### Modified Capabilities
- Ninguna.

## Impact

- `DroneNetworkSync.cs`: Refactorización de la lógica de sincronización y asignación de roles.
- `DroneAI.cs`: Se verá afectado por la desactivación dinámica en clientes remotos.
- `MenuManager.cs`: Utilizado como canal de comunicación para el evento `DRONE_MOVE`.
- Rendimiento: Mejora la fluidez visual al delegar el control físico únicamente al Host.
