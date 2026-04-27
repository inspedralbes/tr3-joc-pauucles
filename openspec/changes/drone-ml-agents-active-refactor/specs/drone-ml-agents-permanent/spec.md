## ADDED Requirements

### Requirement: Observaciones Adaptativas
El dron DEBE ajustar sus observaciones sensoriales según su estado de misión para guiar a la red neuronal hacia el objetivo correcto.

#### Scenario: Búsqueda de dinosaurio
- **WHEN** `portantDino` es `false`.
- **THEN** El sistema DEBE observar la posición del jugador enemigo que transporta la bandera del equipo.

#### Scenario: Retorno a base
- **WHEN** `portantDino` es `true`.
- **THEN** El sistema DEBE observar la posición de `BaseEquipo`.

### Requirement: Reposo Forzado y Velocidad Aumentada
El dron DEBE anular el movimiento físico en reposo y responder con mayor agresividad durante la acción.

#### Scenario: Bloqueo en reposo
- **WHEN** `portantDino` es `false` Y la bandera está en la base.
- **THEN** El sistema DEBE establecer la velocidad del `Rigidbody2D` a cero e ignorar el procesamiento de acciones.

#### Scenario: Movimiento de caza
- **WHEN** El dron tiene un objetivo activo.
- **THEN** El sistema DEBE aplicar las acciones de la IA multiplicadas por `velocidadCaza = 10f`.

### Requirement: Liberación Autónoma en Base
El dron DEBE soltar el objetivo automáticamente al alcanzar el destino de entrega.

#### Scenario: Entrega exitosa
- **WHEN** `portantDino` es `true` Y la distancia a la base es inferior a 1.0 unidades.
- **THEN** El sistema DEBE desvincular el dinosaurio, posicionarlo en la base y desactivar `portantDino`.

### Requirement: Sincronización No Invasiva en Clientes
Los clientes DEBEN mantener la IA activa para coherencia visual pero ceder el control físico a la red.

#### Scenario: Modo títere sincronizado
- **WHEN** El cliente no es Host.
- **THEN** El sistema DEBE mantener `DroneAI` encendido, poner el Rigidbody en `Kinematic` e interpolar suavemente hacia la posición recibida por red.
