## Why

El `DroneAI` ha sido entrenado mediante aprendizaje por refuerzo, pero su lógica actual contiene elementos específicos del entrenamiento (como recompensas y reinicios de episodio) que no son compatibles con el flujo de juego real. Es necesario limpiar la clase y adaptar la lógica de captura y entrega para que funcione de forma autónoma en el entorno de producción.

## What Changes

- **Limpieza de Entrenamiento**: Eliminación de la lógica de spawns aleatorios en `OnEpisodeBegin`, así como todas las llamadas a `AddReward` y `EndEpisode`.
- **Nuevo Estado de Captura**: Introducción de la variable `portantDino` para rastrear si el dron lleva el objetivo.
- **Captura Física**: Implementación de la lógica de "parenting" en `OnTriggerEnter2D` para recoger al dinosaurio o interceptar al ladrón.
- **Navegación Dinámica**: Ajuste de las observaciones para que el dron priorice el regreso a la base cuando está transportando el dinosaurio.
- **Lógica de Entrega**: Implementación de la detección de proximidad a la base para soltar y puntuar el objetivo.

## Capabilities

### New Capabilities
- `drone-real-game-loop`: Implementación de la lógica de captura, transporte y entrega del dron para el modo de juego real, eliminando dependencias del entorno de entrenamiento.

### Modified Capabilities
- Ninguna.

## Impact

- `DroneAI.cs`: Refactorización completa de la lógica de estados y triggers.
- Comportamiento del Dron: Transición de un agente de entrenamiento a un bot funcional para el juego.
