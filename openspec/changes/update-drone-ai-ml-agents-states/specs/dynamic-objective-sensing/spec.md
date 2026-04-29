## ADDED Requirements

### Requirement: Observación Dinámica del Objetivo
El sensor del dron SHALL enfocar sus observaciones en el punto de interés más relevante según el estado del juego.

#### Scenario: Cambio de objetivo de observación
- **WHEN** el estado cambia de `A_Salvo` a `Robado`
- **THEN** la observación de `posTarget` SHALL cambiar de la posición de la base a la posición del jugador enemigo que posee el dinosaurio.

### Requirement: Vector de Observaciones Estructurado
El sistema SHALL proveer un vector de observaciones consistente para que la red neuronal pueda aprender las relaciones espaciales.

#### Scenario: Contenido del vector de observaciones
- **WHEN** se invoca `CollectObservations`
- **THEN** el sistema SHALL añadir al sensor la posición del dron, la posición de la base, la posición del objetivo y el ID del estado (0, 1 o 2).
