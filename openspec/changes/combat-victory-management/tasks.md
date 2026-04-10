## 1. Modificacions a MinijocUIManager.cs

- [x] 1.1 Declarar les variables privades `atacant` i `defensor` de tipus `Player`.
- [x] 1.2 Actualitzar `ShowUI(Player p1, Player p2)` per assignar els jugadors a `atacant` i `defensor` (detectant qui porta la bandera).
- [x] 1.3 Implementar el mètode `public void FinalitzarCombat(string guanyador)`.
- [x] 1.4 Dins de `FinalitzarCombat`, afegir la lògica per desvincular la bandera (`SetParent(null)`) si el defensor perd.
- [x] 1.5 Assegurar que `banderaAgafada` del defensor passi a ser `null`.

## 2. Verificació

- [x] 2.1 Comprovar que els rols s'assignen correctament segons la bandera.
- [x] 2.2 Verificar que la bandera s'allibera al món quan el portador perd el combat.
- [x] 2.3 Confirmar que la UI s'amaga correctament al finalitzar.
