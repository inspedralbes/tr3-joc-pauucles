## ADDED Requirements

### Requirement: Control de Movimiento por ML-Agents
El sistema SHALL delegar el control del movimiento de los drones al modelo de ML-Agents cargado en el componente `Agent`.

#### Scenario: Recepción de acciones de movimiento
- **WHEN** el modelo de ML-Agents emite acciones continuas
- **THEN** el componente SHALL extraer los valores de los índices 0 (X) y 1 (Y) y aplicarlos al transform del objeto multiplicado por su velocidad.

### Requirement: Sincronización de Posición IA
El sistema SHALL asegurar que los movimientos decididos por la IA en el Host sean replicados correctamente a los clientes.

#### Scenario: Sincronización post-acción
- **WHEN** el dron se mueve bajo el control de ML-Agents en una instancia Host
- **THEN** el componente `DroneNetworkSync` SHALL capturar la nueva posición y enviarla a través del socket para su sincronización.
