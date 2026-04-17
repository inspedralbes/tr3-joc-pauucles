## ADDED Requirements

### Requirement: Connexió asíncrona WebSocket
El sistema HA DE ser capaç d'establir una connexió amb un servidor WebSocket local (`ws://localhost:3000`) de manera asíncrona per no bloquejar el fil principal d'Unity.

#### Scenario: Connexió exitosa al Start
- **WHEN** L'objecte que conté `WebSocketClient` s'inicialitza.
- **THEN** El sistema HA D'obrir una connexió cap al servidor especificat.

### Requirement: Processament de missatges GameStart
El sistema HA DE processar els missatges JSON rebuts que indiquin l'inici de la partida i continguin la informació del jugador.

#### Scenario: Recepció de dades de sessió
- **WHEN** Es rep un missatge de tipus `game_start` amb `username` i `team`.
- **THEN** El sistema HA DE guardar aquestes dades i buscar el personatge Woodcutter a l'escena.

### Requirement: Configuració del personatge Woodcutter
El sistema HA DE delegar la identitat del jugador Woodcutter a la informació rebuda de la sessió.

#### Scenario: Aplicació d'identitat real
- **WHEN** Les dades de sessió estan disponibles.
- **THEN** El sistema HA DE cridar al mètode `InicialitzarJugador` del Woodcutter amb el nom d'usuari i l'equip correctes.
