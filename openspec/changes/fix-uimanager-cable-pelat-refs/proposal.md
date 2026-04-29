## Why

Arreglar l'error de compilació CS0103 a `MinijocUIManager.cs` degut a la manca de declaració de la variable `_contenidorCablePelat` utilitzada per a la UI del minijoc d'habilitat.

## What Changes

- **Declaració de variable**: Afegir `private VisualElement _contenidorCablePelat;` a les declaracions de classe.
- **Assignació de referència**: Afegir la línia per buscar l'element `#ContenidorCablePelat` mitjançant `root.Q` dins de `ShowUI`.

## Capabilities

### Modified Capabilities
- `minijoc-ui-management`: Correcció de referències internes per a la gestió de contenidors UI.

## Impact

- `MinijocUIManager.cs`: Correcció de l'error sintàctic i assegurar el funcionament de la UI del minijoc.
