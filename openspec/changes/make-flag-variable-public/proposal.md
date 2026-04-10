## Why

Actualment, la variable `banderaAgafada` a `Player.cs` és privada, el que impedeix que `MinijocUIManager` pugui consultar si un jugador porta la bandera per determinar els rols de combat (atacant/defensor). Això provoca l'error de compilació CS0122.

## What Changes

- **Canvi de protecció**: La variable `banderaAgafada` a `Player.cs` passarà de `private` a `public`.

## Capabilities

### New Capabilities
- Cap.

### Modified Capabilities
- `player-status-access`: Permetre l'accés extern a l'estat de possessió de la bandera per part del jugador.

## Impact

- `Player.cs`: Canvi de modificador d'accés.
- `MinijocUIManager.cs`: Ara podrà accedir correctament a la variable sense errors de protecció.
