## 1. Auditoría y Preparación

- [x] 1.1 Localizar el método `OnTriggerExit2D` en `Player.cs`.
- [x] 1.2 Identificar todas las referencias a `other`, `gameObject` y variables de estado internas dentro del método.

## 2. Implementación de Seguridad

- [x] 2.1 Añadir la Guard Clause al inicio del método: `if (other == null || other.gameObject == null) return;`.
- [x] 2.2 Asegurar que la comprobación `if (other.CompareTag("ZonaEscalera"))` se mantenga segura tras la guard clause.
- [x] 2.3 Validar la existencia de `rb` (Rigidbody2D) antes de restaurar `gravityScale` dentro de la lógica de escaleras.
- [x] 2.4 Revisar y proteger cualquier otra lógica que acceda a componentes externos o variables de estado que puedan ser nulas.

## 3. Verificación

- [x] 3.1 Verificar que el script compila sin errores.
- [x] 3.2 Confirmar que el NullReferenceException ya no se produce al salir de triggers.
- [x] 3.3 Validar que el comportamiento de las escaleras y otras zonas interactivas sigue funcionando correctamente.
