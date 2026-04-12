## Why

Implement the logic for the "Cable Pelat" minigame to ensure its functionality and correct integration with the UI Manager. This provides a new interactive minigame for players and completes the combat variety.

## What Changes

- **MinijocCablePelatLogic.cs**:
    - Update `InicialitzarUI` to use ID selectors (`#`) for `#ZonaInici`, `#ZonaMeta`, and `#FonsPerill`.
    - Implement the logic:
        - `enCurs = true` when entering `#ZonaInici`.
        - `enCurs = false` and finish combat with "Jugador 2" as winner when entering `#FonsPerill` if `enCurs` is true.
        - `enCurs = false` and finish combat with "Jugador 1" as winner when entering `#ZonaMeta` if `enCurs` is true.
- **MinijocUIManager.cs**:
    - Ensure `#ContenidorCablePelat` is properly hidden in `AmagarTotsElsContenidors`.
    - Correctly display and initialize `MinijocCablePelatLogic` in `ShowUI`.

## Capabilities

### New Capabilities
- `minijoc-cable-pelat`: Interactive minigame where the player must navigate from a start zone to a finish zone without touching a dangerous background area.

### Modified Capabilities
- None

## Impact

Affects the combat minigame system and the UI Toolkit elements for the "Cable Pelat" minigame. Requires correct ID naming in the UXML file.
