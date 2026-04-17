## ADDED Requirements

### Requirement: Sincronització de l'estat de la sala al backend
El servidor SHALL notificar a tots els jugadors d'una sala quan un nou jugador s'uneix amb èxit, assegurant que el comptador de jugadors s'actualitzi en temps real.

#### Scenario: Notificació d'unió exitosa
- **WHEN** un jugador s'uneix a una sala a través de la base de dades MongoDB.
- **THEN** el sistema crida obligatòriament a `broadcastRoomUpdates()` per enviar l'estat actualitzat de la sala via WebSocket.

### Requirement: Petició d'unió des del client d'Unity
El client d'Unity SHALL registrar formalment la unió d'un jugador a una sala mitjançant una petició HTTP per mantenir la integritat de la base de dades.

#### Scenario: Registre d'unió des del lobby
- **WHEN** un jugador selecciona una sala a la llista de partides i prem el botó per apuntar-se.
- **THEN** el sistema realitza una petició HTTP POST a l'endpoint `/api/games/join` amb el `roomId` i el `username`.

### Requirement: Actualització visual de la llista de jugadors
La interfície d'usuari del client SHALL reflectir immediatament l'entrada d'un nou jugador a la sala d'espera.

#### Scenario: Visualització immediata del jugador a la sala
- **WHEN** la petició d'unió (`/api/games/join`) rep una resposta exitosa (HTTP 200).
- **THEN** el sistema afegeix el nom de l'usuari actual a la llista visual `llistaJugadorsSala` a la pantalla de sala d'espera.
