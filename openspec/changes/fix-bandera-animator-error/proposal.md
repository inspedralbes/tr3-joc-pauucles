## Why

Se ha detectado el error "Animator is not playing an AnimatorController" en la consola de Unity al intentar reproducir la animación de la bandera. Este cambio añade una comprobación de seguridad para asegurar que el componente `Animator` tenga un controlador válido antes de realizar cualquier llamada a sus métodos, evitando errores en tiempo de ejecución.

## What Changes

- Modificación de la lógica de actualización en `Bandera.cs` para incluir una validación de `runtimeAnimatorController`.
- Protección de todas las llamadas a `SetBool` en el componente `anim` para que solo se ejecuten si hay un controlador asignado.

## Capabilities

### New Capabilities
- `safe-animator-access`: Implementación de comprobaciones defensivas para el acceso al componente Animator, garantizando estabilidad si el AnimatorController está ausente.

### Modified Capabilities
<!-- No requirement changes to existing specs -->

## Impact

- Script `Bandera.cs`.
- Estabilidad del sistema de animaciones de la bandera.
