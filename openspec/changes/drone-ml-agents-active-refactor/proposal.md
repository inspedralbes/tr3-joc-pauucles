## Why

El sistema del dron requiere una integración más profunda con el modelo entrenado de ML-Agents para aprovechar su capacidad de navegación tanto en la caza como en el retorno. Las implementaciones anteriores que desactivaban la IA en ciertos estados limitaban la fluidez visual. Esta propuesta busca mantener el "cerebro" activo permanentemente, redirigiendo sus observaciones dinámicamente y aplicando guardas físicas para estados de reposo.

## What Changes

- **Observaciones Dinámicas (DroneAI.cs)**: Redirección del objetivo de observación (`targetPosition`) según el estado de captura (`portantDino`).
- **Control Físico Supervisado (DroneAI.cs)**: Implementación de reposo forzado mediante anulación de velocidad y aumento de respuesta mediante `velocidadCaza = 10f`.
- **Bucle de Entrega (DroneAI.cs)**: Lógica de detección de base y liberación del dinosaurio mediante jerarquía de transforms.
- **Sincronización No Invasiva (DroneNetworkSync.cs)**: Los clientes remotos mantendrán los componentes de IA activos pero anularán su impacto físico mediante `isKinematic` e interpolación visual rápida.

## Capabilities

### New Capabilities
- `drone-ml-agents-permanent`: Integración continua de ML-Agents en el flujo de red multijugador, permitiendo navegación dinámica y sincronizada.

### Modified Capabilities
- Ninguna.

## Impact

- `DroneAI.cs`: Refactorización de `CollectObservations` y `OnActionReceived`.
- `DroneNetworkSync.cs`: Cambio en la política de gestión de componentes en clientes (mantener IA encendida).
- Experiencia de Usuario: Dron más reactivo y con movimientos más decididos gracias a la mayor velocidad de caza.
