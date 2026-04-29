## 1. Implementació de la correcció d'escala

- [ ] 1.1 Modificar `Player.cs` dins de `AgafarBandera` per afegir `banderaAgafada.localScale = new Vector3(3f, 3f, 1f);` immediatament després de fer el `SetParent`.
- [ ] 1.2 Verificar si `AgafarBanderaAutomàticament` requereix la mateixa assignació (si no crida a `AgafarBandera`).

## 2. Verificació

- [ ] 2.1 Verificar visualment que la bandera no canvia de mida quan el jugador la recull.
- [ ] 2.2 Verificar que el robatori de bandera també manté l'escala correcta.
