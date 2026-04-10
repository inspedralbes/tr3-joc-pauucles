## Why

S'ha detectat que el projecte utilitza la propietat `Rigidbody2D.isKinematic`, la qual ha estat marcada com a obsoleta (CS0618) en les versions recents de Unity. Aquesta actualització és necessària per mantenir la salut del codi, assegurar la compatibilitat amb futures versions del motor i eliminar les advertències de compilació.

## What Changes

- Substitució de totes les assignacions `isKinematic = true` per la nova API `bodyType = RigidbodyType2D.Kinematic`.
- Substitució de totes les assignacions `isKinematic = false` per `bodyType = RigidbodyType2D.Dynamic`.
- Revisió dels fitxers `Player.cs` i qualsevol altre script que gestioni físiques de `Rigidbody2D`.

## Capabilities

### New Capabilities
- `rigidbody-modern-physics`: Ús de l'API de `bodyType` de Unity per a la gestió del tipus de cos en Rigidbody2D.

### Modified Capabilities
<!-- No hi ha canvis en els requeriments funcionals, només en la implementació tècnica -->

## Impact

- **Player.cs**: Actualització de la lògica de canvi de tipus de cos en les corrutines de càstig i respawn.
- **Project Reliability**: Eliminació de warnings obsolets a la consola de Unity.
