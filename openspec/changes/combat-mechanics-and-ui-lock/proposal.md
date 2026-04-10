## Why

Es requereix una correcció urgent per assegurar que la interfície d'usuari (UI) del minijoc estigui completament bloquejada i invisible fins que es demani explícitament. A més, cal definir regles de combat més estrictes que penalitzin el perdedor amb immobilitat i permetin al guanyador robar la bandera, millorant així la competitivitat i el flux de joc.

## What Changes

- **Bloqueig de UI**: Implementació d'invisibilitat forçada del root visual element en `Awake` i `HideUI` a `MinijocUIManager.cs`.
- **Regles de Combat**: 
    - El guanyador crida a `FinalitzarCombat()` (immunitat i moviment).
    - El perdedor crida a `AplicarCastigDerrota()` (immobilitat prolongada).
- **Traspàs de Bandera**: Lògica per detectar si el perdedor tenia la bandera i transferir-la al guanyador mitjançant el mètode `RobarBandera()`.

## Capabilities

### New Capabilities
- `flag-theft`: Capacitat de transferir la bandera d'un jugador a un altre després d'un combat.
- `defeat-penalty`: Sistema de penalització d'immobilitat per al perdedor d'un minijoc.

### Modified Capabilities
- `uimanager-initialization-safety`: Actualització per incloure el bloqueig total del root visual element.
- `uimanager-persistent-state`: Refinament de la lògica d'ocultació.

## Impact

- **MinijocUIManager.cs**: Canvis en `Awake`, `ShowUI`, `HideUI` i en la resolució del combat.
- **Player.cs**: Nous mètodes `AplicarCastigDerrota()` i `RobarBandera()`, i actualització de la lògica de possessió de la bandera.
- **Game Flow**: Impacte directe en com es resolen els enfrontaments i com circula la bandera pel mapa.
