## Why

Actualment, la bandera es recull automàticament en tocar-la. Això pot ser molest si un jugador només vol passar pel costat o si es vol tenir un control més deliberat sobre quan agafar l'objecte. Canviar-ho a una recollida manual per botó millora la jugabilitat i evita errors accidentals.

## What Changes

- **Recollida Manual**: S'elimina la recollida automàtica per col·lisió/trigger.
- **Detecció de Proximitat**: S'afegeix lògica per detectar quan un jugador està a prop de la bandera.
- **Input de Recollida**: S'implementa l'ús de tecles específiques per a cada jugador (E per a J1, Ctrl Dreta per a J2) per recollir la bandera quan s'està a prop.
- **Gestió d'Estat**: S'actualitzen les referències i l'estat de la bandera (fugint, collider) en el moment de la recollida manual.

## Capabilities

### New Capabilities
- `manual-flag-pickup`: Permet als jugadors interactuar amb la bandera mitjançant un botó d'acció quan estan en el seu rang.

### Modified Capabilities
- `flag-acquisition`: Es modifica el disparador de la recollida, passant de col·lisió passiva a entrada d'usuari activa.

## Impact

- **Player.cs**: Modificació profunda de la lògica de col·lisió i trigger, i actualització del mètode `Update` per gestionar l'input.
- **Input System**: Ús de `KeyCode.E` i `KeyCode.RightControl`.
