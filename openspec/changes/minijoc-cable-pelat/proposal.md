## Why

Afegeix varietat als enfrontaments entre jugadors mitjançant un nou minijoc d'habilitat ("Cable Pelat") on els jugadors han de recórrer un camí amb el ratolí sense tocar els marges.

## What Changes

- **Nou Script**: Creació de `MinijocCablePelatLogic.cs` per gestionar la lògica d'interacció mitjançant UI Toolkit (`PointerEnterEvent`).
- **Actualització de MinijocUIManager**:
  - Augmentar el rang de `Random.Range` a la funció de la ruleta (fins a 7) per incloure el nou minijoc.
  - Afegir un nou `case 6` al `switch` de selecció per activar el contenidor `#ContenidorCablePelat`.
  - Integrar la crida a `InicialitzarUI` per carregar els elements del minijoc.

## Capabilities

### New Capabilities
- `minijoc-cable-pelat`: Lògica de control per al minijoc d'habilitat de seguir un camí amb el punter sense tocar les zones de perill.

### Modified Capabilities
- `minijoc-ui-management`: Gestió centralitzada de minijocs a `MinijocUIManager` per suportar nous tipus de reptes.

## Impact

- `MinijocUIManager.cs`: Canvis en la selecció aleatòria i activació de contenidors UI.
- **UI Toolkit**: Requereix la presència dels elements `#ContenidorCablePelat`, `#ZonaInici`, `#ZonaMeta` i `#FonsPerill` al fitxer UXML de la pantalla de minijocs.
