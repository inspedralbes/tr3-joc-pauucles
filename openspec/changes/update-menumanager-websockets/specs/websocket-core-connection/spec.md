## ADDED Requirements

### Requirement: WebSocket Initialization
The system SHALL initialize a `SocketIOUnity` instance using the server URI `http://localhost:3000`.

#### Scenario: Initialize Socket with Server URI
- **WHEN** the `MenuManager` component's `Start` method is executed
- **THEN** the `SocketIOUnity` instance SHALL be created with `new Uri("http://localhost:3000")`

### Requirement: WebSocket Connection Lifecycle Events
The system SHALL handle connection and disconnection events from the Socket.io client to provide feedback to the developer/user.

#### Scenario: Log Successful Connection
- **WHEN** the `OnConnected` event is triggered by the socket
- **THEN** the system SHALL log the message "Connexió Socket.io establerta amb èxit!" to the Unity Debug console

#### Scenario: Log Disconnection
- **WHEN** the `OnDisconnected` event is triggered by the socket
- **THEN** the system SHALL log the message "Socket desconnectat" to the Unity Debug console

### Requirement: Manual Connection Trigger
The system SHALL explicitly initiate the connection to the WebSocket server during the initialization phase.

#### Scenario: Connect to Server on Start
- **WHEN** all event listeners have been registered in the `Start` method
- **THEN** the `socket.Connect()` method SHALL be called
