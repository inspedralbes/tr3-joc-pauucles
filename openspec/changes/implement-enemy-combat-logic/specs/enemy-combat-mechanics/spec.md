## ADDED Requirements

### Requirement: Detección de Colisión entre Jugadores
El sistema DEBE identificar colisiones físicas entre objetos que tengan el tag "Player".

#### Scenario: Choque contra otro jugador
- **WHEN** un jugador colisiona con otro objeto que tiene el tag "Player".
- **THEN** el sistema DEBE registrar un log del encuentro e identificar al oponente.

### Requirement: Validación de Equipos Enemigos
El sistema DEBE permitir el combate únicamente entre jugadores que pertenecen a equipos diferentes.

#### Scenario: Encuentro con enemigo
- **WHEN** el equipo del jugador local es diferente al equipo del jugador colisionante.
- **THEN** el sistema DEBE proceder con la lógica de inicio de combate.

#### Scenario: Encuentro con aliado
- **WHEN** el equipo del jugador local es igual al equipo del jugador colisionante.
- **THEN** el sistema DEBE ignorar la colisión para efectos de combate.

### Requirement: Inicio Seguro de Combate y Bloqueo
El sistema DEBE iniciar la interfaz de minijuegos y restringir el movimiento del jugador local, evitando activaciones múltiples.

#### Scenario: Disparo del minijuego de combate
- **WHEN** se valida un enemigo Y no hay un minijuego activo en `MinijocUIManager`.
- **THEN** la variable `potMoure` del jugador local DEBE establecerse en falso Y se DEBE invocar `MinijocUIManager.Instance.ShowUI`.
