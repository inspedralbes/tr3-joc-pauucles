## 1. Configuración de Autoridad

- [x] 1.1 Implementar la detección de Host en `Start()` de `DroneNetworkSync.cs`.
- [x] 1.2 Definir estados de componentes para Clientes: Desactivar `DroneAI`, `DecisionRequester` y poner `Rigidbody2D` en `isKinematic`.

## 2. Lógica de Red para el Host

- [x] 2.1 En el Host (`Update()`), capturar la posición real del dron.
- [x] 2.2 Emitir la posición a la red mediante el evento correspondiente en `MenuManager` o `WebSocketClient`.

## 3. Lógica Visual para Clientes

- [x] 3.1 En el Cliente (`Update()`), recibir la posición de red.
- [x] 3.2 Aplicar `Vector3.Lerp` con factor `15f` hacia la posición recibida.

## 4. Validación

- [x] 4.1 Verificar en modo local (Host) que el dron sigue funcionando con normalidad.
- [x] 4.2 Verificar en modo remoto (Cliente) que el dron se mueve fluidamente sin interferencias de la IA local.
