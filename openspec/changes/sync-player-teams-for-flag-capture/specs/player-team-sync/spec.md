## ADDED Requirements

### Requirement: Almacenamiento de Equipo por Jugador
Cada instancia de `Player` DEBE almacenar el equipo al que pertenece ("A" o "B") en una variable pública accesible.

#### Scenario: Acceso al equipo
- **WHEN** se consulta el componente `Player` de cualquier objeto jugador.
- **THEN** se DEBE poder leer la variable `equip`.

### Requirement: Sincronización del Equipo Local
El sistema DEBE asignar el equipo correcto al jugador local al inicio de la partida basándose en los datos de la sala actual.

#### Scenario: Asignación al jugador local
- **WHEN** el jugador local entra en la escena de juego.
- **THEN** el sistema DEBE buscar su username en la lista de jugadores de la sala y asignar el equipo correspondiente a su componente `Player`.

### Requirement: Sincronización de Equipos Remotos
El sistema DEBE asignar el equipo correcto a cada jugador remoto al instanciarlos o actualizarlos.

#### Scenario: Asignación a jugadores remotos
- **WHEN** un jugador remoto es detectado o actualizado por el `GameManager`.
- **THEN** el sistema DEBE buscar su username en la lista de jugadores de la sala y asignar el equipo correspondiente a su componente `Player` remoto.

### Requirement: Validación de Captura de Bandera por Equipo
La bandera DEBE utilizar la variable `equip` de los jugadores para validar colisiones y capturas.

#### Scenario: Validación de equipo en colisión
- **WHEN** un jugador colisiona con la bandera.
- **THEN** la bandera DEBE comparar su propio `equipPropietari` con el `equip` del jugador detectado para decidir si permite la captura.
