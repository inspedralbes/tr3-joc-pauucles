## 1. Preparació de Bandera.cs

- [x] 1.1 Afegir variables de seguiment a `Bandera.cs`: `targetSeguiment`, `velocitatSeguiment`, `velocitatRef`, `rb` i `anim`.
- [x] 1.2 Implementar el mètode `ComençarASeguir(Transform nouTarget)` per inicialitzar el seguiment.
- [x] 1.3 Implementar la lògica de seguiment amb `Vector2.SmoothDamp` a l'Update o FixedUpdate de `Bandera.cs`.
- [x] 1.4 Implementar la lògica d'animació (`isRunning`, `isSad`) basada en la velocitat i estat de seguiment.
- [x] 1.5 Implementar el gir (Flip) visual segons la direcció del moviment horitzontal.

## 2. Refactorització de Player.cs

- [x] 2.1 Eliminar el mètode `ActualitzarPosicioBandera()` de `Player.cs`.
- [x] 2.2 Actualitzar el mètode `AgafarBandera()` per eliminar `SetParent` i la manipulació directa de la posició.
- [x] 2.3 Cridar a `scriptB.ComençarASeguir(this.transform)` dins de `AgafarBandera()`.

## 3. Verificació i Proves

- [x] 3.1 Verificar que la bandera segueix al jugador de manera fluida al recollir-la.
- [x] 3.2 Verificar que les animacions de la bandera (córrer/plorar) funcionen correctament.
- [x] 3.3 Verificar que la bandera gira correctament segons la direcció del seu moviment.
