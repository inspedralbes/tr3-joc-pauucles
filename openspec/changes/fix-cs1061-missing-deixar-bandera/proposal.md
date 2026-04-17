## Why

Després de la purga de codi anterior, s'ha detectat que el compilador genera un error CS1061 degut a la falta dels mètodes de desvinculació (`DeixarBandera` a `Player.cs` i `DeixarDeSeguir` a `Bandera.cs`). Aquest canvi restaurarà aquestes capacitats de manera neta.

## What Changes

- **Implementació de `DeixarDeSeguir` (Bandera.cs)**: Permet a la mascota aturar el seu seguiment i posar la seva velocitat a zero.
- **Implementació de `DeixarBandera` (Player.cs)**: Permet al jugador alliberar la referència de la bandera i notificar a la mascota que deixi de seguir.

## Capabilities

### New Capabilities
<!-- Cap -->

### Modified Capabilities
- `flag-movement`: Restauració i estandardització de la lògica d'alliberament de la bandera.

## Impact

- `Player.cs`: Addició del mètode `DeixarBandera`.
- `Bandera.cs`: Addició del mètode `DeixarDeSeguir`.
- Compilació: Correcció de l'error CS1061.
