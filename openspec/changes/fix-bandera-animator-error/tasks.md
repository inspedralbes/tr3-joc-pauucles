## 1. Modificación de Bandera.cs

- [x] 1.1 Localizar el método `Update` en `Bandera.cs`.
- [x] 1.2 Modificar la condición de animación reactiva (cuando tiene padre) para incluir la comprobación de `runtimeAnimatorController`.
- [x] 1.3 Localizar el bloque de código de retorno a la base (`fugint == true`).
- [x] 1.4 Modificar las llamadas a `SetBool("isRunning", ...)` y `SetBool("isSad", ...)` para que incluyan la comprobación de seguridad del controlador.

## 2. Verificación

- [x] 2.1 Verificar que el script compila sin errores.
- [ ] 2.2 Confirmar visualmente (si es posible) que el error "Animator is not playing an AnimatorController" ya no aparece en la consola de Unity cuando la bandera se mueve.
