## ADDED Requirements

### Requirement: Unified Entry Point
Nginx SHALL actuar como el único punto de entrada para los clientes (normalmente puerto 80/443), ocultando la complejidad de los puertos internos de los microservicios.

#### Scenario: Routing to Auth
- **WHEN** un cliente hace una petición a `/api/auth/login`
- **THEN** Nginx debe redirigir internamente la petición al puerto 3001

### Requirement: Path-based Routing
El proxy inverso SHALL enrutar las peticiones basándose en el prefijo de la URL.

#### Scenario: Routing to Game Logic
- **WHEN** un cliente hace una petición que no es de auth o es específicamente de juego
- **THEN** Nginx debe redirigir la petición al puerto 3002

### Requirement: WebSocket Proxying
Nginx SHALL estar configurado para soportar el protocolo WebSocket (Upgrade headers) para el servicio de juego.

#### Scenario: WebSocket Connection
- **WHEN** un cliente intenta abrir una conexión WebSocket a `/socket.io/`
- **THEN** Nginx debe mantener los headers `Upgrade` y `Connection` y pasar la conexión al puerto 3002
