## 1. Modificación de la Lógica de Movimiento

- [x] 1.1 Localizar el método `OnActionReceived(ActionBuffers actions)` en `CyborgIA.cs`.
- [x] 1.2 Identificar la línea donde se asigna la velocidad `rb.linearVelocity = dir * moveSpeed;`.
- [x] 1.3 Reemplazar la asignación completa por una asignación parcial que preserve `rb.linearVelocity.y`.

## 2. Refactorización de Acciones Discretas

- [x] 2.1 Asegurar que el cálculo del vector `dir` siga siendo correcto (acciones 3 y 4 para X).
- [x] 2.2 Validar que las acciones verticales (1 y 2) no interfieran negativamente con la inercia de caída libre.

## 3. Verificación y Pruebas

- [x] 3.1 Compilar el proyecto en Unity para asegurar que no hay errores de sintaxis.
- [x] 3.2 Realizar una prueba manual con `Heuristic` para confirmar que el agente cae de los bordes mientras se mueve lateralmente.
