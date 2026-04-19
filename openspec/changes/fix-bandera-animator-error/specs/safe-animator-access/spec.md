## ADDED Requirements

### Requirement: Validación de AnimatorController antes del acceso
El sistema DEBE verificar que el componente `Animator` tenga asignado un `runtimeAnimatorController` válido antes de intentar modificar cualquier parámetro de animación.

#### Scenario: Animator con controlador asignado
- **WHEN** se intenta actualizar una animación Y `anim.runtimeAnimatorController` NO es nulo.
- **THEN** el sistema SHALL proceder con la ejecución de `anim.SetBool`.

#### Scenario: Animator sin controlador asignado
- **WHEN** se intenta actualizar una animación Y `anim.runtimeAnimatorController` ES nulo.
- **THEN** el sistema SHALL omitir la ejecución de `anim.SetBool` para evitar errores en la consola.

### Requirement: Comprobación de componente Animator nulo
El sistema DEBE verificar que la referencia al componente `Animator` NO sea nula antes de acceder a sus propiedades.

#### Scenario: Referencia a Animator válida
- **WHEN** la variable `anim` NO es nula.
- **THEN** el sistema SHALL proceder a validar el controlador.

#### Scenario: Referencia a Animator nula
- **WHEN** la variable `anim` ES nula.
- **THEN** el sistema SHALL omitir cualquier operación sobre el animador.
