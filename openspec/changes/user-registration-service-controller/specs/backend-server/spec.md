## MODIFIED Requirements

### Requirement: Express Server Initialization
The system SHALL initialize an Express application that listens on a configurable port and includes user management routes.

#### Scenario: Server starts with user routes
- **WHEN** the server is executed
- **THEN** it SHALL include the `/api/users` routes in the middleware chain.
