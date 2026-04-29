## ADDED Requirements

### Requirement: Servidor de WebSocket Pur
El sistema SHALL inicialitzar un servidor de WebSocket pur utilitzant la llibreria `ws` al backend. Aquest servidor MUST compartir el mateix port que el servidor d'aplicacions Express.

#### Scenario: Connexió del Client
- **WHEN** un client intenta connectar-se al servidor utilitzant el protocol WebSocket estàndard (`ws://<host>:<port>`)
- **THEN** el servidor ha d'acceptar la connexió i registrar-la correctament.

### Requirement: Gestió de la Connexió
El sistema SHALL permetre la detecció de la connexió i la desconnexió dels clients per a fins de depuració i seguiment de l'estat.

#### Scenario: Notificació de Connexió
- **WHEN** un client es connecta satisfactòriament
- **THEN** el servidor ha de mostrar un missatge de log indicant la nova connexió.

#### Scenario: Notificació de Desconnexió
- **WHEN** un client tanca la connexió WebSocket
- **THEN** el servidor ha de mostrar un missatge de log indicant que el client s'ha desconnectat.
