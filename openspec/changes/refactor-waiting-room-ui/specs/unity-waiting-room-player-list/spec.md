## ADDED Requirements

### Requirement: Llista de Jugadors a la Sala d'Espera
El sistema SHALL mostrar la llista de jugadors a la Sala d'Espera dins d'un `ListView` específic anomenat `llistaJugadorsSala`.

#### Scenario: Visualització de Jugadors
- **WHEN** un jugador entra o crea una partida correctament i accedeix a la `pantallaSalaEspera`.
- **THEN** el sistema ha d'omplir el `ListView` amb el nom d'usuari i l'estat actual de cada jugador a la sala.

### Requirement: Format de la Llista de Jugadors
El sistema SHALL utilitzar un format visual clar per a cada entrada de la llista de jugadors, indicant si estan a punt o esperant.

#### Scenario: Element de la Llista
- **WHEN** el `ListView` genera un element.
- **THEN** s'ha de mostrar un Label amb el color del text blanc i el contingut: "Jugador: [nom] (Llest/Esperant)".
