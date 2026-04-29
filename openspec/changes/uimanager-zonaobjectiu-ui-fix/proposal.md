## Why

L'element `ZonaObjectiu` del minijoc AturaBarra no s'està visualitzant correctament en el motor de Unity degut a problemes de renderitzat o estils heretats de l'UXML. Aquest fix és necessari per assegurar que el jugador pugui veure l'objectiu i jugar amb normalitat.

## What Changes

- Forçat de mides de la `ZonaObjectiu` per codi (`width: 80`, `height: 50`).
- Forçat de color de fons groc (`backgroundColor = yellow`).
- Assegurar la visibilitat de l'element (`display = Flex`).
- Configuració de posicionament absolut (`position = Absolute`, `top = 0`).

## Capabilities

### New Capabilities
- `uimanager-style-overrides`: Capacitat de sobreescriure estils de UI Toolkit per codi per corregir errors de visualització.

### Modified Capabilities
- `minijoc-atura-barra-mechanics`: Actualització de la robustesa visual de la zona objectiu.

## Impact

- **MinijocUIManager.cs**: Modificació de la lògica de configuració de la `ZonaObjectiu` dins de `SetupAturaBarraButtons()`.
- **Gameplay**: La `ZonaObjectiu` ara serà clarament visible per al jugador.
