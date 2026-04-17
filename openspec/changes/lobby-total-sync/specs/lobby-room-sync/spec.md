## ADDED Requirements

### Requirement: Broadcast de dades de la sala
El servidor SHALL enviar un missatge `ROOM_UPDATED` amb la informació completa de la sala a tots els jugadors connectats a aquesta quan hi hagi un canvi en la llista de jugadors o en el seu estat de preparació.

#### Scenario: Sincronització d'estat READY
- **WHEN** un jugador envia el missatge `READY` via WebSocket.
- **THEN** el servidor actualitza l'estat del jugador a MongoDB i envia un broadcast `ROOM_UPDATED` a tots els membres de la sala.

### Requirement: Gestió d'abandonament (LEAVE_ROOM)
El sistema SHALL permetre que un jugador abandoni una sala de joc voluntàriament, eliminant-lo de la llista de jugadors de la sala a la base de dades.

#### Scenario: Jugador abandona la sala
- **WHEN** el servidor rep un missatge `LEAVE_ROOM` d'un jugador.
- **THEN** el sistema elimina el jugador de la sala a MongoDB i realitza un broadcast `ROOM_UPDATED` als jugadors restants.

### Requirement: Eliminació de sales buides
Si una sala es queda sense jugadors després d'un abandonament, el sistema SHALL eliminar la sala de la base de dades i notificar a tots els usuaris del lobby que la llista de sales ha canviat.

#### Scenario: Últim jugador abandona la sala
- **WHEN** l'últim jugador de la sala envia el missatge `LEAVE_ROOM`.
- **THEN** el sistema elimina la sala de MongoDB i realitza un broadcast `ACTUALITZAR_SALES` a tots els clients connectats al lobby.
