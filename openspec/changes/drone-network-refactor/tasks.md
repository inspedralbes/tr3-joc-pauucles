## 1. Refactorización de DroneNetworkSync

- [x] 1.1 Modificar `Start()` para destruir `DroneAI` y `DecisionRequester` si no es Host.
- [x] 1.2 Configurar `Rigidbody2D` como `Kinematic` en clientes remotos.
- [x] 1.3 Implementar interpolación rápida (`Lerp` con factor 15f) en `Update()` para clientes remotos.
- [x] 1.4 Asegurar que el Host solo envíe datos de movimiento y no los aplique desde la red sobre sí mismo.

## 2. Refactorización de DroneAI (Autoridad del Host)

- [x] 2.1 Definir variable pública `velocidadCaza = 12f`.
- [x] 2.2 Implementar lógica de REPOSO: Desactivar `DecisionRequester`, poner RB en Kinematic y fijar posición en base.
- [x] 2.3 Implementar lógica de CAZA: Activar `DecisionRequester`, poner RB en Dynamic y aplicar `velocidadCaza` en `OnActionReceived`.
- [x] 2.4 Implementar lógica de RETORNO: Desactivar `DecisionRequester`, poner RB en Kinematic y usar `MoveTowards` hacia la base.
- [x] 2.5 Implementar liberación automática del dinosaurio al llegar a la base y transición a REPOSO.

## 3. Validación y Limpieza

- [x] 3.1 Verificar la correcta transición entre estados en el Host.
- [x] 3.2 Comprobar que los Clientes replican el movimiento sin interferir con la IA localmente.
