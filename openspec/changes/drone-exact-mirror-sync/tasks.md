## 1. Neutralización de Componentes en Cliente

- [x] 1.1 Modificar `CheckHostStatus()` en `DroneNetworkSync.cs` para identificar correctamente el rol local.
- [x] 1.2 Implementar la destrucción de `DecisionRequester` en clientes no-Host.
- [x] 1.3 Desactivar `DroneAI` en clientes no-Host.
- [x] 1.4 Configurar el `Rigidbody2D` como `Kinematic` en clientes no-Host.

## 2. Movimiento Estricto e Interpolación Agresiva

- [x] 2.1 Actualizar el bloque `Update()` de clientes remotos para usar un factor de `40f` en el `Lerp`.
- [x] 2.2 Implementar la regla de snap: si la distancia a `posicionRed` es > 0.5f, forzar `transform.position = posicionRed`.
- [x] 2.3 Asegurar que el Host ignore el posicionamiento visual entrante por red para evitar jitters locales.

## 3. Verificación de Transmisión del Host

- [x] 3.1 Confirmar que el Host sigue emitiendo la posición del dron sin interrupciones.
- [x] 3.2 Verificar que el mensaje de red incluye todos los datos necesarios para el snap y la interpolación en el cliente.
