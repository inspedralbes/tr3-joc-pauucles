## Context

El script `Player.cs` gestiona diversas interacciones mediante disparadores (triggers), como la entrada y salida de zonas de escaleras o bases. Los eventos de salida (`OnTriggerExit2D`) son propensos a errores si el objeto colisionante se destruye o si la referencia se vuelve inválida en el preciso momento de la salida, provocando que el motor de Unity pase una referencia nula o inconsistente al script.

## Goals / Non-Goals

**Goals:**
- Eliminar el `NullReferenceException` en `OnTriggerExit2D`.
- Asegurar que la lógica de salida de zonas interactivas sea robusta.
- Mantener la limpieza del código mediante el uso de "Guard Clauses".

**Non-Goals:**
- No se modificará la lógica de entrada (`OnTriggerEnter2D`) a menos que se detecte un riesgo similar.
- No se cambiarán las etiquetas (Tags) ni la configuración física de los triggers.

## Decisions

- **Guard Clause Inicial**: Se implementará un chequeo `if (other == null || other.gameObject == null) return;` en la primera línea del método. Esto es una práctica estándar de alto rendimiento que evita el procesamiento innecesario de eventos inválidos.
- **Validación de Componentes**: Cualquier acceso a componentes internos (como `Rigidbody2D`) o variables de estado (como `banderaAgafada`) durante el evento de salida se realizará dentro de bloques condicionales de validación.
- **Lógica Específica de Escaleras**: La desactivación de `isNearLadder` y `isClimbing` se protegerá para asegurar que solo ocurra si el objeto que sale es efectivamente una escalera válida.

## Risks / Trade-offs

- **[Riesgo] Omisión de lógica necesaria** → **[Mitigación]** La guard clause solo se activa si el objeto es nulo, lo cual significa que no hay nada que procesar. Si el objeto existe, la lógica seguirá fluyendo normalmente.
- **[Riesgo] Estabilidad de la gravedad** → **[Mitigación]** Al salir de una escalera, se asegura que el script verifique la existencia del `Rigidbody2D` antes de intentar restaurar `gravityScale`.
