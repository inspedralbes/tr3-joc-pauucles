## ADDED Requirements

### Requirement: Desacoplamiento del ML-Agents Toolkit
El dron DEBE funcionar de manera continua sin depender de señales de recompensa o finalización de episodio externas durante el juego real.

#### Scenario: Flujo de juego continuo
- **WHEN** El dron está en funcionamiento durante una partida.
- **THEN** El sistema NO DEBE llamar a `AddReward` ni a `EndEpisode` bajo ninguna circunstancia de colisión o proximidad.

### Requirement: Captura y Transporte de Objetivo
El dron DEBE ser capaz de recoger el dinosaurio (bandera) físicamente y mantenerlo vinculado a su posición durante el transporte.

#### Scenario: Recogida exitosa
- **WHEN** El dron colisiona con el dinosaurio (componente `Bandera`) o el jugador ladrón (tag `Player`).
- **THEN** El dinosaurio DEBE convertirse en hijo del dron, su `localPosition` DEBE ser `(0,0,0)` y el estado `portantDino` DEBE ser `true`.

### Requirement: Navegación de Regreso
El dron DEBE priorizar la base del equipo como objetivo de navegación una vez que haya capturado el dinosaurio.

#### Scenario: Navegación con carga
- **WHEN** El estado `portantDino` es `true`.
- **THEN** La observación de `posTarget` en `CollectObservations` DEBE devolver la posición de la `baseEquipo`.

### Requirement: Entrega en Base
El dron DEBE soltar el dinosaurio en la base cuando alcance una proximidad suficiente.

#### Scenario: Entrega exitosa
- **WHEN** El estado `portantDino` es `true` y la distancia a la base es inferior a 1.0 unidades.
- **THEN** El sistema DEBE desvincular al dinosaurio (`SetParent(null)`), colocarlo exactamente en la posición de la base y establecer `portantDino` a `false`.
