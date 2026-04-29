## 1. Declaración de Variables y Referencias

- [x] 1.1 Actualizar valores por defecto de `moveSpeed` (5f) y `jumpForce` (7f) en `Player.cs`.
- [x] 1.2 Añadir variable pública `climbSpeed` con valor 4f.
- [x] 1.3 Declarar variables booleanas privadas `tocantEscala` y `escalant`.

## 2. Movimiento Horizontal y Orientación

- [x] 2.1 Refactorizar el cálculo de `moveInput` para usar `Input.GetAxisRaw("Horizontal")`.
- [x] 2.2 Implementar la rotación del personaje modificando `transform.localScale.x` basado en la dirección del movimiento.
- [x] 2.3 Asegurar que la rotación se aplique solo cuando hay entrada horizontal activa.

## 3. Restricciones y Lógica de Salto

- [x] 3.1 Modificar la condición de salto para incluir la validación de `!escalant`.
- [x] 3.2 Añadir comprobación de velocidad vertical `Mathf.Abs(rb.linearVelocity.y) < 0.1f` (o similar) como refuerzo de `isGrounded`.

## 4. Detección de Escaleras

- [x] 4.1 Implementar `OnTriggerEnter2D` para detectar el tag "ZonaEscalera" y activar `tocantEscala`.
- [x] 4.2 Implementar `OnTriggerExit2D` para desactivar `tocantEscala` y `escalant` al salir de la zona.
- [x] 4.3 Asegurar que el `originalGravity` se restablezca correctamente al salir de la escalera.

## 5. Mecánicas de Escalado

- [x] 5.1 En `Update`, detectar entrada vertical (`Input.GetAxisRaw("Vertical")`) cuando `tocantEscala` sea true para activar `escalant`.
- [x] 5.2 Implementar `FixedUpdate` para gestionar la física del escalado: poner `rb.gravityScale` a 0 y aplicar velocidad vertical si `escalant` es true.
- [x] 5.3 Implementar el retorno a `rb.gravityScale = 1` (usando `originalGravity`) cuando no se esté escalando.
