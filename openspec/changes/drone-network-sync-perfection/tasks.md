## 1. Configuración de Roles y Estado Inicial

- [x] 1.1 Modificar `DroneNetworkSync.cs` para incluir las variables `isHost` e `isRemote`.
- [x] 1.2 Implementar en `Start()` la lógica de asignación de roles consultando al `GameManager` o `MenuManager`.
- [x] 1.3 Si `isRemote` es true, desactivar el componente `DroneAI` y configurar el `Rigidbody2D` como `Kinematic`.

## 2. Implementación de Sincronización

- [x] 2.1 En el Host, implementar el envío periódico de la posición del dron mediante el evento `DRONE_MOVE` a través de `MenuManager`.
- [x] 2.2 En el Cliente remoto, implementar la interpolación suave (`Lerp`) de la posición actual hacia la posición recibida por red en el `Update()`.
- [x] 2.3 Asegurar que la rotación también se sincronice o se mantenga fija según los requisitos visuales.

## 3. Sincronización de Objetos Emparentados

- [x] 3.1 Verificar que el script de red del Dinosaurio/Bandera no se desactive cuando es hijo del dron.
- [x] 3.2 Realizar pruebas de transporte en entorno multijugador para confirmar que todos los clientes ven el dinosaurio junto al dron.
