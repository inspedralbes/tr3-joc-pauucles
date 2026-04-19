## ADDED Requirements

### Requirement: Sincronització del Nametag Local
El sistema SHALL mostrar el nom d'usuari correcte sobre el cap del jugador local immediatament després de la instanciació.

#### Scenario: Visualització del nom propi
- **WHEN** El GameManager instancia o configura el jugador local.
- **THEN** S'identifica el component de text (TextMeshPro) dins dels fills de l'objecte del jugador.
- **THEN** S'hi assigna el valor del camp `username` obtingut de la instància de `MenuManager`.
