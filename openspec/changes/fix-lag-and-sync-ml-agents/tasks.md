## 1. Optimización de Red en DroneNetworkSync.cs

- [x] 1.1 Declarar variables de control de tiempo (`lastSendTime`, `sendInterval = 0.1f`) en `DroneNetworkSync.cs`.
- [x] 1.2 Modificar el `Update` de `DroneNetworkSync.cs` para llamar a `SendPosition()` solo cuando haya transcurrido el intervalo de 0.1 segundos.
- [x] 1.3 Asegurar que el `lastSendTime` se actualice correctamente después de cada envío exitoso.

## 2. Consolidación de Movimiento por IA en DroneAI.cs

- [x] 2.1 Eliminar o comentar las llamadas a `MoureDronDirecte()` en el método `Update()` de `DroneAI.cs`.
- [x] 2.2 Eliminar o comentar la implementación completa del método `MoureDronDirecte()` para evitar ejecuciones accidentales.
- [x] 2.3 Verificar que `OnActionReceived()` aplica correctamente el movimiento usando `flySpeed` y `Time.fixedDeltaTime`.

## 3. Mejora de Diagnóstico en MenuManager.cs

- [x] 3.1 Localizar el bloque de procesamiento de `DRONE_MOVE` en `MenuManager.cs`.
- [x] 3.2 Añadir `Debug.LogError` cuando la búsqueda del dron en la lista de `GameManager` (incluyendo la búsqueda de emergencia) falla.
- [x] 3.3 Incluir el `teamId` del dron en el mensaje de error para facilitar la identificación.
