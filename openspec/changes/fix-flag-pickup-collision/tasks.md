## 1. Modificació de Player.cs

- [x] 1.1 Localitzar el mètode `AgafarBanderaAutomàticament(GameObject objBandera)` a `Player.cs`.
- [x] 1.2 Eliminar la línia `if (colB != null) colB.enabled = false;`.
- [x] 1.3 Afegir la línia `if (colB != null) Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), colB);` en el seu lloc.
- [x] 1.4 Verificar que es manté la crida `AgafarBandera(objBandera.transform);` al final del mètode.

## 2. Verificació

- [x] 2.1 Comprovar que el jugador pot recollir la bandera sense que aquesta sigui desactivada.
- [x] 2.2 Verificar que el jugador i la bandera poden estar al mateix espai sense empènyer-se.
- [x] 2.3 Confirmar que la bandera no cau del mapa en recollir-la gràcies al manteniment del collider.
