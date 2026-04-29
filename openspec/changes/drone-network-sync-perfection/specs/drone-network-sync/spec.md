## ADDED Requirements

### Requirement: Asignación Dinámica de Roles
El sistema DEBE determinar en tiempo de ejecución si el cliente local es el Host o un Cliente remoto para el dron.

#### Scenario: Identificación de Host
- **WHEN** El script se inicia y el jugador local es el creador de la sala.
- **THEN** La variable `isHost` DEBE ser `true` e `isRemote` DEBE ser `false`.

#### Scenario: Identificación de Cliente Remoto
- **WHEN** El script se inicia y el jugador local NO es el creador de la sala.
- **THEN** La variable `isHost` DEBE ser `false` e `isRemote` DEBE ser `true`.

### Requirement: Comportamiento del Cliente Remoto
Los clientes remotos DEBE actuar como meros receptores visuales del movimiento calculado por el Host.

#### Scenario: Configuración de Cliente
- **WHEN** `isRemote` es `true`.
- **THEN** El componente `DroneAI` DEBE desactivarse, el `Rigidbody2D` DEBE establecerse en `Kinematic` y el objeto DEBE interpolar suavemente su posición hacia la recibida por red.

### Requirement: Comunicación del Host
El Host DEBE transmitir periódicamente la posición del dron a todos los clientes.

#### Scenario: Transmisión de Movimiento
- **WHEN** `isHost` es `true`.
- **THEN** El sistema DEBE llamar a la función de red correspondiente en el `MenuManager` enviando la posición actual del transform.

### Requirement: Sincronización de Portador
Los objetos transportados por el dron DEBEN mantener su integridad de sincronización de red.

#### Scenario: Transporte de Dinosaurio
- **WHEN** El dron emparenta al dinosaurio como hijo.
- **THEN** El dinosaurio DEBE seguir sincronizando su posición global para que todos los clientes vean el movimiento solidario con el dron.
