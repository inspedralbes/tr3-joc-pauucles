## 1. Limpieza de Lógica de Entrenamiento

- [x] 1.1 Eliminar variables `spawnPoints`, `jugadorObjetivo` y la referencia serializada a `dinosaurio`.
- [x] 1.2 Eliminar el método `OnEpisodeBegin`.
- [x] 1.3 Eliminar todas las llamadas a `AddReward` y `EndEpisode` en el archivo.

## 2. Búsqueda Dinámica y Estados

- [x] 2.1 Declarar `private bool portantDino = false;` y `private Transform dinosaurioTransform;`.
- [x] 2.2 Implementar método privado para buscar el dinosaurio del equipo usando `FindObjectsByType<Bandera>()`.
- [x] 2.3 Actualizar `GetTargetPosition()` para priorizar el portador enemigo o el dinosaurio suelto.

## 3. Captura y Entrega Física

- [x] 3.1 Refactorizar `OnTriggerEnter2D` para capturar al dinosaurio del portador enemigo o del suelo.
- [x] 3.2 Implementar `SetParent(transform)` y resetear `localPosition` tras la captura.
- [x] 3.3 Añadir lógica en `Update()` para detectar proximidad a `baseEquipo` (< 1.0f) y liberar el objetivo.

## 4. Verificación de Observaciones

- [x] 4.1 Asegurar que `CollectObservations` sigue enviando 8 valores (posDron, posBase, posTarget, velDron).
- [x] 4.2 Verificar que `targetPosition` se actualiza correctamente a `baseEquipo.position` cuando `portantDino` es true.
