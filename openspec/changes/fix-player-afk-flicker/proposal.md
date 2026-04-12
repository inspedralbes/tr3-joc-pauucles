## Why

Corregir el bug on el personatge continua parpellejant (efecte AFK) quan està en combat o en estats on no es pot moure (`potMoure = false`). Això millora la claredat visual i evita confusions durant els enfrontaments.

## What Changes

- **Reseteig de Temps Inactiu**: Quan `potMoure` és `false`, el comptador `tempsInactiu` s'ha de posar a `0`.
- **Restauració de l'Alpha**: Assegurar que el `SpriteRenderer` torni a tenir un alpha de `1f` quan el jugador entra en un estat on no es pot moure.
- **Lògica de l'Update**: Moure la gestió de l'AFK per sobre del control de moviment o integrar el reseteig dins de la comprovació d'estat.

## Capabilities

### Modified Capabilities
- `player-gameplay-refinements`: Millores en la lògica de control i visualització del jugador durant el joc i els combats.

## Impact

- `Player.cs`: Canvis en el mètode `Update` per gestionar correctament el temps d'inactivitat i el color del sprite.
