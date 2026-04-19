## Why

S'ha decidit que la identificació visual dels jugadors s'ha de basar en les 6 skins disponibles (Biker, Cyborg, GraveRobber, Punk, SteamMan, Woodcutter) en lloc dels colors d'equip. Els colors ara només s'apliquen a les banderes. Cal netejar les referències obsoletes al `GameManager.cs` i afegir les noves variables per als prefabs de skin.

## What Changes

- **Eliminació**: Esborrar les variables `prefabRojo`, `prefabVerde`, `prefabAzul` i `prefabAmarillo` (Prefabs de Jugador per Color).
- **Addició**: Afegir variables públiques per als 6 prefabs de skin: `prefabBiker`, `prefabCyborg`, `prefabGraveRobber`, `prefabPunk`, `prefabSteamMan`, `prefabWoodcutter`.
- **Persistència**: Mantenir intactes les variables de "Prefabs de Banderes".

## Capabilities

### New Capabilities
- `skin-based-player-management`: Gestió de la visualització dels personatges basada estrictament en skins.

### Modified Capabilities
<!-- Cap -->

## Impact

- `GameManager.cs`: Canvi en la declaració de variables i configuració de l'inspector.
- Lògica d'spawn: El mètode `GetPrefabPerSkin` ara tindrà referències directes a les noves variables.
