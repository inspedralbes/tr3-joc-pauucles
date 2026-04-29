## Why

Malgrat els canvis anteriors, encara poden existir residus de codi que provoquen que la bandera perdi la seva consistència física i caigui del mapa en ser recollida. Aquesta "purga" busca reescriure els mètodes crítics de recollida i inici de seguiment per assegurar una base neta i funcional.

## What Changes

- **Reescriptura de `AgafarBandera` (Player.cs)**: Implementació simplificada que prioritza la desvinculació del parent, la ignorància de col·lisions recursiva en fills i l'inici del seguiment.
- **Reescriptura de `ComençarASeguir` (Bandera.cs)**: Garantia de que el `Rigidbody2D` és `Dynamic` i el collider està habilitat al moment de començar el seguiment.

## Capabilities

### New Capabilities
<!-- Cap -->

### Modified Capabilities
- `flag-movement`: Purga i estandardització de la lògica de recollida i seguiment.

## Impact

- `Player.cs`: Substitució total del mètode `AgafarBandera`.
- `Bandera.cs`: Substitució total del mètode `ComençarASeguir`.
- Física del joc: Major estabilitat de la mascota (Dino).
