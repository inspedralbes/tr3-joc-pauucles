## ADDED Requirements

### Requirement: Identificación del Estado del Objetivo (Dinosaurio)
El sistema DEBE identificar dinámicamente el estado del dinosaurio del equipo para determinar el objetivo actual del dron. Los estados son:
- **A_Salvo**: El dinosaurio está en la base del equipo.
- **Robado**: El dinosaurio tiene un padre (parent != null), indicando que un jugador lo tiene.
- **Tirado**: El dinosaurio no está en la base ni lo tiene un jugador (está en el suelo).

#### Scenario: Dinosaurio en base
- **WHEN** el dinosaurio está dentro del área definida como base del equipo.
- **THEN** el estado se identifica como A_Salvo y el objetivo del dron es la base.

#### Scenario: Dinosaurio capturado por jugador
- **WHEN** el transform del dinosaurio tiene un padre asignado.
- **THEN** el estado se identifica como Robado y el objetivo del dron es la posición del jugador que lo lleva.

#### Scenario: Dinosaurio en el suelo
- **WHEN** el dinosaurio no está en la base y no tiene padre asignado.
- **THEN** el estado se identifica como Tirado y el objetivo del dron es la posición del dinosaurio.

### Requirement: Recolección de Observaciones para ML-Agents
El sistema DEBE recolectar exactamente 8 valores numéricos seguros para el sensor vectorial del agente, evitando valores nulos.
Las observaciones son:
1. Posición del dron (X, Y).
2. Posición de la base del equipo (X, Y).
3. Posición del objetivo actual (X, Y) según el estado del dinosaurio.
4. Velocidad actual del dron (X, Y).

#### Scenario: Actualización de observaciones
- **WHEN** el método CollectObservations es llamado por el Agent.
- **THEN** se añaden 8 valores float al sensor vectorial que representan las posiciones y velocidades mencionadas.

### Requirement: Control de Movimiento Continuo
El sistema DEBE aplicar fuerzas de movimiento al dron basándose en las acciones continuas recibidas de la red neuronal, multiplicadas por un factor de velocidad y el tiempo delta.

#### Scenario: Aplicación de acciones de movimiento
- **WHEN** se reciben acciones en OnActionReceived.
- **THEN** el dron se desplaza en los ejes X e Y proporcionalmente a los valores de acción recibidos.

### Requirement: Sistema de Recompensas por Proximidad
El sistema DEBE otorgar recompensas incrementales al agente basándose en la reducción de la distancia hacia el objetivo actual en cada paso de simulación.

#### Scenario: Recompensa por acercamiento
- **WHEN** la distancia actual al objetivo es menor que la distancia en el paso anterior.
- **THEN** el agente recibe una recompensa positiva (ej. 0.01f).
