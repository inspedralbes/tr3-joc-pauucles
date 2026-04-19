## ADDED Requirements

### Requirement: Configuració del Nametag Local
El sistema SHALL configurar el text del Nametag del jugador local en el moment d'iniciar la partida.

#### Scenario: Visualització del nom d'usuari local
- **WHEN** El jugador local és instanciat pel `GameManager`.
- **THEN** El sistema obté el `username` del `MenuManager`.
- **THEN** El text del Nametag (component `TextMeshPro` fill) s'actualitza per mostrar el nom de l'usuari.
