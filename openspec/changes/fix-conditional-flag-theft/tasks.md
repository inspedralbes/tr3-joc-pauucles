## 1. Implementació Condicional a MinijocUIManager

- [x] 1.1 Localitzar el mètode `ProcessarResultatCombat(Player guanyador, Player perdedor)` a `MinijocUIManager.cs`.
- [x] 1.2 Obtenir la referència de l'objecte bandera mitjançant el tag "Bandera".
- [x] 1.3 Implementar el condicional `if (bandera.transform.parent == perdedor.transform)` abans de cridar a `RobarBandera()`.
- [x] 1.4 Assegurar que la crida a `WinCombat()` i `LoseCombat()` es realitza sempre, fora del condicional de la bandera.

## 2. Validació

- [x] 2.1 Verificar a Unity que si el perdedor no té la bandera, aquesta no es mou del seu lloc original després del combat.
- [x] 2.2 Confirmar que si el perdedor portava la bandera, el guanyador la rep correctament.
- [x] 2.3 Validar que el càstig de paràlisi s'aplica correctament en ambdós escenaris.
