## ADDED Requirements

### Requirement: Acceso público a banderaAgafada
La clase `Player` SHALL exponer la variable `banderaAgafada` de forma pública.

#### Scenario: Acceso desde MinijocUIManager
- **WHEN** un combate se inicia y el `MinijocUIManager` consulta `player.banderaAgafada`
- **THEN** el sistema permite el acceso sin errores de compilación por nivel de protección.
