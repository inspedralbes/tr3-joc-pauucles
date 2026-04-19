## Why

El juego actualmente carece de una interacción de combate robusta entre jugadores. Al encontrarse dos jugadores de equipos opuestos, debería activarse un minijuego que determine el resultado del encuentro. Este cambio implementa la detección de colisiones entre enemigos y el disparo automático del sistema de minijuegos para crear conflicto táctico.

## What Changes

- Implementación o reparación de la detección de colisiones entre jugadores en `Player.cs` (`OnCollisionEnter2D`).
- Lógica de obtención y comparación de equipos (`equip`) entre el jugador local y el colisionante.
- Integración con `MinijocUIManager` para iniciar el combate solo si no hay un minijuego activo.
- Bloqueo del movimiento del jugador local (`potMoure = false`) al iniciar el combate.
- Inclusión de logs de depuración para rastrear colisiones contra enemigos.

## Capabilities

### New Capabilities
- `enemy-combat-mechanics`: Detección automática de enemigos y disparo de minijuegos de combate tras colisión física.

### Modified Capabilities
<!-- No requirement changes to existing specs -->

## Impact

- Script `Player.cs`.
- Script `MinijocUIManager.cs` (uso de su API pública).
- Flujo de juego: interrupción de movimiento y entrada en fase de combate.
