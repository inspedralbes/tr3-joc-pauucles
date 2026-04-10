## Why

Actualment, la bandera es pot "robar" o recollir per accident simplement en fregar-la, ja que el seu collider es manté actiu mentre un jugador la porta. Això causa comportaments no desitjats on la bandera canvia de mans sense que hi hagi una acció deliberada o una resolució de combat. Aquest canvi soluciona el problema desactivant el collider de la bandera un cop ha estat recollida.

## What Changes

- **Desactivació de Collider**: Quan un jugador recull la bandera (tant per col·lisió com per trigger), el collider de l'objecte bandera es desactivarà immediatament.
- **Gestió de la Jerarquia**: Es manté la lògica de fer que la bandera sigui filla del jugador (`SetParent`).

## Capabilities

### New Capabilities
- `flag-collision-guard`: Control de l'estat del collider de la bandera segons si està sent transportada o no.

### Modified Capabilities
- None.

## Impact

- **Player.cs**: Modificació de la lògica de recollida de la bandera.
- **Física del Joc**: La bandera deixarà de ser un objecte físicament interactuable mentre estigui en mans d'un jugador.
