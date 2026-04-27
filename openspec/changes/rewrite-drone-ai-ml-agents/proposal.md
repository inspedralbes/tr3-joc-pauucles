## Why

El archivo `DroneAI.cs` actual requiere una reescritura completa para ser compatible y eficiente en el entrenamiento con ML-Agents. Se busca establecer un sistema de estados claro, observaciones precisas y una estructura de recompensas que facilite el aprendizaje del agente en la tarea de seguimiento del objetivo (dinosaurio).

## What Changes

- Reescritura total de `DroneAI.cs` heredando de `Agent` de ML-Agents.
- Implementación de una máquina de estados para el objetivo del dron: `A_Salvo`, `Robado` y `Tirado`.
- Definición de 8 observaciones clave en `CollectObservations` para el sensor vectorial.
- Control de movimiento continuo en `OnActionReceived`.
- Lógica de recompensas basada en la proximidad al objetivo en `FixedUpdate`.

## Capabilities

### New Capabilities
- `drone-ai-ml-agents`: Lógica y comportamiento del agente dron optimizado para entrenamiento por refuerzo, incluyendo gestión de estados del objetivo y recolección de observaciones espaciales.

### Modified Capabilities
<!-- No se modifican requerimientos de capacidades existentes, se crea una nueva implementación técnica. -->

## Impact

- `Assets/Scripts/DroneAI.cs`: Este archivo será reemplazado o reescrito significativamente.
- Configuración de ML-Agents en Unity: Se requerirá ajustar el componente Agent en el Prefab/Objeto del Dron.
- Proceso de entrenamiento: Afecta a la convergencia y éxito del entrenamiento del modelo del dron.
