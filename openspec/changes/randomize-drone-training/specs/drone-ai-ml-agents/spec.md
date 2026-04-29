## ADDED Requirements

### Requirement: Aleatorización de Inicio de Episodio
El sistema DEBE aleatorizar la situación inicial en cada nuevo episodio para diversificar el entrenamiento.
- DEBE elegir un punto de spawn aleatorio de una lista proporcionada.
- DEBE decidir aleatoriamente entre simular un estado "Robado" o un estado "Tirado".
- DEBE resetear la posición del dron a su base original.

#### Scenario: Simulación de estado Robado al inicio
- **WHEN** se inicia un episodio y el número aleatorio es 0.
- **THEN** el jugador objetivo se teletransporta al punto de spawn y el dinosaurio se vincula como hijo del jugador.

#### Scenario: Simulación de estado Tirado al inicio
- **WHEN** se inicia un episodio y el número aleatorio es 1.
- **THEN** el dinosaurio se desvincula de cualquier padre y se teletransporta solo al punto de spawn.
