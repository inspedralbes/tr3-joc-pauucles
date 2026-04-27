## ADDED Requirements

### Requirement: Throttling de Mensajes de Red
El sistema SHALL limitar la frecuencia de envío de la posición del dron desde el Host para evitar saturar el ancho de banda y causar lag en los clientes.

#### Scenario: Envío periódico de posición
- **WHEN** el dron se mueve bajo control de la IA
- **THEN** el Host SHALL enviar el mensaje `DRONE_MOVE` a través del WebSocket con un intervalo mínimo de 0.1 segundos (10 veces por segundo).

### Requirement: Control Exclusivo por ML-Agents
El movimiento del dron SHALL ser calculado exclusivamente a través de las acciones recibidas por el modelo de ML-Agents para evitar conflictos con lógicas manuales.

#### Scenario: Aplicación de movimiento por IA
- **WHEN** el método `OnActionReceived` es invocado
- **THEN** el sistema SHALL aplicar el vector de movimiento basado en las acciones continuas y SHALL ignorar cualquier otra entrada de movimiento manual.

### Requirement: Validación de Instanciación en Cliente
El sistema SHALL alertar si se reciben actualizaciones para una entidad que no ha sido correctamente inicializada en el cliente local.

#### Scenario: Recepción de datos para entidad faltante
- **WHEN** el `MenuManager` recibe un mensaje `DRONE_MOVE` para un ID de dron que no existe en `dronsEscena`
- **THEN** el sistema SHALL emitir un error `Debug.LogError` indicando que el dron no ha sido instanciado.
