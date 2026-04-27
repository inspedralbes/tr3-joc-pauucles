## Why

Actualmente, el sistema de drones presenta dos problemas críticos que afectan la jugabilidad y la estabilidad:
1. La IA del dron (ML-Agents) crashea o se queda en estado IDLE debido a errores de referencia nula en la recolección de observaciones cuando los objetos (banderas) cambian de estado o son recogidos.
2. Los clientes remotos experimentan una sincronización visual deficiente o nula de los drones, ya que sus sistemas físicos e IA locales interfieren con las posiciones recibidas por red.

## What Changes

- **Robustez de la IA (DroneAI.cs)**: Implementación de null-checks estrictos en `CollectObservations`. La IA ahora detectará dinámicamente si el objetivo (bandera/dinosaurio) está en el suelo o lo posee un jugador, evitando excepciones.
- **Sincronización Visual Pasiva (DroneNetworkSync.cs)**: Configuración del dron como "espectador" en los clientes. Se desactivará el Rigidbody2D y la lógica de IA en instancias remotas, aplicando una interpolación suave (`Lerp`) hacia la posición dictada por el Host.
- **Flujo de Mensajería (MenuManager.cs)**: Asegurar que los mensajes `DRONE_MOVE` se apliquen correctamente a los drones registrados en la escena del cliente, con alertas de depuración si una entidad no es encontrada.

## Capabilities

### New Capabilities
- `drone-ai-robustness`: Capacidad de la IA para manejar cambios dinámicos en los objetivos sin crashear.
- `passive-drone-client-sync`: Sincronización visual optimizada para clientes remotos donde el dron actúa como una entidad puramente visual.

### Modified Capabilities
- Ninguna.

## Impact

- `Assets/Scripts/DroneAI.cs`: Cambios en la lógica de sensores y observaciones.
- `Assets/Scripts/DroneNetworkSync.cs`: Cambios en la gestión de estados Host/Cliente y movimiento visual.
- `Assets/Scripts/MenuManager.cs`: Mejora en la recepción de paquetes de red para drones.
