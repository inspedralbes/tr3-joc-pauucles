## ADDED Requirements

### Requirement: Independent Identity Service
El sistema SHALL tenir un servei d'identitat independent escoltant al port 3001. Aquest servei ha de gestionar exclusivament les rutes de `/login`, `/register` i la gestió d'usuaris.

#### Scenario: Successful Identity Service Startup
- **WHEN** el servei d'identitat s'inicia correctament
- **THEN** ha d'estar disponible al port 3001 i connectar-se només als repositoris necessaris

### Requirement: Independent Game Service
El sistema SHALL tenir un servei de joc independent escoltant al port 3002. Aquest servei ha de gestionar els WebSockets, la lògica de sales i l'estat de les partides.

#### Scenario: Successful Game Service Startup
- **WHEN** el servei de joc s'inicia correctament
- **THEN** ha d'estar disponible al port 3002 i manejar totes les connexions WebSocket (ws)
