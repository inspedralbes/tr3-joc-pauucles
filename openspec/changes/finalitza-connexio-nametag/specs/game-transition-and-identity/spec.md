## ADDED Requirements

### Requirement: Lobby readiness confirmation
El sistema ha de permetre als jugadors confirmar que estan preparats ("READY") des de la interfície del lobby.

#### Scenario: Enviar estat READY
- **WHEN** el jugador prem el botó "LLEST" (`#btnConfirmarReady`) al MenuManager.
- **THEN** el sistema envia un missatge amb el text "READY" a través del WebSocket.

### Requirement: Processament de l'inici de partida
El sistema ha de gestionar el missatge de "PARTIDA_INICIADA" per preparar la transició al joc.

#### Scenario: Emmagatzematge de dades i canvi d'escena
- **WHEN** es rep el missatge "PARTIDA_INICIADA" via WebSocket amb les dades del jugador (`username`, `team`, `color`).
- **THEN** el sistema guarda aquestes dades en variables estàtiques i carrega l'escena "Bosque".

### Requirement: Visualització de la identitat del jugador (Nametag)
Cada jugador ha de mostrar visualment el seu nom amb el color que se li ha assignat.

#### Scenario: Configuració del Nametag al Start
- **WHEN** s'inicia el script `Player` a l'escena de joc.
- **THEN** es crida al mètode `Configurar` del Nametag amb el nom i el color guardats, el qual actualitza el text i tradueix el nom del color (ex: "Verd") a un `Color` de Unity (ex: `Color.green`).

### Requirement: Estabilitat visual del Nametag
El Nametag ha de ser llegible en tot moment, independentment del moviment del jugador.

#### Scenario: Rotació constant
- **WHEN** el jugador es mou o el seu transform canvia de rotació.
- **THEN** el Nametag manté la seva rotació com a `Quaternion.identity` a cada frame (`LateUpdate`).
