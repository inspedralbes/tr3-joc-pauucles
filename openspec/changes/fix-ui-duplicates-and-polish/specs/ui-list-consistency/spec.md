## ADDED Requirements

### Requirement: Neteja obligatòria de llistes a Unity
El client d'Unity SHALL cridar al mètode `.Clear()` (o equivalent segons la col·lecció de dades) del contenidor visual de la llista de sales i la llista de jugadors abans de processar i mostrar noves dades.

#### Scenario: Actualització de sales sense duplicats
- **WHEN** el client rep una nova llista de sales via WebSocket o HTTP.
- **THEN** el sistema buida el contenidor `llistaPartides` abans d'instanciar els botons de les sales noves.

#### Scenario: Actualització de jugadors a la sala d'espera
- **WHEN** un jugador s'uneix o abandona la sala actual.
- **THEN** el sistema buida el contenidor `llistaJugadorsSala` abans de repintar la llista actualitzada de participants.

### Requirement: Notificació de canvis de sala al backend
El servidor SHALL enviar un broadcast `ROOM_UPDATED` quan un jugador marxi d'una sala, sempre que la sala encara contingui participants, per sincronitzar la UI de la resta de jugadors.

#### Scenario: Jugador abandona sala no buida
- **WHEN** el servidor processa un esdeveniment `LEAVE_ROOM` i queden jugadors a la sala.
- **THEN** el sistema emet un missatge `ROOM_UPDATED` a tots els clients connectats a aquesta sala.
