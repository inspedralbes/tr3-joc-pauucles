## 1. Neteja de Player.cs

- [x] 1.1 Eliminar el bloc de "GESTIÓ AFK (Parpelleig)" i la variable `tempsInactiu` de `Player.cs`.
- [x] 1.2 Eliminar l'assignació forçada de `localScale` (escala 3,3,1) a `AgafarBandera`.

## 2. Refactorització de Bandera.cs

- [x] 2.1 Actualitzar variables a `Bandera.cs`: afegir `distanciaMinima`, `forçaSaltDino` i eliminar variables de suavitzat obsoletes si cal.
- [x] 2.2 Substituir la lògica d'Update per moviment basat en velocitat horitzontal (`linearVelocity`).
- [x] 2.3 Implementar la detecció d'obstacles mitjançant Raycast i la lògica de salt automàtic.
- [x] 2.4 Actualitzar el mètode `CheckGrounded` (o similar) per assegurar que el Dino només salti des del terra.
- [x] 2.5 Ajustar les animacions `isRunning` i el Flip visual basant-se en la nova velocitat horitzontal.

## 3. Verificació

- [x] 3.1 Comprovar que el jugador ja no parpelleja en estar quiet.
- [x] 3.2 Verificar que la bandera (Dino) segueix al jugador amb la nova lògica de velocitat.
- [x] 3.3 Verificar que el Dino és capaç de saltar obstacles petits (murs/escales).
