## Why

Actualmente, la instanciación de las banderas (dinosaures) en `GameManager.cs` es inconsistente, lo que puede provocar que ambos equipos tengan banderas del mismo color o que no coincidan con la configuración de la sala. Este cambio asegura que las banderas reflejen fielmente los colores elegidos por los usuarios en el lobby, mejorando la claridad visual y la integridad mecánica del juego.

## What Changes

- Obtención directa de `teamAColor` y `teamBColor` desde `MenuManager.Instance.currentRoomData`.
- Implementación de una lógica de mapeo (switch) en `GameManager.cs` para seleccionar el Prefab de dinosaurio exacto basado en el string del color.
- Asegurar que la variable `equipPropietari` se asigne correctamente a cada instancia de bandera.
- Eliminación de lógicas redundantes o imprecisas de selección de prefab existentes en el método de instanciación.

## Capabilities

### New Capabilities
- `accurate-flag-color-instantiation`: Sistema de selección e instanciación de banderas basado estrictamente en los datos de color de la sala.

### Modified Capabilities
<!-- No requirement changes to existing specs -->

## Impact

- Script `GameManager.cs`.
- Visuales de las banderas en la escena de juego.
- Sincronización visual entre el lobby y la partida.
