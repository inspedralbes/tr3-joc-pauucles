## Why

El `DroneAI` actual está diseñado para un entorno de entrenamiento controlado y estático. Para que sea funcional en el juego multijugador real, es necesario eliminar las dependencias del sistema de entrenamiento (ML-Agents rewards/episodes) y adaptar la búsqueda de objetivos a un entorno dinámico donde las banderas y los jugadores cambian de estado y posición constantemente.

## What Changes

- **Limpieza de Entrenamiento**: Eliminación de `spawnPoints`, `jugadorObjetivo`, `dinosaurio` (referencia serializada), `OnEpisodeBegin`, `AddReward` y `EndEpisode`.
- **Búsqueda Dinámica**: Implementación de lógica para encontrar la bandera del equipo y el jugador enemigo que la porta en tiempo real.
- **Nuevo Estado de Captura**: Introducción de la variable `portantDino` para gestionar el transporte físico del objetivo.
- **Captura Física**: Mejora de `OnTriggerEnter2D` para vincular dinámicamente el dinosaurio al dron mediante jerarquía de transforms.
- **Navegación Adaptativa**: Ajuste de las observaciones para que el dron priorice la base cuando transporta el dinosaurio.
- **Bucle de Entrega**: Implementación de una comprobación de proximidad a la base para la entrega y puntuación.

## Capabilities

### New Capabilities
- `drone-multiplayer-inference`: Lógica completa de inferencia para el dron en modo multijugador, incluyendo búsqueda dinámica de objetivos y transporte físico.

### Modified Capabilities
- Ninguna.

## Impact

- `DroneAI.cs`: Refactorización masiva para eliminar dependencias de entrenamiento y añadir lógica de juego real.
- Estructura de Escena: Requiere que las banderas tengan componentes identificables (como `Bandera`) y que los equipos estén correctamente etiquetados.
