## ADDED Requirements

### Requirement: Feedback Visual després de Crear Sala
El sistema HA D'amagar automàticament el pop-up de configuració quan una sala s'ha creat correctament al backend.

#### Scenario: Tancament del pop-up per èxit
- **WHEN** el backend respon amb èxit (Result.Success) a la petició de `/games/create`.
- **THEN** el sistema HA D'assignar `DisplayStyle.None` a l'estil de `popUpCrearSala`.
