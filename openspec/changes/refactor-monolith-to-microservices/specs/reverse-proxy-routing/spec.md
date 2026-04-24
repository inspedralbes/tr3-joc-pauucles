## ADDED Requirements

### Requirement: Unified API Gateway
Nginx SHALL actuar com a Proxy Invers per centralitzar totes les peticions externes en un únic punt d'entrada.

#### Scenario: Routing to Auth
- **WHEN** un client fa una petició a `/api/users/login`
- **THEN** Nginx ha de redirigir la petició internament al port 3001

### Requirement: WebSocket Proxying
Nginx SHALL suportar la redirecció de connexions WebSocket cap al servei de joc.

#### Scenario: WebSocket Connection
- **WHEN** un client intenta una connexió WebSocket a `/socket.io/` o `/api/games/`
- **THEN** Nginx ha de mantenir la connexió viva i redirigir-la al port 3002
