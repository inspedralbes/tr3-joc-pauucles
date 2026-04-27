## Why

Actualmente, los drones utilizan una lógica de movimiento manual hacia el jugador, lo que impide aprovechar el modelo de Inteligencia Artificial (ML-Agents) ya entrenado. Este cambio permite conectar el cerebro de la IA al control físico del dron, habilitando comportamientos autónomos basados en aprendizaje por refuerzo.

## What Changes

- **Eliminación de Movimiento Manual**: Se eliminarán o comentarán las llamadas a `MoureDronDirecte` y lógicas de persecución manual en `Update` o `FixedUpdate`.
- **Implementación de Acciones de IA**: Se implementará el método `OnActionReceived` para recibir comandos del modelo de ML-Agents.
- **Control por Acciones Continuas**: El movimiento se basará en dos acciones continuas (Eje X y Eje Y) extraídas del `ActionBuffers`.
- **Integración con Sincronización de Red**: Se asegurará que la posición generada por la IA sea capturada y enviada por `DroneNetworkSync` hacia los clientes.

## Capabilities

### New Capabilities
- `ml-agents-drone-control`: Habilitar el control del dron mediante el modelo de ML-Agents.

### Modified Capabilities
- Ninguna.

## Impact

- `Assets/Scripts/DroneAI.cs`: Modificación de la lógica de movimiento y recepción de acciones.
- `Assets/Scripts/DroneNetworkSync.cs`: Verificación de la captura de posición post-IA.
