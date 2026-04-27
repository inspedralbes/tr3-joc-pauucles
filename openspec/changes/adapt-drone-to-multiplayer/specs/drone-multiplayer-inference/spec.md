## ADDED Requirements

### Requirement: Referencia Dinámica de Objetivos
El sistema DEBE ser capaz de localizar el dinosaurio (bandera) del equipo y identificar al jugador enemigo que lo transporta sin referencias estáticas en el inspector.

#### Scenario: Búsqueda de Bandera
- **WHEN** El dron necesita actualizar sus observaciones.
- **THEN** El sistema DEBE iterar sobre los objetos con el componente `Bandera` para encontrar el que corresponde a su `teamId`.

#### Scenario: Identificación de Portador Enemigo
- **WHEN** La bandera del equipo está siendo transportada por un jugador.
- **THEN** El sistema DEBE identificar el transform del jugador enemigo como el objetivo de navegación actual.

### Requirement: Captura Física en Multijugador
El dron DEBE interceptar físicamente al jugador enemigo o recoger la bandera del suelo mediante contacto.

#### Scenario: Intercepción de Jugador
- **WHEN** El dron colisiona con el jugador enemigo que lleva la bandera de su equipo.
- **THEN** El sistema DEBE desvincular la bandera del jugador, vincularla al dron (`SetParent`), y activar el estado `portantDino`.

### Requirement: Navegación de Entrega
El dron DEBE dirigir sus sensores hacia la base del equipo exclusivamente cuando transporta el objetivo.

#### Scenario: Regreso a Base
- **WHEN** El estado `portantDino` es `true`.
- **THEN** La observación `targetPosition` DEBE ser la posición de la `baseEquipo`.

### Requirement: Finalización de Entrega
El dron DEBE depositar la bandera en la base automáticamente al alcanzar el destino.

#### Scenario: Entrega Exitosa
- **WHEN** El dron está a menos de 1.0 unidades de la base con `portantDino` en `true`.
- **THEN** El sistema DEBE soltar la bandera, colocarla en la base y desactivar `portantDino`.
