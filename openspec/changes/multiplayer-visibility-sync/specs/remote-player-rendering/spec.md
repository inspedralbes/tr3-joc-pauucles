## ADDED Requirements

### Requirement: Instanciació de jugadors remots
El client Unity SHALL instanciar un prefab de jugador remot per a cada usuari que es trobi a la mateixa sala que el jugador local.

#### Scenario: Nou jugador a la sala
- **WHEN** El client rep una actualització de sala on hi ha un nou `username`.
- **THEN** El `GameManager` instancia un `JugadorRemot` i li assigna el nom de l'usuari al seu Nametag.

### Requirement: Actualització de jugadors remots
El client Unity SHALL actualitzar la posició i l'estat visual dels prefabs remots segons els missatges rebuts del servidor.

#### Scenario: Moviment de jugador remot
- **WHEN** El client rep un missatge `PLAYER_MOVE` d'un usuari que ja té un prefab instanciat.
- **THEN** El prefab corresponent actualitza la seva `position`, `flipX` i l'estat del `Animator`.
