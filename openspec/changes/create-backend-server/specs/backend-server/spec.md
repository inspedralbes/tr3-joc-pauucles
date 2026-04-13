## ADDED Requirements

### Requirement: Express Server Initialization
The system SHALL initialize an Express application that listens on a configurable port.

#### Scenario: Server starts successfully
- **WHEN** the server is executed
- **THEN** it listens on the port specified in the `PORT` environment variable or defaults to 3000, and logs "Servidor funcionant al port 3000" (or the specified port).

### Requirement: Middleware Configuration
The system SHALL configure `cors` and `express.json()` middlewares to handle cross-origin requests and JSON payloads.

#### Scenario: Middleware is applied
- **WHEN** a request is made to the server
- **THEN** CORS headers are processed and JSON request bodies are correctly parsed.

### Requirement: Database Connectivity
The system SHALL establish a connection to a MongoDB database using `mongoose` and handle the connection status.

#### Scenario: Successful database connection
- **WHEN** the server starts and attempts to connect to the URI provided in `MONGO_URI`
- **THEN** it logs "Base de dades connectada correctament" upon success.

#### Scenario: Failed database connection
- **WHEN** the connection to the database fails
- **THEN** the system logs the error to the console.

### Requirement: Environment Variable Management
The system SHALL use `dotenv` to load configuration from a `.env` file at startup.

#### Scenario: Variables are loaded
- **WHEN** `dotenv.config()` is called
- **THEN** `process.env.MONGO_URI` and `process.env.PORT` are available for use in the application.
