## Why

El codi actual de `GameManager.cs` utilitza mètodes obsolets de Unity (`FindObjectsOfType`), el que genera warnings CS0618. A més, la cerca de punts de spawn no és prou específica, el que podria portar a errors si hi ha altres objectes amb noms similars. Aquest canvi modernitza el codi i assegura una identificació precisa dels punts de respawn.

## What Changes

- **Correcció del Warning CS0618**: Substitució de `Object.FindObjectsOfType<T>()` per `UnityEngine.Object.FindObjectsByType<T>(UnityEngine.FindObjectsSortMode.None)`.
- **Refinament de la cerca de Spawns**: El codi buscarà exactament els noms `PuntSpawn_Equip1` i `PuntSpawn_Equip2` en lloc de cerques parcials.
- **Millora de la robustesa**: Ús de namespaces explícits per evitar ambigüitats.

## Capabilities

### New Capabilities
- Cap.

### Modified Capabilities
- `gamemanager-refinement`: Modernització i precisió en la gestió de spawns i manteniment del codi del GameManager.

## Impact

- **Codi**: `GameManager.cs`.
- **Performance**: Millora lleugera en utilitzar mètodes de cerca més moderns i específics.
- **Mantenibilitat**: Eliminació de warnings de compilació.
