## Context

The `MinijocUIManager` handles the display of different combat minigames. Currently, slot 6 is assigned to "Cable Pelat". The user wants to replace it with "Acaparament de Mirades", including variable names and logic calls.

## Goals / Non-Goals

**Goals:**
- Refactor `MinijocUIManager.cs` to use `_contenidorAcaparamentMirades` instead of `_contenidorCablePelat`.
- Ensure the new container is properly assigned and hidden.
- Integrate the "Acaparament de Mirades" logic initialization in `ShowUI`.

**Non-Goals:**
- Implementing the actual gameplay logic of "Acaparament de Mirades" (this will be stubbed).
- Deleting the `MinijocCablePelatLogic.cs` file (just removing references in `MinijocUIManager`).

## Decisions

- **Variable Refactoring**: All occurrences of `_contenidorCablePelat` will be replaced by `_contenidorAcaparamentMirades`.
- **Component Access**: Use `GetComponent<MinijocAcaparamentMiradesLogic>()` to retrieve the logic controller on the same GameObject as `MinijocUIManager`.
- **Logic Method Stubs**: `MinijocAcaparamentMiradesLogic.cs` must be modified to ensure the calls from `MinijocUIManager.cs` don't cause compiler errors.

## Risks / Trade-offs

- [Risk] → **Compiler Errors**: If `MinijocAcaparamentMiradesLogic` is not updated before `MinijocUIManager`, the project won't compile. 
- [Mitigation] → The `tasks.md` will prioritize updating the logic script first.
- [Risk] → **UI Element Names**: If the UXML doesn't have `ContenidorAcaparamentMirades`, the UI element will be null.
- [Mitigation] → We will assume the UXML matches the requested name.
