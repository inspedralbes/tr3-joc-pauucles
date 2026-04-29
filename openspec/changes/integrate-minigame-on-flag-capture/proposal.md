## Why

Actualmente, la captura de la bandera es un evento instantáneo que no ofrece un reto adicional al jugador ni una pausa táctica. Integrar un minijuego al momento de la captura añade profundidad mecánica, permitiendo que el éxito de la captura dependa de la habilidad del jugador en un desafío rápido, a la vez que detiene su movimiento para crear tensión en el juego.

## What Changes

- Modificación de `OnTriggerEnter2D` en `Bandera.cs` para invocar el sistema de minijuegos tras el re-parentesco.
- Bloqueo del movimiento del jugador capturador mediante `potMoure = false`.
- Llamada al método `ShowUI` de `MinijocUIManager.Instance` pasando al jugador capturador.
- Inserción de comentarios guía para la futura implementación de la lógica de éxito/fracaso (devolver bandera si se pierde, reactivar movimiento al cerrar UI).

## Capabilities

### New Capabilities
- `flag-capture-minigame-integration`: Activación automática de la interfaz de minijuegos y bloqueo de movimiento al capturar una bandera enemiga.

### Modified Capabilities
<!-- No requirement changes to existing specs -->

## Impact

- Script `Bandera.cs`.
- Script `MinijocUIManager.cs` (uso de su API pública).
- Flujo de juego: interrupción del movimiento tras captura.
