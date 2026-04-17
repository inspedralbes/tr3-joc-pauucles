## Why

S'ha detectat que la bandera (Dino) pot caure pel terra o tenir comportaments físics inconsistents en ser recollida pel jugador. Aquest canvi busca assegurar que la bandera es mantingui com una entitat física independent amb seguiment actiu.

## What Changes

- **Substitució de la lògica de recollida**: Es reemplaça el mètode `AgafarBandera` a `Player.cs` per una versió que evita el parentiu rígid i força el mode `Dynamic` del Rigidbody2D.
- **Activació del seguiment**: S'assegura la crida a `ComençarASeguir` de l'script `Bandera`.

## Capabilities

### New Capabilities
<!-- Cap -->

### Modified Capabilities
- `flag-movement`: Ajust del procediment d'inici de seguiment a `Player.cs`.

## Impact

- `Player.cs`: Canvi en la implementació de `AgafarBandera`.
- Estabilitat física: Millora en la interacció de la bandera amb el terra del mapa.
