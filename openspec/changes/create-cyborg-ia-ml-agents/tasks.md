## 1. Setup y Estructura Base

- [x] 1.1 Crear el archivo `CyborgIA.cs` en la ruta de scripts del proyecto Unity.
- [x] 1.2 Definir la clase `CyborgIA` heredando de `Agent` e importar `Unity.MLAgents`, `Actuators` y `Sensors`.
- [x] 1.3 Declarar las variables necesarias: `targetDinosaurio`, `baseDestino`, `moveSpeed`, `rb` y `tieneDino`.

## 2. Inicialización y Ciclo de Episodio

- [x] 2.1 Implementar el método `Initialize()` para capturar la referencia al `Rigidbody2D`.
- [x] 2.2 Implementar `OnEpisodeBegin()` reseteando `tieneDino` a false y soltando al dinosaurio (parent = null).
- [x] 2.3 Implementar la lógica de posicionamiento aleatorio (`Random.Range`) para el Cyborg y el dinosaurio al iniciar el episodio.

## 3. Observaciones y Acciones

- [x] 3.1 Implementar `CollectObservations()` agregando `transform.localPosition`, `targetDinosaurio.localPosition`, `baseDestino.localPosition` y el estado de `tieneDino`.
- [x] 3.2 Implementar `OnActionReceived()` para procesar `DiscreteActions[0]` (1-4) y mover al Rigidbody.
- [x] 3.3 Aplicar la penalización de tiempo (`AddReward(-0.001f)`) en cada paso de acción.

## 4. Lógica de Colisión y Recompensas

- [x] 4.1 Implementar `OnCollisionEnter2D()` para gestionar el contacto con el dinosaurio: recompensa de 0.5f, `tieneDino = true` y emparentamiento.
- [x] 4.2 Implementar `OnCollisionEnter2D()` para gestionar el contacto con la base: recompensa de 1f, soltar dinosaurio y llamar a `EndEpisode()`.

## 5. Control Manual y Verificación

- [x] 5.1 Implementar `Heuristic()` para mapear las flechas del teclado a las acciones discretas de movimiento.
- [x] 5.2 Verificar la compilación y realizar una prueba rápida en el editor de Unity usando el modo heurístico.
