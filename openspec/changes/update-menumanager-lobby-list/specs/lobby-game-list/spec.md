## ADDED Requirements

### Requirement: Llistar Partides Disponibles al Lobby
El sistema HA de carregar i mostrar una llista de totes les partides actives quan l'usuari entra al lobby.

#### Scenario: Inicialització de la llista de partides
- **WHEN** l'usuari fa login correctament i es mostra la pantalla del Lobby.
- **THEN** el sistema HA de fer una petició GET a `/api/games/list` i poblar el ListView `llistaPartides`.

### Requirement: Visualització de la Informació de la Partida
El sistema HA de mostrar informació específica per a cada partida de la llista per tal que l'usuari pugui identificar-la.

#### Scenario: Format dels elements de la llista
- **WHEN** la llista de partides es pobla amb dades del backend.
- **THEN** cada element HA DE mostrar el Room ID i el recompte de jugadors (per exemple, "Sala: room123 - Jugadors: 2/4").
