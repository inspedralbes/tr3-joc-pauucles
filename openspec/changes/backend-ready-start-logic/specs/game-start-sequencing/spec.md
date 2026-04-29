## ADDED Requirements

### Requirement: Processament de READY via WebSocket
El servidor SHALL actualitzar l'estat `isReady` d'un jugador a MongoDB quan rebi el missatge `READY` via WebSocket i notificar immediatament a tots els membres de la sala.

#### Scenario: Jugador canvia a estat llest
- **WHEN** el servidor rep el missatge `{ "type": "READY", "roomId": "X", "username": "jugador1" }`.
- **THEN** l'estat del jugador a la base de dades passa a `isReady: true` i s'emet un broadcast `ROOM_UPDATED` a la sala.

### Requirement: Validació d'inici de partida
El sistema SHALL verificar si es compleixen les condicions per començar la partida immediatament després de qualsevol canvi d'estat a la sala.

#### Scenario: Sala plena i tots llestos
- **WHEN** el nombre de jugadors de la sala arriba al `maxPlayers` i TOTS tenen `isReady: true`.
- **THEN** el sistema canvia l'status de la sala a `playing` i emet un broadcast `PARTIDA_INICIADA` amb la informació de cada jugador.

### Requirement: Notificació de PARTIDA_INICIADA
El missatge `PARTIDA_INICIADA` SHALL incloure les dades necessàries per a la configuració visual del jugador al client.

#### Scenario: Enviament de dades de sessió al client
- **WHEN** la partida s'inicia al backend.
- **THEN** el servidor envia a cada client un missatge JSON que inclou el `username`, l'equip (`team`) i el color assignat.
