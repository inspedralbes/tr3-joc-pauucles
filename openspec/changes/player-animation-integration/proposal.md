## Why

El personatge actual no té feedback visual de les seves accions (córrer, saltar, caure). Connectar l'Animator permetrà que el personatge reflecteixi el seu estat físic a través d'animacions, millorant l'experiència de joc i la immersió.

## What Changes

- Afegir una referència privada al component `Animator` en el script `Player.cs`.
- Inicialitzar l'Animator al mètode `Start`.
- Actualitzar els paràmetres de l'Animator (`yVelocity`, `isRunning`, `isGrounded`) al final de cada frame en el mètode `Update`.
- Garantir que la lògica de moviment existent no es vegi afectada.

## Capabilities

### New Capabilities
- `player-visual-feedback`: Implementació del feedback visual del jugador mitjançant animacions basades en el seu estat físic (velocitat i contacte amb el terra).

### Modified Capabilities
- Cap.

## Impact

- **Codi**: Modificació de `Player.cs`.
- **Unity**: Requereix que el GameObject del Player tingui un component `Animator` amb els paràmetres `yVelocity` (float), `isRunning` (bool) i `isGrounded` (bool) configurats.
