## 1. Neteja de Lògica Manual

- [ ] 1.1 Eliminar les variables `aPropDeBandera`, `banderaPropera` i la funció `RecollirBanderaManualment` a `Player.cs`.
- [ ] 1.2 Eliminar la comprovació d'input de tecles `E` i `RightControl` al mètode `Update` de `Player.cs`.
- [ ] 1.3 Eliminar la lògica de proximitat actual de `OnCollisionEnter2D`, `OnCollisionExit2D`, `OnTriggerEnter2D` i `OnTriggerExit2D`.

## 2. Implementació de Recollida Automàtica

- [ ] 2.1 Implementar la recollida directa a `OnTriggerEnter2D`:
    - Filtrar per tag "Bandera".
    - `SetParent(this.transform)`.
    - Fixar `localPosition = new Vector3(-0.8f, 0, 0)`.
    - Desactivar collider: `col.enabled = false`.
    - Sincronitzar component `Bandera` (`fugint = false`).
- [ ] 2.2 Implementar exactament la mateixa lògica a `OnCollisionEnter2D` (usant `collision.gameObject` i `collision.collider`).

## 3. Validació

- [ ] 3.1 Verificar que la bandera es recull a l'instant només de tocar-la.
- [ ] 3.2 Confirmar que la recollida funciona tant si la bandera és física com si és trigger.
- [ ] 3.3 Validar que ja no cal prémer cap tecla per agafar la bandera.
