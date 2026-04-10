## Why

Actualment, el `MinijocUIManager` només gestiona la interfície del minijoc PPTLLS. Per poder expandir la varietat de minijocs disponibles (com la ruleta ja implementada), cal integrar la interfície visual per al minijoc "Parells o Senars".

## What Changes

- Actualització de `MinijocUIManager.cs` per gestionar múltiples contenidors visuals (`ContenidorPPTLLS` i `ContenidorParellsSenars`).
- Implementació de la vinculació de botons per a "Parells o Senars" (`BtnParells` i `BtnSenars`).
- Integració de la lògica de "Parells o Senars" amb el sistema de selecció aleatòria (ID 4).
- Gestió de la visibilitat de la UI segons el minijoc seleccionat (usant `display = None/Flex`).
- Resolució local de l'enfrontament assignant l'opció contrària al segon jugador per a proves.

## Capabilities

### New Capabilities
- `minijoc-ui-parells-senars`: Interfície visual i interacció per al minijoc de Parells o Senars.

### Modified Capabilities
- `minijoc-selection-roulette`: Actualització per activar la UI específica quan es selecciona l'ID 4.

## Impact

- **MinijocUIManager.cs**: Canvis en la gestió de la UI i vinculació de nous botons.
- **Player.cs**: Sense canvis directes, però interactua amb la nova UI.
- **UI Toolkit**: Cal que el fitxer UXML contingui els nous elements (`ContenidorParellsSenars`, `BtnParells`, `BtnSenars`).
