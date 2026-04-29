## 1. Detecció de Proximitat (Triggers)

- [x] 1.1 Implementar `OnTriggerEnter2D` a `Player.cs` per gestionar la proximitat de la bandera (igual que `OnCollisionEnter2D`).
- [x] 1.2 Implementar `OnTriggerExit2D` a `Player.cs` per netejar la proximitat de la bandera (igual que `OnCollisionExit2D`).

## 2. Refinament de Recollida Manual

- [x] 2.1 Afegir la guarda de nullitat `if (banderaPropera == null) return;` al mètame de recollida manual a `Player.cs`.
- [x] 2.2 Obtenir el component `Bandera` i posar `fugint = false`.
- [x] 2.3 Realitzar el `SetParent(this.transform)` i fixar `localPosition = new Vector3(-0.8f, 0, 0)`.
- [x] 2.4 Desactivar el `Collider2D` de la bandera mitjançant `GetComponent<Collider2D>().enabled = false`.
- [x] 2.5 Reiniciar la variable `aPropDeBandera = false`.
