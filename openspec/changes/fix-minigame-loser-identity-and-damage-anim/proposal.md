## Why

Actualmente, el sistema de minijuegos presenta fallos en la asignación de la identidad del perdedor durante la resolución de los combates, enviando en ocasiones cadenas vacías que impiden que el cliente perdedor procese correctamente su derrota (daño y stun). Además, se ha detectado la falta de feedback visual (animación de daño) cuando un jugador pierde, lo que reduce la calidad de la experiencia de juego.

## What Changes

- **Identidad de Perdedor Obligatoria**: Se garantiza que los mensajes `MINIJOC_RESULT` siempre incluyan el nombre del perdedor cuando haya un ganador claro, revisando la lógica de todos los minijuegos.
- **Protocolo de Empate**: Los empates se comunicarán explícitamente enviando "Empat" tanto en el campo de ganador como en el de perdedor para asegurar una limpieza de estado síncrona.
- **Feedback Visual de Daño**: Se activará el trigger "Hurt" en el animador del jugador al procesar la derrota en `Player.cs`.

## Capabilities

### New Capabilities
- `minigame-guaranteed-loser-sync`: Asegura que el flujo de red de resultados de minijuegos siempre identifique a ambos participantes para una resolución determinista.
- `player-feedback-hurt`: Implementación de feedback visual inmediato mediante animación ante la derrota en combate.

### Modified Capabilities
- Ninguna.

## Impact

- `MinijocPPTLLSLogic.cs`, `MinijocParellsSenarsLogic.cs`, `MinijocAcaparamentMiradesLogic.cs`: Refactorización de la lógica de resolución.
- `Player.cs`: Inclusión de disparadores de animación en el flujo de daño.
- `MinijocUIManager.cs`: Manejo de los nuevos mensajes de resultado sincronizados.
