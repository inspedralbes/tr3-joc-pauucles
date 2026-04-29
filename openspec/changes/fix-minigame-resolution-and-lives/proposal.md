## Why

El sistema actual de resolución de minijuegos presenta redundancias en el procesamiento de resultados, lo que a veces provoca que el ganador sufra penalizaciones de derrota por error. Además, la lógica de red permite reinicios de temporizadores que deberían ser absolutos, y los drones muestran comportamientos erráticos al inicio de la partida. Este cambio busca asegurar una identidad única de perdedor, evitar dobles ejecuciones de resultados y estabilizar el comportamiento de los drones en reposo.

## What Changes

- **Identidad Única de Resolución**: Se implementará un filtro estricto en `FinalitzarCombat` para asegurar que solo el jugador identificado como perdedor ejecute la lógica de `ProcesarDerrota()`.
- **Protección contra Doble Resolución**: Introducción de una bandera `isConcluding` para evitar que el mismo resultado de minijuego se procese múltiples veces.
- **Temporizador Absoluto**: Eliminación de la lógica de reinicio de temporizadores en la recepción de datos de red; el tiempo será dictado exclusivamente por el Host.
- **Drones en Reposo**: Configuración de `DroneAI` para forzar velocidad cero y desactivar la toma de decisiones cuando el dinosaurio esté en la base.
- **Limpieza de Estado Post-Combate**: Reset de variables de colisión y cooldown inmediatamente después de finalizar un minijuego para garantizar que el siguiente encuentro sea limpio.

## Capabilities

### New Capabilities
- `minigame-strict-resolution`: Lógica de resolución de combate con validación de identidad y protección contra reentrancia.
- `drone-idle-stability`: Control de estado pasivo para drones basado en la posición del objetivo principal.

### Modified Capabilities
- Ninguna.

## Impact

- `MinijocUIManager.cs`: Refactorización de la lógica de fin de combate.
- `DroneAI.cs`: Ajuste de la lógica de activación y física inicial.
- Scripts de Minijuegos: Ajuste de la gestión de red del temporizador.
- `Player.cs`: Limpieza de variables de estado de combate.
