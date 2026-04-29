## 1. Ajustos en MinijocUIManager.cs

- [x] 1.1 Localitzar el mètode `ProcessarResultatCombat()` o on es realitza el robatori de la bandera.
- [x] 1.2 Cambiar la `localPosition` inicial de la bandera a `new Vector3(-0.8f, 0, 0)` després de fer el `SetParent`.

## 2. Implementació en Player.cs

- [x] 2.1 Declarar una variable privada `private Transform banderaPortant;` per optimitzar la cerca.
- [x] 2.2 Dins de l' `Update()`, afegir una comprovació per trobar fills amb el tag "Bandera" si `banderaPortant` és nul.
- [x] 2.3 Implementar la lògica per canviar l'offset de la bandera segons el valor de l'input horitzontal.
- [x] 2.4 Assegurar que la bandera es col·loca al costat oposat de la direcció del moviment (`input > 0` -> `-0.8`, `input < 0` -> `0.8`).

## 3. Validació

- [x] 3.1 Verificar que després d'un combat, la bandera apareix al costat del guanyador.
- [x] 3.2 Confirmar que quan el jugador es mou, la bandera el segueix per l'esquena (remolc).
- [x] 3.3 Comprovar que l'espai a sobre del cap del jugador ha quedat lliure.
