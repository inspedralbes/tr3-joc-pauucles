## ADDED Requirements

### Requirement: WebSocket Server Initialization
The backend SHALL initialize a Socket.io server integrated with the existing HTTP server to allow bidirectional communication.

#### Scenario: Server Start
- **WHEN** the backend application starts
- **THEN** a Socket.io server is initialized and attached to the HTTP server

### Requirement: Client Connection Handling
The server SHALL accept and handle WebSocket connections from game clients.

#### Scenario: Client Connects
- **WHEN** a client initiates a connection to the server's WebSocket endpoint
- **THEN** the server accepts the connection and assigns a unique `socket.id`

### Requirement: Connection Event Logging
The server SHALL log messages to the console when a client connects or disconnects to facilitate debugging.

#### Scenario: Log on Connect
- **WHEN** a client successfully connects via Socket.io
- **THEN** the server logs "Client connectat via Socket: <socket.id>" to the console

#### Scenario: Log on Disconnect
- **WHEN** a client disconnects from the server
- **THEN** the server logs a disconnection message including the socket ID

### Requirement: CORS Configuration for WebSockets
The Socket.io server SHALL be configured with a permissive CORS policy (origin: "*") to allow connections from Unity WebGL or standalone builds.

#### Scenario: Cross-Origin Connection
- **WHEN** a client from a different origin (e.g., localhost:XXXX, or a web domain) attempts to connect
- **THEN** the server allows the connection based on the "*" CORS origin setting

### Requirement: REST API Coexistence
The integration of Socket.io SHALL NOT interfere with the existing Express REST API routes.

#### Scenario: API Request after Socket Integration
- **WHEN** a GET/POST request is made to an existing API endpoint (e.g., `/api/users/login`)
- **THEN** the server responds correctly as it did before the Socket.io integration
