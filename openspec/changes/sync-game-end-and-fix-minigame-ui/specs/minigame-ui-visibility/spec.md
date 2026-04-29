## ADDED Requirements

### Requirement: Visibilidad Garantizada del Minijuego
El sistema SHALL asegurar que la interfaz de usuario del minijuego sea visible antes de procesar cualquier lógica de combate.

#### Scenario: Inicio del Minijuego
- **WHEN** Se invoca `IniciarMinijoc`
- **THEN** La raíz de la UI (`UIDocument` o `GameObject` contenedor) debe establecerse en `DisplayStyle.Flex` o `SetActive(true)` inmediatamente
- **THEN** Se procede con la inicialización de la lógica de combate
