## ADDED Requirements

### Requirement: Neutralización de Cliente IA
El sistema DEBE desactivar o eliminar cualquier capacidad de decisión local en los clientes que no tengan autoridad de Host sobre el dron.

#### Scenario: Inicialización de dron en Cliente
- **WHEN** Un cliente no-Host inicia el componente `DroneNetworkSync`.
- **THEN** El sistema DEBE destruir `DecisionRequester`, desactivar `DroneAI` y establecer `Rigidbody2D` como `Kinematic`.

### Requirement: Interpolación Agresiva
El dron DEBE sincronizar su posición visual de forma casi instantánea con los datos recibidos de red.

#### Scenario: Seguimiento de red en Cliente
- **WHEN** El dron está en modo Cliente y recibe una nueva posición.
- **THEN** El sistema DEBE realizar un `Vector3.Lerp` con un multiplicador de `40f` contra el tiempo delta.

### Requirement: Snap de Posición Forzada
El dron DEBE corregir su posición instantáneamente si la desviación visual supera un umbral crítico.

#### Scenario: Desviación crítica detectada
- **WHEN** La distancia entre la posición local y la posición de red es mayor a `0.5` unidades.
- **THEN** El sistema DEBE forzar la posición local a la posición de red sin interpolación.

### Requirement: Autoridad de Transmisión del Host
El Host DEBE transmitir su posición real continuamente sin permitir que las actualizaciones de red externas modifiquen su propia posición local.

#### Scenario: Actualización de red en Host
- **WHEN** El jugador local es el Host.
- **THEN** El sistema DEBE ignorar cualquier mensaje de red entrante sobre la posición del dron y continuar emitiendo su posición real.
