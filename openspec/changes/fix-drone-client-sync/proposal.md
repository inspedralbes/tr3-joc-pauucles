## Why

Actualmente, los drones en el cliente no están correctamente sincronizados con el host. Esto se debe a fallos en el registro de los drones en la escena, una pérdida de la coordenada Z durante el movimiento sincronizado (lo que hace que desaparezcan tras el fondo) y una falta de visibilidad en los logs para depurar el flujo de mensajes. Este cambio es necesario para asegurar que todos los jugadores vean la misma posición de los drones y para facilitar el mantenimiento del sistema de red.

## What Changes

- **Registro de Drones**: Asegurar que tanto el Host como el Cliente registren los drones en `GameManager.Instance.dronsEscena` durante el inicio (`Awake`/`Start`).
- **Corrección de Posicionamiento Z**: Modificar la lógica de interpolación (`Lerp`) en `DroneNetworkSync.cs` para preservar la coordenada Z original del dron, evitando que se desplace a Z=0.
- **Sincronización de Red**: Revisar la lógica de envío/recepción de paquetes `DRONE_MOVE` para asegurar que el Host emite y el Cliente ejecuta el movimiento.
- **Depuración Mejorada**: Añadir logs estratégicos en `MenuManager.cs` y `DroneNetworkSync.cs` para trazar la llegada de datos JSON y la búsqueda de drones en la lista.

## Capabilities

### New Capabilities
- `drone-sync-fix`: Asegurar la correcta sincronización y visibilidad de los drones en el cliente.

### Modified Capabilities
- Ninguna (no existen especificaciones previas para el sistema de drones en `openspec/specs`).

## Impact

- `Assets/Scripts/DroneNetworkSync.cs`: Cambio en la lógica de Lerp y logs.
- `Assets/Scripts/DroneAI.cs` (o similar): Cambio en el registro inicial.
- `Assets/Scripts/MenuManager.cs`: Adición de logs en la recepción de mensajes Socket.IO.
- `Assets/Scripts/GameManager.cs`: Verificación de la lista `dronsEscena`.
