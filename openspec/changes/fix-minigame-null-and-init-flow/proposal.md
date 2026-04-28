## Why

Actualmente el sistema de minijuegos experimenta fallos de ejecución críticos (`NullReferenceException`) durante la resolución de combates y una falta de sincronización en el inicio para el jugador Host. Además, los empates o errores dobles pueden causar excepciones si no se gestionan adecuadamente. Este cambio busca robustecer la lógica de red y UI para asegurar una experiencia fluida y sin errores de consola.

## What Changes

- **Verificación Robusta de Nulos**: Implementación de guardas de seguridad en `MinijocUIManager.cs` para validar nombres de usuario y referencias a objetos antes de procesar resultados.
- **Sincronización de Inicio en Host**: Ajuste del listener de red para asegurar que el Host procese su propio mensaje de inicio rebotado por el servidor, activando la interfaz síncronamente con los clientes.
- **Gestión de Resultados Vacíos**: Manejo explícito de casos donde el ganador sea una cadena vacía o nula, evitando errores de lógica en empates.

## Capabilities

### New Capabilities
- `minigame-null-safety`: Implementación de comprobaciones de seguridad exhaustivas para prevenir NullReferenceException en la lógica de UI y red de minijuegos.
- `minigame-sync-host-loop`: Mejora del flujo de red para garantizar que el Host participe en el ciclo de vida del minijuego (inicio/fin) de la misma forma que los clientes remotos.

### Modified Capabilities
- Ninguna.

## Impact

- `MinijocUIManager.cs`: Refactorización de `FinalitzarCombat` y validación de referencias.
- `MenuManager.cs`: Ajuste en el procesamiento de mensajes `MINIJOC_START` y `MINIJOC_RESULT`.
- Estabilidad: Eliminación de excepciones en la consola de Unity durante el gameplay multijugador.
