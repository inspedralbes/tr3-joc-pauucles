## 1. Nou Script Bandera.cs

- [x] 1.1 Crear el fitxer `Assets/Scripts/Bandera.cs`.
- [x] 1.2 Implementar `posicioInicial` i `fugint` a `Bandera.cs`.
- [x] 1.3 Implementar `Start()` per capturar la posició inicial.
- [x] 1.4 Implementar `Update()` per al moviment de retorn quan `fugint` és cert.
- [x] 1.5 Implementar el reset d'estat i collider en arribar al destí.

## 2. Canvis a MinijocUIManager.cs

- [x] 2.1 Modificar `ProcessarResultatCombat()` per alliberar la bandera en lloc de transferir-la.
- [x] 2.2 Activar l'estat `fugint` de la bandera quan s'allibera del perdedor.
- [x] 2.3 Deslligar la bandera del pare (`SetParent(null)`).

## 3. Canvis a Player.cs

- [x] 3.1 Actualitzar la recollida de la bandera per desactivar l'estat `fugint`.
- [x] 3.2 Desactivar el collider de la bandera quan un jugador l'agafa.
- [x] 3.3 Assegurar que s'aplica el `SetParent(this.transform)` correctament.

## 4. Validació

- [x] 4.1 Verificar que la bandera torna a la seva posició inicial quan un jugador perd un combat.
- [x] 4.2 Verificar que el collider es reactiva en arribar a la posició inicial.
- [x] 4.3 Verificar que un jugador pot interceptar la bandera mentre fuig (o un cop arribada).
