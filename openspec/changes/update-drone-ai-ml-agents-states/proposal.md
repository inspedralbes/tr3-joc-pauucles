## Why

Actualmente, el entrenamiento de la IA del dron es genérico y no distingue claramente entre las diferentes fases del juego (defensa de la base, persecución del ladrón o recuperación de la bandera tirada). Esto resulta en un comportamiento poco eficiente y difícil de optimizar. Definir estados explícitos y recompensas específicas por fase permitirá un entrenamiento más rápido y un comportamiento del dron mucho más inteligente y reactivo.

## What Changes

- **Lógica de Estados de Juego**: Introducción de 3 estados lógicos para el dinosaurio/bandera del equipo:
  - `A_Salvo` (0): El dinosaurio está en la base del equipo.
  - `Robado` (1): Un jugador enemigo lleva el dinosaurio.
  - `Tirado` (2): El dinosaurio está en el suelo, fuera de la base.
- **Observaciones Enriquecidas**: El sensor ahora recibirá:
  - Posición del dron.
  - Posición de la base del equipo.
  - Posición del objetivo dinámico (jugador, dinosaurio o base según el estado).
  - El estado actual (0, 1, 2) como valor discreto.
- **Sistema de Recompensas Rediseñado**:
  - Recompensas por proximidad al objetivo en los estados `Robado` y `Tirado`.
  - Recompensas por inactividad y permanencia en base en el estado `A_Salvo`.
  - Recompensas discretas (1.0f) por capturar/recuperar el dinosaurio.
  - Penalizaciones por salir de los límites del mapa.
- **Lógica de Reinicio**: El dinosaurio se reseteará a la base tras una captura exitosa, finalizando el episodio de entrenamiento.

## Capabilities

### New Capabilities
- `drone-state-driven-training`: Capacidad de entrenar al dron basado en el estado global del dinosaurio.
- `dynamic-objective-sensing`: Capacidad de la IA para cambiar su objetivo de observación según el contexto del juego.

### Modified Capabilities
- Ninguna.

## Impact

- `Assets/Scripts/DroneAI.cs`: Modificación profunda de `CollectObservations`, `OnActionReceived`, `Update` y adición de `OnTriggerEnter2D`.
- `Assets/Scripts/Bandera.cs`: Posible necesidad de verificar el estado de "tirada" o "en base".
