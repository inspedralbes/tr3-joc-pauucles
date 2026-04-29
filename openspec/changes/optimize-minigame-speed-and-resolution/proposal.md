## Why

La resolución actual de los minijuegos es lenta y presenta redundancias en el manejo del tiempo y los resultados, lo que afecta la fluidez del gameplay y genera estados inconsistentes (como stuns accidentales al ganador). Esta optimización busca una resolución instantánea basada en eventos y un control estricto del tiempo para mejorar la experiencia competitiva.

## What Changes

- **Timer Único**: El temporizador se inicia una sola vez al comenzar el minijuego. Se elimina cualquier lógica de reinicio del timer ante inputs de los jugadores. El Host resuelve al ganador al agotarse el tiempo si no ha habido una resolución previa.
- **Resolución Instantánea**: Los minijuegos finalizarán inmediatamente cuando un jugador cometa un error o alcance el objetivo, sin esperar a que el timer llegue a cero.
- **Prioridad de Recepción**: En caso de que ambos jugadores completen el objetivo, el ganador será determinado por el orden de recepción del mensaje de éxito en el servidor/Host.
- **Identificación de Castigo**: Los mensajes de penalización (stun) incluirán explícitamente el ID del jugador perdedor para evitar efectos secundarios en el ganador.
- **Cierre de UI Inmediato**: La interfaz del minijuego se ocultará en cuanto se decida el resultado para permitir el retorno inmediato al mapa de juego.

## Capabilities

### New Capabilities
- `minigame-fast-resolution`: Nuevo flujo de control para minijuegos basado en resolución inmediata por eventos y timer de sesión única.

### Modified Capabilities
- Ninguna.

## Impact

- `MinigameManager` (o scripts específicos de minijuegos): Refactorización de la lógica de fin de juego y manejo de mensajes.
- Red: Mejora en la precisión de la determinación de ganadores en entornos de alta latencia.
- UI: Transiciones más rápidas entre el estado de minijuego y el gameplay normal.
