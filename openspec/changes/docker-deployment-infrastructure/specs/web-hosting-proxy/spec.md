## ADDED Requirements

### Requirement: Unity WebGL Static Hosting
Nginx SHALL servir els arxius de la build de Unity WebGL (HTML, JS, WASM) des de l'arrel `/`.

#### Scenario: Accessing the Game
- **WHEN** un usuari accedeix a `http://localhost/`
- **THEN** Nginx ha de retornar el fitxer `index.html` de la build WebGL

### Requirement: Path-based API Proxying
Nginx SHALL redirigir les peticions a `/api/users/` al servei d'identitat i les peticions a `/api/games/` al servei de joc.

#### Scenario: Login Request Routing
- **WHEN** arriba una petició a `POST /api/users/login`
- **THEN** Nginx ha de fer proxy pass al servei `identity`

### Requirement: WebSocket Protocol Support
Nginx SHALL estar configurat per mantenir les connexions WebSocket cap al servei de joc.

#### Scenario: WebSocket Handshake
- **WHEN** un client intenta una connexió WebSocket a `/socket.io/`
- **THEN** Nginx ha de fer l'upgrade de la connexió cap al servei `game`
