## 1. Ajustes en DroneAI (Cerebro IA)

- [x] 1.1 Definir la variable pública `velocidadCaza = 10f`.
- [x] 1.2 Refactorizar `CollectObservations`: si `portantDino` es true, enviar posición de la base como objetivo; de lo contrario, buscar dinámicamente al portador enemigo.
- [x] 1.3 Modificar `OnActionReceived` para implementar el reposo forzado (si la bandera está a salvo y no la llevamos, anular velocidad y salir).
- [x] 1.4 En `OnActionReceived`, multiplicar el movimiento resultante por `velocidadCaza`.
- [x] 1.5 Implementar en `Update` o `FixedUpdate` la comprobación de proximidad a base (< 1.0f) para soltar el dinosaurio y resetear `portantDino`.

## 2. Ajustes en DroneNetworkSync (Modo Títere)

- [x] 2.1 Asegurar que `DroneAI` y `DecisionRequester` NO se desactiven ni se destruyan en clientes.
- [x] 2.2 En clientes remotos, establecer `Rigidbody2D.isKinematic = true`.
- [x] 2.3 Implementar o ajustar el `Vector3.Lerp` en `Update` para que los clientes remotos sigan la posición sincronizada con un factor de suavizado de 15f.

## 3. Validación y Pruebas

- [x] 3.1 Verificar en modo local (Host) que el dron busca al ladrón y vuelve a la base correctamente usando ML-Agents.
- [x] 3.2 Confirmar en una sesión multijugador que los clientes ven el movimiento fluido sin interferencias físicas de la IA local.
