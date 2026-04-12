## Why

Replace the "Cable Pelat" minigame in the `MinijocUIManager` with the "Acaparament de Mirades" minigame. This involves renaming variables, updating UI container selection, and correctly initializing the new minigame logic.

## What Changes

- **MinijocUIManager.cs**:
    - Replace `_contenidorCablePelat` with `_contenidorAcaparamentMirades`.
    - Update `ShowUI` to find `#ContenidorAcaparamentMirades` instead of `#ContenidorCablePelat`.
    - Update `AmagarTotsElsContenidors` to hide `_contenidorAcaparamentMirades`.
    - Update `ShowUI` case 6:
        - Activate `_contenidorAcaparamentMirades`.
        - Get `MinijocAcaparamentMiradesLogic` component.
        - Call `logic.InicialitzarUI(root)` and `logic.IniciarMinijoc()`.
- **MinijocAcaparamentMiradesLogic.cs**:
    - Update to inherit from `MonoBehaviour` and include `using UnityEngine.UIElements;`.
    - Add `InicialitzarUI(VisualElement root)` and `IniciarMinijoc()` methods (stubs to ensure compilation).

## Capabilities

### New Capabilities
- `acaparament-mirades-ui`: Implementation of UI integration for the "Acaparament de Mirades" minigame.

### Modified Capabilities
- `minijoc-cable-pelat`: This capability will be removed or replaced by "Acaparament de Mirades" in the UI Manager.

## Impact

Affects `MinijocUIManager` and replaces one minigame slot (ID 6) in the randomizer logic.
