## MODIFIED Requirements

### Requirement: Persistència del MenuManager
El `MenuManager` SHALL persistir a través dels canvis d'escena per mantenir la connexió WebSocket activa.

#### Scenario: Singleton actiu
- **WHEN** Es carrega una nova escena.
- **THEN** Si ja existeix una instància de `MenuManager`, la nova és destruïda i la original es manté.
- **THEN** Tots els handlers de missatges romandran actius i vinculats a la instància persistent.
