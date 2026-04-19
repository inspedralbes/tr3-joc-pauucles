## Why

La captura de banderas es inconsistente porque los equipos de los jugadores remotos no se sincronizan correctamente. Este cambio asegura que todos los jugadores (locales y remotos) tengan su equipo asignado correctamente desde los datos de la sala, permitiendo que la lógica de la bandera funcione de forma fiable.

## What Changes

- Añadir la variable `public string equip;` en `Player.cs`.
- En `GameManager.cs`, asignar el equipo al jugador local durante `ConfigurarLocalPlayerVisuals()` usando los datos de `MenuManager`.
- En `GameManager.cs`, asignar el equipo a los jugadores remotos dentro de `UpdateRemotePlayer()` buscando su equipo en los datos de la sala.
- Simplificar la lógica de `OnTriggerEnter2D` en `Bandera.cs` para usar directamente la variable `equip` del jugador.

## Capabilities

### New Capabilities
- `player-team-sync`: Sincronización robusta de equipos para jugadores locales y remotos basada en los datos de la sesión/sala.

### Modified Capabilities
<!-- No requirement changes to existing specs -->

## Impact

- Scripts `Player.cs`, `GameManager.cs` y `Bandera.cs`.
- Lógica de captura de bandera y validación de equipos en tiempo real.
