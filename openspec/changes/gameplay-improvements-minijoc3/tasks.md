## 1. Millores de Gameplay a Player.cs

- [x] 1.1 Modificar `AplicarCastigDerrota()` per activar `isTrigger = true` al `Collider2D`.
- [x] 1.2 Actualitzar la corrutina de càstig per restaurar `isTrigger = false` i assegurar que la gravetat o posició no fallin.
- [x] 1.3 Refactoritzar `AgafarBandera()` per forçar la `localPosition = Vector3.zero`.

## 2. Preparació Minijoc 3 a MinijocUIManager.cs

- [x] 2.1 Declarar referència per al `ContenidorAturaBarra` i botó `BtnAturar`.
- [x] 2.2 Actualitzar `AmagarTotsElsContenidors()` per incloure el nou contenidor.
- [x] 2.3 Implementar el cas 3 en el `switch` de `ShowUI()`.
- [x] 2.4 Crear mètode `SetupAturaBarraButtons()` i la lògica placeholder per resoldre amb puntuacions aleatòries.

## 3. Validació

- [x] 3.1 Comprovar que el guanyador pot travessar el perdedor mentre aquest està immobilitzat.
- [x] 3.2 Verificar que la bandera s'enganxa perfectament al centre del guanyador en ser robada.
- [x] 3.3 Confirmar que la ruleta pot activar el minijoc 3 i aquest es resol tancant la UI correctament.
