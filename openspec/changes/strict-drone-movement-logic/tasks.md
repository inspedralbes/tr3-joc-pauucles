## 1. Implementación de Reposo Absoluto

- [x] 1.1 Modificar `OnActionReceived` en `DroneAI.cs` para detectar el estado de reposo (dino en base, no transportado).
- [x] 1.2 Implementar el bloqueo físico en `OnActionReceived`: `rb.linearVelocity = Vector2.zero` y forzar `transform.position = baseEquipo.position`.
- [x] 1.3 Insertar `return;` temprano para ignorar el procesamiento de ML-Agents en reposo.

## 2. Refactorización de Modo Caza y Retorno

- [x] 2.1 Actualizar la lógica de `OnActionReceived` para que solo procese movimiento IA si el dinosaurio está fuera de la base o robado.
- [x] 2.2 Implementar el retorno determinista en `Update()` cuando `portantDino` es true usando `Vector3.MoveTowards`.
- [x] 2.3 Asegurar que en el modo retorno determinista se sigan ignorando las acciones de ML-Agents.

## 3. Lógica de Entrega Determinista

- [x] 3.1 Ajustar el umbral de entrega en `Update()` a `< 0.5f` de la base.
- [x] 3.2 Implementar la limpieza de entrega: `SetParent(null)`, posicionamiento exacto y reset de `portantDino`.
- [x] 3.3 Verificar la reactivación correcta de la sincronización de red de la bandera tras la entrega.
