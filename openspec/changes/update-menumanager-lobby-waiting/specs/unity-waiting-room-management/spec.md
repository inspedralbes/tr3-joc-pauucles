## ADDED Requirements

### Requirement: Accés a la Sala d'Espera
El sistema SHALL mostrar la Sala d'Espera automàticament al client Unity quan un usuari crea una partida amb èxit.

#### Scenario: Transició a la Sala d'Espera
- **WHEN** el backend respon amb un èxit (200 OK) a la petició de creació de partida.
- **THEN** la UI ha d'ocultar el Lobby i mostrar l'element `pantallaSalaEspera`.

### Requirement: Tancament de la Sala d'Espera
El sistema SHALL permetre que el jugador pugui tancar la Sala d'Espera en qualsevol moment per tornar al Lobby.

#### Scenario: Retorn al Lobby
- **WHEN** el jugador prem el botó `btnTancarSalaEspera`.
- **THEN** la Sala d'Espera s'ha d'ocultar i el Lobby s'ha de tornar a mostrar, i el sistema ha d'executar una actualització de la llista de partides disponibles.

### Requirement: Persistència de l'ID de Sala
El client Unity SHALL emmagatzemar l'identificador de la sala (`roomId`) de la partida actual mentre estigui dins de la Sala d'Espera.

#### Scenario: Registre d'ID de Sala
- **WHEN** s'ha creat la partida correctament.
- **THEN** el sistema ha d'assignar el `roomId` de la resposta a la variable `currentRoomId`.
