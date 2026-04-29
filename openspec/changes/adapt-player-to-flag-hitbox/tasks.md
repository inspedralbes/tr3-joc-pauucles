## 1. Actualització de OnTriggerEnter2D

- [x] 1.1 Modificar `OnTriggerEnter2D` a `Player.cs` per gestionar la detecció de la bandera mitjançant `GetComponentInParent<Bandera>()`.
- [x] 1.2 Assegurar que el tag "Bandera" es comprova a l'objecte de la col·lisió (que serà el fill Hitbox).

## 2. Refactorització de AgafarBandera

- [x] 2.1 Actualitzar `AgafarBandera(Transform bandera)` a `Player.cs`.
- [x] 2.2 Implementar el bucle `foreach` per ignorar les col·lisions amb tots els colliders trobats mitjançant `GetComponentsInChildren<Collider2D>()`.
- [x] 2.3 Verificar que es manté `SetParent(null)` i `RigidbodyType2D.Dynamic`.

## 3. Verificació

- [x] 3.1 Comprovar que la recollida de la bandera funciona correctament en entrar en contacte amb la nova Hitbox.
- [x] 3.2 Verificar que no hi ha empentes físiques entre el jugador i la bandera un cop recollida.
- [x] 3.3 Confirmar que la bandera continua detectant el terra correctament.
