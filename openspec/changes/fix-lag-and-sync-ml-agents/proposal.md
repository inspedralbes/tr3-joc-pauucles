## Why

Actualmente, el sistema de drones experimenta un lag extremo debido a una saturación de mensajes WebSocket (se envían en cada frame) y una desincronización visual causada por la superposición de lógicas de movimiento manual y de ML-Agents. Este cambio es crítico para asegurar la jugabilidad y la estabilidad de la red mientras se mantiene la autonomía de la IA.

## What Changes

- **Optimización de Red**: Limitación del envío de posición (`SendPosition`) en `DroneNetworkSync.cs` a un intervalo de 0.1 segundos (10 Hz), eliminando el envío por frame.
- **Consolidación de IA**: Centralización del movimiento exclusivamente en `OnActionReceived` de `DroneAI.cs`, eliminando cualquier lógica de movimiento manual residual que interfiera.
- **Gestión de Errores de Instanciación**: Implementación de un error controlado en `MenuManager.cs` si un mensaje de red llega para un dron que no ha sido instanciado en el cliente, facilitando la depuración del ciclo de vida del dron.

## Capabilities

### New Capabilities
- `optimized-drone-sync`: Implementar sincronización de red optimizada por tiempo y control por IA centralizado.

### Modified Capabilities
- Ninguna.

## Impact

- `Assets/Scripts/DroneNetworkSync.cs`: Cambio en la lógica de temporización de envío.
- `Assets/Scripts/DroneAI.cs`: Limpieza de lógicas de movimiento manual.
- `Assets/Scripts/MenuManager.cs`: Mejora en la detección de drones no instanciados.
