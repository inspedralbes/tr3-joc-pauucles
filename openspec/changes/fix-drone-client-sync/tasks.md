## 1. Registro Robusto de Drones

- [x] 1.1 Modificar `DroneAI.cs` para asegurar el registro en `Initialize`.
- [x] 1.2 Añadir registro redundante en `DroneNetworkSync.cs` durante el `Start`.
- [x] 1.3 Implementar búsqueda de emergencia en `MenuManager.cs` si un dron no está en la lista de `GameManager`.

## 2. Corrección de Sincronización y Eje Z

- [x] 2.1 Corregir `DroneNetworkSync.cs` para preservar `transform.position.z` en `ReceiveUpdate`.
- [x] 2.2 Revisar y ajustar el envío de `flipX` y `state` en `SendPosition`.

## 3. Implementación de Logs y Verificación

- [x] 3.1 Añadir logs de recepción en `MenuManager.cs` (cada 300 frames para evitar saturación).
- [x] 3.2 Añadir logs de aplicación de movimiento en `DroneNetworkSync.cs`.
- [x] 3.3 Verificar que el Host envía los paquetes correctamente y el Cliente los procesa.
