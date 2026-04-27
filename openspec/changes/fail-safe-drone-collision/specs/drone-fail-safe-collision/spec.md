## ADDED Requirements

### Requirement: Detección Robusta de Objetivos
El dron DEBE identificar correctamente si ha colisionado con la bandera o con un jugador portador, independientemente de su identificador de equipo (`teamId`).

#### Scenario: Colisión con la Bandera
- **WHEN** El dron entra en contacto con un objeto que contiene el componente `Bandera`.
- **THEN** El sistema DEBE registrar el evento con un `Debug.Log` y proceder a la fase de recompensa.

#### Scenario: Colisión con el Jugador
- **WHEN** El dron entra en contacto con un objeto que tiene el tag `Player`.
- **THEN** El sistema DEBE registrar el evento con un `Debug.Log` y proceder a la fase de recompensa.

### Requirement: Recompensa y Reinicio
El dron DEBE recibir la máxima recompensa y el episodio DEBE reiniciarse tras una colisión exitosa.

#### Scenario: Éxito en la Captura
- **WHEN** Se confirma una colisión válida (Bandera o Jugador).
- **THEN** El sistema DEBE asignar una recompensa de `1f`, teletransportar al objetivo a su punto de origen y finalizar el episodio con `EndEpisode()`.
