## ADDED Requirements

### Requirement: Notificació per Posició Extrema (X-Axis Hack)
El sistema ha de permetre notificar la victòria d'un jugador local teletransportant-lo a una coordenada X extremadament alta per ser detectada pels jugadors remots.

#### Scenario: Victòria local i teletransport
- **WHEN** el jugador local crida `GuanyarMinijoc()`
- **THEN** la seva posició es fixa a `X = 9999f`, `Y = 9999f` i s'inicia una restauració de posició automàtica després de 0.2 segons.

### Requirement: Detecció de Senyal de Derrota Remota
El sistema ha de monitoritzar la posició dels jugadors remots i activar la derrota local si detecta un jugador en la posició de senyalització.

#### Scenario: Detecció de rival a X extrema
- **WHEN** la coordenada X d'un missatge de posició remota és `>= 9000f`
- **THEN** el sistema ha de tancar la UI de minijocs, cridar `PerdreMinijoc()` al jugador local i ignorar el moviment visual del rival a la coordenada extrema.
