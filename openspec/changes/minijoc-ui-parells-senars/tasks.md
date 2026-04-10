## 1. Actualització de MinijocUIManager.cs

- [x] 1.1 Declarar referències per als contenidors visuals (`ContenidorPPTLLS`, `ContenidorParellsSenars`) a `MinijocUIManager`.
- [x] 1.2 Implementar el mètode `ToggleContainers(int minijocId)` per canviar la visibilitat.
- [x] 1.3 Refactoritzar `ShowUI` per cridar a `ToggleContainers` i inicialitzar el minijoc correcte.
- [x] 1.4 Crear el mètode `SetupParellsSenarsButtons()` per vincular els botons del nou minijoc.

## 2. Integració de Lògica de Parells o Senars

- [x] 2.1 Implementar el mètode `HandleParellsSenarsClick(bool userChoseParells)` per gestionar l'elecció.
- [x] 2.2 Vincular les crides a `MinijocParellsSenarsLogic.cs` per resoldre l'enfrontament.
- [x] 2.3 Assegurar la crida a `WinCombat()` i `LoseCombat()` segons el resultat.

## 3. Validació

- [x] 3.1 Forçar la ruleta per triar ID 4 i verificar que es mostra la UI de Parells o Senars.
- [x] 3.2 Comprovar que els botons `BtnParells` i `BtnSenars` tanquen la UI i retornen el control al jugador.
- [x] 3.3 Verificar que quan surt PPTLLS (ID 1), encara funciona correctament.
