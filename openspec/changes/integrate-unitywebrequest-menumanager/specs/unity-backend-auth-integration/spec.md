## ADDED Requirements

### Requirement: User Authentication Network Integration
The system SHALL provide a mechanism to send registration and login requests from the Unity client to the backend API.

#### Scenario: Successful Network Request
- **WHEN** `RegistrarUsuari` or `FerLogin` is called with a username and password
- **THEN** the system SHALL send a POST request with the JSON-serialized credentials to the backend
- **AND** the system SHALL display a success message in the Unity Debug log upon receiving a successful response

#### Scenario: Failed Network Request
- **WHEN** the backend is unreachable or returns an error status
- **THEN** the system SHALL display an error message in the Unity Debug log
