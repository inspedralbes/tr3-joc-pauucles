## ADDED Requirements

### Requirement: Determinación Dinámica de Autoridad
El script DEBE determinar al inicio si el cliente local tiene autoridad sobre el dron.

#### Scenario: Inicio en modo Cliente
- **WHEN** El componente se inicia y `MenuManager.IsHost` es `false`.
- **THEN** El sistema DEBE establecer un estado interno de no-autoridad.

### Requirement: Desactivación de Lógica en Cliente
Los clientes remotos DEBEN deshabilitar cualquier componente que afecte la posición local del dron de forma autónoma.

#### Scenario: Configuración de componentes en Cliente
- **WHEN** El jugador es un Cliente (!isHost).
- **THEN** El sistema DEBE desactivar `DecisionRequester`, desactivar `DroneAI` y establecer el `Rigidbody2D` como `Kinematic`.

### Requirement: Interpolación Suave en Cliente
El dron DEBE seguir la posición de red con un movimiento fluido en las máquinas de los clientes.

#### Scenario: Movimiento en Cliente
- **WHEN** El objeto está en modo Cliente.
- **THEN** El sistema DEBE interpolar su posición hacia la coordenada de red usando `Vector3.Lerp` con un factor de suavizado de `15f`.

### Requirement: Transmisión de Datos del Host
El Host DEBE ser el único encargado de difundir la posición real del dron.

#### Scenario: Envío de posición desde Host
- **WHEN** El jugador es el Host.
- **THEN** El sistema DEBE leer la posición actual y enviarla mediante el sistema de eventos de red.
