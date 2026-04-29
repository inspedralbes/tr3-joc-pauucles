## Why

Actualment, després de crear una sala amb èxit, el pop-up de configuració roman visible i la llista de partides no s'actualitza automàticament. Això genera confusió a l'usuari sobre si la sala s'ha creat realment.

## What Changes

- Modificar la corrutina `EnviarPeticio` (o el mètode que gestiona la resposta de `/games/create`) per amagar el pop-up `popUpCrearSala` i refrescar la llista cridant `ObtenirPartides()`.
- Refinar el mètode `ObtenirPartides` per assegurar una gestió correcta del JSON de la llista de partides i la neteja d'ítems previs al `ListView`.

## Capabilities

### New Capabilities
- `game-creation-feedback`: Millora del feedback visual després de crear una sala.
- `game-list-refresh`: Capacitat de refrescar dinàmicament la llista de partides del lobby.

### Modified Capabilities
<!-- No requirement changes for existing capabilities -->

## Impact

- `MenuManager.cs`: Canvis en la lògica de resposta de peticions de xarxa i en la corrutina d'obtenció de partides.
