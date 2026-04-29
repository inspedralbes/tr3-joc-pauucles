## ADDED Requirements

### Requirement: Acceso a banderaAgafada
El sistema DEBE permitir que la variable `banderaAgafada` en `Player.cs` sea pública.

#### Scenario: MinijocUIManager identifica al defensor
- **WHEN** un impacto ocurre y el UI necesita mostrar la pantalla de minijuego
- **THEN** el gestor puede consultar `jugador.banderaAgafada` para determinar si el jugador la posee
