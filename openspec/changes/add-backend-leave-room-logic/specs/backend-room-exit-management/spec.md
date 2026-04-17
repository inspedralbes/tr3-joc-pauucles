## ADDED Requirements

### Requirement: Gestió de Missatges de WebSocket
El servidor SHALL escoltar els missatges entrants dels clients a través del WebSocket.

#### Scenario: Recepció de Missatge JSON
- **WHEN** el servidor rep dades del client.
- **THEN** el servidor ha de parsejar les dades com un objecte JSON i extreure el camp `type`.

### Requirement: Sortida de Sala
El sistema SHALL permetre que un jugador pugui sortir d'una sala de joc mitjançant un missatge del protocol WebSocket.

#### Scenario: Jugador Surt de la Sala
- **WHEN** s'envia un missatge amb `type: "leave_room"`, un `roomId` i un `username`.
- **THEN** el servidor ha d'eliminar el jugador amb aquest nom d'usuari de la llista `players` d'aquella sala en la base de dades.

### Requirement: Neteja de Sales Buides
El sistema SHALL esborrar les sales de la base de dades quan aquestes no tinguin cap jugador registrat.

#### Scenario: Eliminació Automàtica de Sala Buida
- **WHEN** l'últim jugador surt d'una sala.
- **THEN** la sala (el document `Game`) ha de ser eliminada completament de la col·lecció de la base de dades.
