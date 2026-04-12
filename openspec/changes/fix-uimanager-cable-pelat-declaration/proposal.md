## Why

Arreglar l'error de compilació CS0103 a `MinijocUIManager.cs` causat per la manca de declaració de la variable `_contenidorCablePelat`. Aquesta variable és necessària per gestionar el contenidor visual del minijoc "Cable Pelat".

## What Changes

- **Declaració de variable**: Afegir `private VisualElement _contenidorCablePelat;` a les declaracions de classe.
- **Assignació de referència**: Afegir la línia per buscar l'element `#ContenidorCablePelat` mitjançant `root.Q` dins de `ShowUI`.

## Capabilities

### Modified Capabilities
- `minijoc-ui-management`: Correcció de la integritat sintàctica i funcional del gestor de la interfície de minijocs per suportar el minijoc de Cable Pelat.

## Impact

- `MinijocUIManager.cs`: Correcció de l'error sintàctic i assegurar que el contenidor es pugui activar/desactivar correctament.
