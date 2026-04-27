## 1. IA Robusta en DroneAI.cs

- [x] 1.1 Implementar búsqueda dinámica del objetivo en `CollectObservations`: buscar bandera en suelo o portador.
- [x] 1.2 Añadir null-checks estrictos a los objetos `banderaPrefab`, `basePunt` y referencias de jugadores.
- [x] 1.3 Asegurar un fallback a `Vector3.zero` en las observaciones para evitar el crasheo del sensor.

## 2. Configuración de Espectador en DroneNetworkSync.cs

- [x] 2.1 Modificar `CheckHostStatus` para configurar correctamente `isRemote` y desactivar `DroneAI` en clientes.
- [x] 2.2 Forzar `Rigidbody2D.bodyType = RigidbodyType2D.Kinematic` en instancias remotas.
- [x] 2.3 Implementar el `Vector3.Lerp` visual en el `Update` cuando `isRemote` es verdadero.

## 3. Verificación de Flujo en MenuManager.cs

- [x] 3.1 Añadir un log de depuración (`[DRONE-NET]`) al recibir mensajes `DRONE_MOVE` para trazar el flujo.
- [x] 3.2 Asegurar que el cliente encuentra el dron en `GameManager.Instance.dronsEscena` antes de aplicar el update.
- [x] 3.3 Añadir un warning informativo si se recibe un movimiento para un dron no instanciado en el cliente.
