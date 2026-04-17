## Why

Actualment, el mètode `AgafarBanderaAutomàticament` pot contenir lògica que desactiva el collider de la bandera, provocant que aquesta no detecti el terra i caigui al buit. Aquest canvi busca substituir aquesta desactivació per una ignorància selectiva de col·lisió amb el jugador.

## What Changes

- **Substitució de la lògica de recollida automàtica**: Es reemplaça completament el mètode `AgafarBanderaAutomàticament` a `Player.cs`.
- **Eliminació de `enabled = false`**: Es prohibeix la desactivació del collider de la bandera per mantenir la seva interacció amb el món.
- **Implementació de `Physics2D.IgnoreCollision`**: S'utilitza la versió amb 3 paràmetres (`true`) per ignorar la col·lisió entre el jugador i la bandera recollida.

## Capabilities

### New Capabilities
<!-- Cap -->

### Modified Capabilities
- `flag-movement`: Refinament del mètode de recollida automàtica per mantenir la integritat física de la bandera.

## Impact

- `Player.cs`: Canvi en la implementació de `AgafarBanderaAutomàticament`.
- Estabilitat física: Evita que la bandera es perdi en caure pel buit durant la recollida.
