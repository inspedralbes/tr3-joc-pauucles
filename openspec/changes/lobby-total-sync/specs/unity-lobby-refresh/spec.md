## ADDED Requirements

### Requirement: Actualització visual de la llista de jugadors
El client d'Unity SHALL repintar la llista de jugadors de la sala d'espera cada vegada que rebi un missatge `ROOM_UPDATED` via WebSocket, mostrant l'estat actual de cada jugador.

#### Scenario: Recepció de ROOM_UPDATED
- **WHEN** el client rep el missatge `ROOM_UPDATED`.
- **THEN** el `MenuManager` actualitza la `llistaJugadorsSala` i afegeix "(Llest)" o "(Esperant)" segons el camp `isReady` de cada jugador.

### Requirement: Enviament de LEAVE_ROOM des de la UI
La interfície d'usuari d'Unity SHALL enviar un missatge `LEAVE_ROOM` al servidor quan el jugador decideixi tancar o abandonar la sala d'espera.

#### Scenario: Clic al botó de tancar sala
- **WHEN** el jugador prem el botó de la creu (Tancar Sala) a la pantalla de sala d'espera.
- **THEN** el sistema envia un missatge `LEAVE_ROOM` amb el `roomId` i `username` via WebSocket i torna a la pantalla del lobby.
