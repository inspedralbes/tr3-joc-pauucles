## Why

Actualment, en recollir la bandera, es desactiva el seu collider per evitar empentes amb el jugador. Això provoca que la bandera perdi la seva capacitat de detectar el terra i caigui al buit si el jugador no està exactament a sobre d'una plataforma sòlida.

## What Changes

- **Canvi en la gestió de col·lisions**: En lloc de desactivar el collider de la bandera, s'utilitzarà `Physics2D.IgnoreCollision` per permetre que la bandera ignori només al jugador que la porta, mantenint la seva col·lisió amb l'entorn (terra).
- **Manteniment de la física**: La bandera conservarà el seu collider actiu, permetent que el `Rigidbody2D` continuï detectant el terra i evitant caigudes accidentals fora del mapa.

## Capabilities

### New Capabilities
<!-- Cap -->

### Modified Capabilities
- `flag-movement`: Actualització de la lògica de recollida per gestionar col·lisions selectives en lloc de desactivació total.

## Impact

- `Player.cs`: Modificació del mètode `AgafarBanderaAutomàticament`.
- Estabilitat del joc: Millora en la persistència de la bandera al mapa.
