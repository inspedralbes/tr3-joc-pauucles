## ADDED Requirements

### Requirement: Nametag del jugador local (Restaurat)
El sistema SHALL assegurar que el personatge del jugador local mostri el seu nom d'usuari a l'escena de joc.

#### Scenario: Configuració del Nametag en spawn
- **WHEN** El jugador local és instanciat pel `GameManager`.
- **THEN** El sistema busca el component `TextMeshPro` fill i hi assigna el valor de `MenuManager.Instance.userId`.
