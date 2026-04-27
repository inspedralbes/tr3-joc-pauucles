## 1. Limpieza de Lógica de Entrenamiento

- [x] 1.1 Eliminar el bloque de aleatorización de spawns en `OnEpisodeBegin`.
- [x] 1.2 Eliminar todas las llamadas a `AddReward` en `OnActionReceived`.
- [x] 1.3 Eliminar todas las llamadas a `EndEpisode` en `OnActionReceived` y otros métodos.

## 2. Implementación de Estado y Captura

- [x] 2.1 Declarar la variable `private bool portantDino = false;` en la clase `DroneAI`.
- [x] 2.2 Modificar `OnTriggerEnter2D` para implementar el "parenting" del dinosaurio cuando se detecte colisión con la bandera o el ladrón.
- [x] 2.3 Asegurar que `portantDino` cambie a `true` tras la captura.

## 3. Navegación y Entrega

- [x] 3.1 Actualizar `GetTargetPosition()` para que devuelva la posición de `baseEquipo` si `portantDino` es `true`.
- [x] 3.2 Añadir el método `Update()` o `FixedUpdate()`.
- [x] 3.3 Implementar en el nuevo método la lógica de soltar el dinosaurio en la base si la distancia es `< 1.0f` y resetear `portantDino` a `false`.
