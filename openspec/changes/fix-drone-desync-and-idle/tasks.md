## 1. Mejoras de Reposo en DroneAI

- [x] 1.1 Modificar `OnActionReceived` en `DroneAI.cs` para retornar inmediatamente si `currentState == DroneState.A_Salvo`.
- [x] 1.2 Implementar en `Update()` (o `FixedUpdate()`) una lógica de `Vector3.Lerp` hacia `baseEquipo.position` y poner `rb.linearVelocity = Vector2.zero` cuando el dron esté en reposo.

## 2. Refuerzo de Modo Títere en DroneNetworkSync

- [x] 2.1 Modificar `CheckHostStatus()` (o `Start()`) en `DroneNetworkSync.cs` para que, si `isRemote` es true, desactive explícitamente `DroneAI`, `BehaviorParameters` y `DecisionRequester`.
- [x] 2.2 Asegurar que el `Rigidbody2D` se mantenga en `Kinematic` para evitar cualquier movimiento por colisiones locales.

## 3. Gestión de Red de la Bandera en DroneAI

- [x] 3.1 Al capturar la bandera (`OnTriggerEnter2D`), buscar el componente de sincronización de red (ej. `NetworkSync`) en `dinosaurioTransform` y desactivarlo.
- [x] 3.2 Al realizar la entrega en base (`Update`), reactivar el componente de sincronización de red de la bandera.
