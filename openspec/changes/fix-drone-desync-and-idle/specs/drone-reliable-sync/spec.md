## ADDED Requirements

### Requirement: Flotación en Reposo
El dron DEBE permanecer estático y flotando sobre su base cuando el objetivo está a salvo.

#### Scenario: Reposo en Base
- **WHEN** El estado del dron es `A_Salvo`.
- **THEN** El sistema DEBE ignorar las acciones de movimiento de ML-Agents y realizar un `Lerp` suave hacia la posición de la base.

### Requirement: Purga de Componentes en Clientes
Los clientes remotos NO DEBEN tener componentes de IA activos para evitar conflictos de movimiento.

#### Scenario: Inicialización de Cliente
- **WHEN** El script `DroneNetworkSync` detecta que el cliente no es el Host.
- **THEN** El sistema DEBE desactivar los componentes `DroneAI`, `BehaviorParameters` y `DecisionRequester`.

### Requirement: Control de Red del Objetivo
El dron DEBE silenciar la red del dinosaurio mientras lo transporta para evitar jitters por múltiples emisores.

#### Scenario: Silenciamiento en Transporte
- **WHEN** El dron captura el dinosaurio (`portantDino = true`).
- **THEN** El sistema DEBE desactivar el componente de sincronización de red (`NetworkSync` o equivalente) del dinosaurio.

#### Scenario: Restauración tras Entrega
- **WHEN** El dron libera el dinosaurio en la base.
- **THEN** El sistema DEBE reactivar el componente de sincronización de red del dinosaurio.
