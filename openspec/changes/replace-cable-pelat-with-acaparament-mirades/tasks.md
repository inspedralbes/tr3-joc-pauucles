## 1. Prepare Minigame Logic Component

- [x] 1.1 Update `MinijocAcaparamentMiradesLogic.cs` to inherit from `MonoBehaviour` and use `using UnityEngine.UIElements;`.
- [x] 1.2 Add stub methods `InicialitzarUI(VisualElement root)` and `IniciarMinijoc()` to `MinijocAcaparamentMiradesLogic.cs`.

## 2. Refactor UI Manager

- [x] 2.1 Rename `_contenidorCablePelat` to `_contenidorAcaparamentMirades` in variable declarations of `MinijocUIManager.cs`.
- [x] 2.2 Update UI container assignment in `ShowUI` to find `root.Q<VisualElement>("ContenidorAcaparamentMirades")`.
- [x] 2.3 Update `AmagarTotsElsContenidors` to hide `_contenidorAcaparamentMirades`.
- [x] 2.4 Update `ShowUI` case 6:
    - Set `_contenidorAcaparamentMirades.style.display = DisplayStyle.Flex`.
    - Retrieve `MinijocAcaparamentMiradesLogic` component.
    - Call `logic.InicialitzarUI(root)` and `logic.IniciarMinijoc()`.
