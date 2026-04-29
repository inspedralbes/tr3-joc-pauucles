## ADDED Requirements

### Requirement: Discriminación de Equipos en Bases
El sistema DEBE identificar si una base pertenece al mismo equipo que el jugador o al equipo contrario basándose en el nombre del objeto o sus componentes.

#### Scenario: Jugador en base enemiga
- **WHEN** un jugador colisiona con una base cuyo equipo identificado es diferente al del jugador.
- **THEN** el sistema DEBE ignorar la colisión y permitir el paso libre del jugador.

#### Scenario: Jugador en base propia
- **WHEN** un jugador colisiona con una base cuyo equipo identificado coincide con el del jugador.
- **THEN** el sistema DEBE proceder a validar si el jugador transporta una bandera enemiga.

### Requirement: Validación de Entrega de Bandera
El sistema DEBE procesar la entrega de una bandera solo cuando un jugador entra en su base propia transportando una bandera capturada de un equipo enemigo.

#### Scenario: Entrega legítima de bandera
- **WHEN** un jugador en su base propia tiene un objeto hijo (bandera enemiga).
- **THEN** el sistema DEBE bloquear el movimiento del jugador (`potMoure = false`) e invocar el minijuego de validación.

#### Scenario: Entrada en base propia sin bandera
- **WHEN** un jugador entra en su base propia pero NO transporta ninguna bandera enemiga.
- **THEN** el sistema DEBE permitir el paso sin activar ninguna lógica de entrega.
