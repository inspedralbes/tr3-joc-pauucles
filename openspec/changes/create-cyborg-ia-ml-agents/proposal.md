## Why

Implementar un agente inteligente para el personaje Cyborg utilizando Unity ML-Agents, permitiendo que aprenda a recolectar dinosaurios y llevarlos a una base de destino de forma autónoma a través del aprendizaje por refuerzo.

## What Changes

- Creación del script `CyborgIA.cs` heredando de `Unity.MLAgents.Agent`.
- Definición de variables de estado: `targetDinosaurio`, `baseDestino`, `moveSpeed`, `tieneDino`.
- Implementación de lógica de reinicio de episodio en `OnEpisodeBegin()`.
- Configuración de la recogida de observaciones en `CollectObservations()`.
- Implementación de acciones discretas de movimiento 2D en `OnActionReceived()`.
- Sistema de recompensas basado en la recolección exitosa, entrega y penalización por tiempo.
- Modo de control manual en `Heuristic()` para pruebas.

## Capabilities

### New Capabilities
- `cyborg-ml-agents-ai`: Lógica completa del agente Cyborg para recolección y transporte utilizando ML-Agents.

### Modified Capabilities
<!-- No se modifican capacidades existentes de especificación -->

## Impact

- Nuevo script `CyborgIA.cs` en la carpeta de scripts de Unity.
- Dependencia del paquete `Unity.MLAgents` en el proyecto de Unity.
- Cambios en la jerarquía de la escena para configurar al Cyborg como Agente.
