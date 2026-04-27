## ADDED Requirements

### Requirement: Autoridad de Red Exclusiva del Host
El sistema DEBE garantizar que solo el Host tenga componentes activos de IA y el control físico del dron.

#### Scenario: Cliente no-Host inicializa dron
- **WHEN** Un cliente que no es el creador de la sala inicia el script `DroneNetworkSync`.
- **THEN** El sistema DEBE destruir los componentes `DroneAI` y `DecisionRequester`, y establecer el `Rigidbody2D` como `Kinematic`.

### Requirement: Replicación Visual de Alta Velocidad
Los clientes DEBEN seguir la posición del Host con el menor retraso visual posible.

#### Scenario: Actualización de posición en Cliente
- **WHEN** El cliente recibe un mensaje de red con la nueva posición del dron.
- **THEN** El sistema DEBE realizar un `Vector3.Lerp` con un factor de suavizado de `15f` hacia esa posición.

### Requirement: Estado de Reposo Determinista
El dron DEBE anclarse a su base cuando no hay una misión de búsqueda o transporte activa.

#### Scenario: Dron en reposo
- **WHEN** El dinosaurio está en la base y `portantDino` es `false`.
- **THEN** El sistema DEBE desactivar el `DecisionRequester`, poner el Rigidbody en `Kinematic` y fijar el Transform exactamente en la base.

### Requirement: Estado de Caza Dinámico
El dron DEBE activar su IA para localizar y capturar objetivos fuera de la base.

#### Scenario: Inicio de caza
- **WHEN** El dinosaurio es robado por un enemigo o está fuera de la base y el dron no lo lleva.
- **THEN** El sistema DEBE activar el `DecisionRequester`, poner el Rigidbody en `Dynamic` y utilizar `velocidadCaza = 12f` en sus acciones.

### Requirement: Retorno Físico Inmune
El dron DEBE priorizar el regreso seguro a la base sobre cualquier otra decisión de la IA al transportar el objetivo.

#### Scenario: Retorno con dinosaurio
- **WHEN** `portantDino` es `true`.
- **THEN** El sistema DEBE desactivar el `DecisionRequester`, poner el Rigidbody en `Kinematic` y mover el dron linealmente hacia la base ignorando obstáculos.
