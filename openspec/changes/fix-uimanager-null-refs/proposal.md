## Why

S'ha detectat un error `ArgumentNullException` a `MinijocUIManager.ShowUI` en intentar accedir a elements de la UI Toolkit (`rootVisualElement.Q`). Això passa perquè s'intenta fer una cerca sobre una referència nul·la, el que provoca que el joc es bloquegi quan s'hauria de mostrar la interfície del minijoc.

## What Changes

- Addició de comprovacions de nul·litat (null checks) per a `rootVisualElement` abans de fer consultes UQuery.
- Verificació de les referències de `ContenidorPPTLLS` i `ContenidorParellsSenars` per assegurar que s'han trobat correctament en el fitxer UXML.
- Millora de la robustesa del mètode `ShowUI` per evitar excepcions si els elements de la interfície no estan presents.

## Capabilities

### New Capabilities
- `uimanager-null-safety`: Garantia de seguretat contra referències nul·les en la gestió de la interfície d'usuari de minijocs.

### Modified Capabilities
<!-- Cap modificació de requisits funcionals, només correcció d'error d'implementació -->

## Impact

- **MinijocUIManager.cs**: Actualització del mètode `ShowUI` i la inicialització de contenidors.
- **Estabilitat del joc**: Es preveu que el joc deixi de fallar en iniciar enfrontaments entre jugadors.
