## ADDED Requirements

### Requirement: Persistència de l'estat READY
El sistema SHALL actualitzar l'estat `isReady` del jugador a la base de dades MongoDB de forma persistent immediatament després de rebre el missatge del client.

#### Scenario: Actualització i guardat de READY
- **WHEN** el servidor rep un missatge de tipus `READY` amb `roomId` i `username`.
- **THEN** el sistema cerca la sala, marca `isReady: true` per al jugador corresponent i crida a `await room.save()`.

### Requirement: Notificació de canvi d'estat a la sala
El sistema SHALL realitzar un broadcast de la sala actualitzada a tots els clients connectats un cop s'ha persistit el canvi d'estat de preparació.

#### Scenario: Broadcast de ROOM_UPDATED
- **WHEN** s'ha completat el guardat de l'estat `isReady` d'un jugador.
- **THEN** el servidor emet un missatge `ROOM_UPDATED` amb la informació de la sala a tots els participants.
