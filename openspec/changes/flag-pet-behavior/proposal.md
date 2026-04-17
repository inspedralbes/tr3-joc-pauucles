## Why

Actualment la bandera es "paret" al jugador mitjançant `SetParent`, el que la fa una extensió rígida del personatge. Aquest canvi busca donar-li una personalitat de "mascota" (un petit dinosaure), fent que segueixi al jugador amb un moviment fluid i físic, amb animacions pròpies segons el seu estat de moviment.

## What Changes

- **Eliminació de la vinculació rígida**: Es treu el `SetParent` i la manipulació directa de la posició des de `Player.cs`.
- **Moviment físic de la bandera**: La bandera (Dino) ara té el seu propi script de seguiment basat en `Rigidbody2D` i `SmoothDamp`.
- **Animacions de la mascota**: S'integra la lògica per canviar entre animacions de córrer (`isRunning`) i plorar (`isSad`) segons si es mou o està quiet.
- **Rotació (Flip)**: La mascota girarà per mirar cap a la direcció on s'està movent.

## Capabilities

### New Capabilities
- `flag-movement`: Defineix com la bandera (com a entitat independent) ha de seguir al jugador que la porta, gestionant la seva pròpia física i estats d'animació.

### Modified Capabilities
<!-- Cap -->

## Impact

- `Player.cs`: Es simplifica eliminant la gestió de la posició de la bandera.
- `Bandera.cs`: Es converteix en un script actiu de seguiment (o es crea si no existia).
- Prefab de la Bandera: Caldrà assegurar-se que tingui `Rigidbody2D` i `Animator` configurats correctament per a les noves animacions.
