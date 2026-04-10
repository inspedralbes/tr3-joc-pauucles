## Why

Actualment, el `MinijocUIManager` presenta problemes de visibilitat on diversos contenidors de minijocs es poden veure alhora. A més, hi ha errors a la consola indicant que alguns contenidors no es troben, i la correspondència entre els IDs de la ruleta i els minijocs implementats no és l'esperada per l'usuari (específicament per al joc de Parells o Senars).

## What Changes

- Implementació del mètode `AmagarTotsElsContenidors()` per assegurar que només un minijoc és visible a la vegada.
- Refactorització de la lògica de cerca de contenidors per utilitzar els noms exactes (`ContenidorPPTLLS` i `ContenidorParellsSenars`).
- Actualització de la ruleta per assignar l'ID 2 al minijoc "Parells o Senars" i assegurar-ne la inicialització correcta.
- Eliminació del resultat d'empat forçat per al nou ID del joc Parells o Senars.
- Crida a `AmagarTotsElsContenidors()` en tancar la UI o abans d'obrir-ne una de nova.

## Capabilities

### New Capabilities
- `uimanager-container-management`: Gestió centralitzada i segura de la visibilitat dels contenidors de minijocs.

### Modified Capabilities
- `minijoc-selection-roulette`: Reassignació d'IDs per als minijocs implementats (ID 2 per a Parells o Senars).
- `minijoc-ui-parells-senars`: Actualització de la lògica d'activació per respondre a l'ID 2.

## Impact

- **MinijocUIManager.cs**: Canvis significatius en el `switch` de la ruleta, inicialització de referències i gestió de visibilitat.
- **UI Toolkit**: Assegurar que els noms dels contenidors al fitxer UXML coincideixen exactament amb el codi.
