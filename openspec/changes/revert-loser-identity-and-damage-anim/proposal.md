## Why

Los cambios introducidos recientemente en la lógica de resolución de minijuegos y la animación de daño han generado inestabilidad o comportamientos no deseados en la sincronización de red. El objetivo de esta reversión es devolver el código a un estado anterior estable donde la apertura de ventanas de minijuego era síncrona y funcional, priorizando la estabilidad del flujo de juego principal sobre la resolución específica de la identidad del perdedor y efectos visuales secundarios.

## What Changes

- **Eliminación de Animación Hurt**: Se retirará el trigger "Hurt" del método `ProcesarDerrota` en `Player.cs`.
- **Reversión de Resolución de Minijuegos**: Se restaurará la lógica original de envío de resultados en `MinijocPPTLLSLogic.cs`, `MinijocParellsSenarsLogic.cs` y `MinijocAcaparamentMiradesLogic.cs`.
- **Limpieza de UIManager**: Se revertirán los cambios en `MinijocUIManager.cs` relacionados con el filtrado estricto de perdedores y la gestión de mensajes "Empat".

## Capabilities

### New Capabilities
- Ninguna.

### Modified Capabilities
- `minigame-sync-init`: Retorno al comportamiento base de sincronización de inicio y resolución.

## Impact

- `Player.cs`: Eliminación de llamadas al animador en el flujo de daño.
- Scripts de Minijuegos: Retorno a la emisión de resultados simplificada.
- `MinijocUIManager.cs`: Simplificación de la lógica de finalización de combate.
