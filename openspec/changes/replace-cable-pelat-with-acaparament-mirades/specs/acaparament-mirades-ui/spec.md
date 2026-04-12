## ADDED Requirements

### Requirement: Variable Replacement
The system SHALL replace the variable `_contenidorCablePelat` with `_contenidorAcaparamentMirades` in `MinijocUIManager`.

#### Scenario: Renaming variable
- **WHEN** searching for `_contenidorCablePelat` in `MinijocUIManager.cs`
- **THEN** it should be renamed to `_contenidorAcaparamentMirades`.

### Requirement: UI Container Selection
The system SHALL find the UI element with the ID `ContenidorAcaparamentMirades` and assign it to `_contenidorAcaparamentMirades`.

#### Scenario: Assigning UI Container
- **WHEN** `ShowUI` is called in `MinijocUIManager.cs`
- **THEN** it finds `root.Q<VisualElement>("ContenidorAcaparamentMirades")`.

### Requirement: Hide Container Logic
The system SHALL hide `_contenidorAcaparamentMirades` when `AmagarTotsElsContenidors` is called.

#### Scenario: Hiding Container
- **WHEN** `AmagarTotsElsContenidors()` is executed
- **THEN** `_contenidorAcaparamentMirades.style.display` is set to `DisplayStyle.None`.

### Requirement: Case 6 Initialization
The system SHALL activate the `_contenidorAcaparamentMirades` and correctly initialize `MinijocAcaparamentMiradesLogic` in `case 6` of the randomizer switch.

#### Scenario: Initialization in ShowUI
- **WHEN** `_activeMinigameId` is 6 in `ShowUI`
- **THEN** `_contenidorAcaparamentMirades` is shown, the logic component is retrieved and `InicialitzarUI(root)` and `IniciarMinijoc()` are called.
