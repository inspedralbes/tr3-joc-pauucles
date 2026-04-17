## ADDED Requirements

### Requirement: Notificació de Sortida de Sala
El client Unity SHALL notificar activament al servidor WebSocket quan un jugador decideixi abandonar la sala de joc.

#### Scenario: Sortida Satisfactòria
- **WHEN** el jugador prem el botó `btnTancarSalaEspera` i la connexió WebSocket està activa.
- **THEN** el sistema ha d'enviar un missatge JSON amb el camp `type: "leave_room"`, el `roomId` actual i el `username` del jugador abans d'amagar la UI.

### Requirement: Verificació d'Estat del Socket
El client SHALL verificar que el WebSocket estigui en estat `Open` abans d'intentar enviar la notificació de sortida.

#### Scenario: Socket Tancat
- **WHEN** el jugador prem el botó `btnTancarSalaEspera` però el socket no està connectat.
- **THEN** el sistema ha de realitzar la transició visual de la UI de totes maneres, sense intentar realitzar l'enviament per xarxa.
