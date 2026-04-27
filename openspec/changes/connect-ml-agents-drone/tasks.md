## 1. Preparación de DroneAI.cs

- [x] 1.1 Comentar o eliminar la llamada a `MoureDronDirecte()` en el método `Update` de `DroneAI.cs`.
- [x] 1.2 Comentar o eliminar cualquier lógica de actualización manual de `currentState` que interfiera con la IA si fuera necesario.

## 2. Implementación de Acciones de ML-Agents

- [x] 2.1 Implementar el método `public override void OnActionReceived(ActionBuffers actions)` en `DroneAI.cs`.
- [x] 2.2 Extraer las acciones continuas: `float moveX = actions.ContinuousActions[0]` y `float moveY = actions.ContinuousActions[1]`.
- [x] 2.3 Calcular el vector de movimiento y aplicarlo a `transform.position` usando `flySpeed` y `Time.fixedDeltaTime`.
- [x] 2.4 Asegurar que el eje Z se mantenga en `-0.15f` tras aplicar el movimiento de la IA.

## 3. Integración con el Sistema de Red

- [x] 3.1 Verificar que `DroneNetworkSync.cs` sigue enviando la posición correctamente en el Host después de los cambios en `DroneAI.cs`.
- [x] 3.2 Realizar una prueba visual para confirmar que el dron se mueve según el modelo de IA en el cliente.
