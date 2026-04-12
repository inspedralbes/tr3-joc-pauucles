## 1. Actualización de Lógica en Update

- [x] 1.1 Modificar la condición de activación de `escalant` para incluir `Input.GetButton("Jump")` y `Input.GetAxisRaw("Vertical") > 0`.
- [x] 1.2 Añadir la condición `!tocantEscala` al bloque de código encargado del salto para evitar saltos accidentales en zonas de escaleras.

## 2. Actualización de Lógica en FixedUpdate

- [x] 2.1 Implementar la nueva lógica de velocidad vertical cuando `escalant` es `true`.
- [x] 2.2 Asegurar que la velocidad vertical sea `climbSpeed` al subir (Salto/Arriba), `-climbSpeed` al bajar (Abajo), y `0` si no hay entrada.

## 3. Verificación de Código

- [x] 3.1 Comprobar que no haya errores de sintaxis en `Player.cs` tras las modificaciones.
- [x] 3.2 Verificar que el sistema de escalada respete la gravedad original al salir de la escalera.
