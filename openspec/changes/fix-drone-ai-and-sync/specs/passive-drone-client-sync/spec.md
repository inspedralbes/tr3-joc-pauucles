## ADDED Requirements

### Requirement: Modo Pasivo para Clientes Remotos
Los clientes que no sean el Host de la sala SHALL tratar a los drones como entidades puramente visuales, delegando toda la lógica de movimiento al servidor/Host.

#### Scenario: Configuración de componentes remotos
- **WHEN** un dron se inicializa con `isRemote = true`
- **THEN** el sistema SHALL desactivar el componente `DroneAI` y configurar el `Rigidbody2D` como `Kinematic`.

### Requirement: Interpolación Visual de Red
El sistema SHALL suavizar el movimiento de los drones en los clientes para compensar el lag y la frecuencia de actualización de red.

#### Scenario: Aplicación de movimiento por red
- **WHEN** se recibe una nueva `targetPosition` vía mensaje `DRONE_MOVE`
- **THEN** el transform del dron SHALL realizar un `Vector3.Lerp` hacia dicha posición de forma continua en el `Update`.
