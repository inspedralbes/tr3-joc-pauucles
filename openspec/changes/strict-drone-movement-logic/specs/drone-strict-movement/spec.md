## ADDED Requirements

### Requirement: Reposo Absoluto en Base
El dron DEBE permanecer inmóvil en su base cuando el objetivo está a salvo y no lo transporta.

#### Scenario: Reposo en base
- **WHEN** `portantDino` es `false` Y el dinosaurio está a menos de 1.5 unidades de la base Y no tiene padre.
- **THEN** El sistema DEBE anular la velocidad del `Rigidbody2D`, forzar la posición a la de la base e ignorar cualquier entrada de la IA.

### Requirement: Modo Caza Condicional
El dron SOLO DEBE procesar las acciones de la IA cuando el objetivo es una prioridad activa.

#### Scenario: Activación de búsqueda
- **WHEN** El dinosaurio tiene un padre (robado) O está a más de 1.5 unidades de la base.
- **THEN** El sistema DEBE permitir que las acciones de ML-Agents muevan el dron.

### Requirement: Retorno Determinista
El dron DEBE ignorar a la IA y regresar matemáticamente a la base cuando transporta el objetivo.

#### Scenario: Regreso con carga
- **WHEN** `portantDino` es `true`.
- **THEN** El sistema DEBE mover al dron usando `Vector3.MoveTowards` hacia la base, ignorando las acciones de ML-Agents.

### Requirement: Finalización de Entrega
El dron DEBE depositar el objetivo exactamente en la base al llegar.

#### Scenario: Llegada a base
- **WHEN** El dron transporta el dinosaurio Y la distancia a la base es inferior a 0.5 unidades.
- **THEN** El sistema DEBE desvincular el dinosaurio, posicionarlo exactamente en la base, establecer `portantDino` a `false` y activar el reposo absoluto.
