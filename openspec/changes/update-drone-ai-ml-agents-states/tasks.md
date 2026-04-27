## 1. Actualización de DroneAI.cs (Estructura y Estados)

- [x] 1.1 Definir el enum `GameState` con los valores `A_Salvo`, `Robado` y `Tirado`.
- [x] 1.2 Implementar el método privado `DeterminarEstadoActual()` que actualice una variable de clase según la posición y el parentesco de la bandera.
- [x] 1.3 Modificar `OnEpisodeBegin()` para resetear el dinosaurio a la base al inicio de cada episodio de entrenamiento.

## 2. Implementación de Observaciones y Recompensas

- [x] 2.1 Actualizar `CollectObservations()` para enviar el vector de 10 entradas (Dron, Base, Objetivo, Estado, Velocidad).
- [x] 2.2 Implementar la lógica de recompensas continuas en `FixedUpdate()` o `OnActionReceived()` según el estado actual.
- [x] 2.3 Implementar `OnTriggerEnter2D()` para gestionar las colisiones con objetivos (recompensa positiva) y límites del mapa (recompensa negativa).

## 3. Validación y Limpieza

- [x] 3.1 Comprobar que la lógica de red `DroneNetworkSync` no interfiere con el entrenamiento en el Host.
- [x] 3.2 Realizar una prueba en el editor de Unity usando el componente `Decision Requester` para verificar que el dron intenta moverse hacia los objetivos correctos.
