## Why

El entrenamiento actual del dron puede ser demasiado estático o predecible. Para mejorar la robustez del modelo de IA, es necesario que en cada episodio el dron se enfrente a diferentes situaciones iniciales (dinosaurio en manos de un jugador o dinosaurio abandonado en el suelo) en posiciones variadas del mapa.

## What Changes

- Adición de un array de puntos de spawn (`spawnPoints`) en `DroneAI.cs`.
- Actualización de la lógica de `OnEpisodeBegin` para seleccionar un punto de spawn aleatorio.
- Implementación de un sistema de aleatorización de estado inicial (Robado vs Tirado) al inicio de cada episodio.
- Forzado del reseteo de la posición del dron a su base al inicio de cada episodio.

## Capabilities

### New Capabilities
<!-- No se introducen capacidades totalmente nuevas, se mejora el entrenamiento de la capacidad existente. -->

### Modified Capabilities
- `drone-ai-ml-agents`: Actualización de los requisitos de inicialización de episodios para soportar escenarios aleatorios y teletransporte de objetivos.

## Impact

- `Assets/Scripts/DroneAI.cs`: Modificación de los métodos `Initialize` y `OnEpisodeBegin`.
- Inspector de Unity: Será necesario asignar los Transforms de los puntos de spawn en el componente `DroneAI`.
- Comportamiento de entrenamiento: Aumentará la variabilidad de las experiencias del agente, mejorando la generalización.
