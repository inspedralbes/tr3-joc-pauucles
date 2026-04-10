## Why

Actualment, el sistema de combat només suporta el minijoc PPTLLS. Per fer el joc més variat i dinàmic, és necessari implementar un sistema de selecció aleatòria (ruleta) que triï entre els 6 minijocs disponibles quan s'inicia un enfrontament.

## What Changes

- Actualització de `MinijocUIManager.cs` per incloure la lògica de selecció aleatòria.
- Implementació d'un sistema de "ruleta" que tria un minijoc entre 6 possibles.
- Integració del minijoc PPTLLS (ID 1) amb la seva interfície actual.
- Creació d'un sistema de "fallback" per als altres 5 minijocs que encara no tenen UI, resolent-los com a empat i tancant la UI per no bloquejar el flux del joc.
- Log de depuració per indicar quin minijoc ha estat seleccionat.

## Capabilities

### New Capabilities
- `minijoc-selection-roulette`: Sistema de selecció aleatòria de minijocs durant el combat.

### Modified Capabilities
- `minijoc-ui-pptlls-interaction`: Actualització per ser part del sistema de selecció aleatòria.

## Impact

- **MinijocUIManager.cs**: Canvis principals en la lògica d'activació de la UI i gestió de minijocs.
- **Player.cs**: Sense canvis directes, però dependrà de la correcta resolució de la ruleta.
- **Game Flow**: Millora en la varietat de situacions de combat.
