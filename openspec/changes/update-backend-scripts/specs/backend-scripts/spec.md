## ADDED Requirements

### Requirement: Production Start Script
The `backend/package.json` file MUST contain a `start` script to execute the server using Node.js.

#### Scenario: Run production script
- **WHEN** the command `npm start` is executed in the `backend` directory
- **THEN** the system SHALL run `node src/server.js`.

### Requirement: Development Script
The `backend/package.json` file MUST contain a `dev` script to execute the server using `nodemon` for automatic reloads.

#### Scenario: Run development script
- **WHEN** the command `npm run dev` is executed in the `backend` directory
- **THEN** the system SHALL run `nodemon src/server.js`.

## REMOVED Requirements

### Requirement: Default Test Script
**Reason**: The default test script is not applicable at this stage and needs to be removed as per requirements.
**Migration**: No migration required as no tests are currently implemented.
