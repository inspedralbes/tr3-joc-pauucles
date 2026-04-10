## 1. Ajustos de la Ruleta i UI

- [x] 1.1 Modificar `ShowUI()` per canviar `Random.Range(1, 7)` a `Random.Range(1, 4)`.
- [x] 1.2 Actualitzar `SetupAturaBarraButtons()` per forçar `_zonaObjectiu.style.top = 0`.

## 2. Suport de Teclat

- [x] 2.1 Afegir a l' `Update()` de `MinijocUIManager.cs` la detecció de la tecla Espai.
- [x] 2.2 Enllaçar la detecció de tecla amb la crida a `HandleAturaBarraClick()` només si el minijoc està actiu.

## 3. Validació

- [x] 3.1 Comprovar que només surten els minijocs 1, 2 i 3 en múltiples intents.
- [x] 3.2 Verificar que la tecla Espai atura correctament la barra en el minijoc 3.
- [x] 3.3 Confirmar que la `ZonaObjectiu` apareix sempre ben alineada verticalment.
