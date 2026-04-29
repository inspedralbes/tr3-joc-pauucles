## 1. Implement Minigame Logic

- [x] 1.1 Update `MinijocCablePelatLogic.cs` to use `using UnityEngine.UIElements;`.
- [x] 1.2 Define `bool enCurs = false;` in `MinijocCablePelatLogic.cs`.
- [x] 1.3 Update `InicialitzarUI(VisualElement root)` to search for `#ZonaInici`, `#ZonaMeta`, and `#FonsPerill` using ID selectors.
- [x] 1.4 Add `PointerEnterEvent` callback to `#ZonaInici` to set `enCurs = true`.
- [x] 1.5 Add `PointerEnterEvent` callback to `#FonsPerill` to set `enCurs = false` and call `MinijocUIManager.Instance.FinalitzarCombat("Jugador 2")` if `enCurs` is true.
- [x] 1.6 Add `PointerEnterEvent` callback to `#ZonaMeta` to set `enCurs = false` and call `MinijocUIManager.Instance.FinalitzarCombat("Jugador 1")` if `enCurs` is true.

## 2. Integrate with UI Manager

- [x] 2.1 Update `AmagarTotsElsContenidors` in `MinijocUIManager.cs` to set `_contenidorCablePelat.style.display = DisplayStyle.None`.
- [x] 2.2 In `ShowUI` case 6 (CablePelat), ensure `_contenidorCablePelat` is displayed and `InicialitzarUI` is called.
