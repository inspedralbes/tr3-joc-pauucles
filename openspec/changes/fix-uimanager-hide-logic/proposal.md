## Why

Actualment, el mètode `HideUI()` a `MinijocUIManager.cs` desactiva el component `UIDocument` o el `GameObject` sencer. Això provoca que en la següent activació l'UI Toolkit recarregui l'asset UXML complet, mostrant de nou tots els menús barrejats o ignorant les referències ja inicialitzades.

## What Changes

- Modificació estricta de `HideUI()`: s'eliminarà qualsevol crida a `gameObject.SetActive(false)` o `_uiDocument.enabled = false`.
- L'única acció de `HideUI()` serà cridar a `AmagarTotsElsContenidors()`.
- Verificació que `AmagarTotsElsContenidors()` aplica correctament `.style.display = DisplayStyle.None` a tots els contenidors.
- L'arrel de la UI romandrà sempre activa per mantenir la integritat de les referències i l'estat del DOM visual.

## Capabilities

### New Capabilities
- `uimanager-persistent-state`: Gestió de la visibilitat de la UI sense desactivar el component arrel, mantenint les referències i l'estat.

### Modified Capabilities
- `uimanager-container-management`: Refinament de la lògica d'ocultació global.

## Impact

- **MinijocUIManager.cs**: Canvi en el comportament del mètode `HideUI` i `AmagarTotsElsContenidors`.
- **UI Toolkit**: Millora en la transició entre estats de la UI sense recàrregues innecessàries.
