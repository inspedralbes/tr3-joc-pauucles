## ADDED Requirements

### Requirement: Sincronització de spawns per a Late-Joiners
El sistema SHALL garantir que tots els jugadors, inclosos els que s'uneixen després de la càrrega de l'escena, visualitzin les banderes correctament sincronitzades amb les dades del servidor.

#### Scenario: Sincronització en entrar a la sala
- **WHEN** Un jugador carrega l'escena de combat.
- **THEN** El GameManager espera fins que el WebSocketClient estigui connectat i el MenuManager tingui les dades de la sala (currentRoomData).
- **THEN** Un cop les dades són vàlides, el sistema executa la instanciació de les banderes.
