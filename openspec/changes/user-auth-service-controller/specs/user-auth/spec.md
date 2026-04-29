## ADDED Requirements

### Requirement: User Registration
The system SHALL allow a new user to register with a unique username and a password.

#### Scenario: Successful Registration
- **WHEN** a POST request is made to `/api/users/register` with a new username and password.
- **THEN** the system SHALL hash the password using `bcrypt` and store the new user.
- **THEN** the system SHALL return a 201 Created status.

#### Scenario: Registration with Duplicate Username
- **WHEN** a POST request is made to `/api/users/register` with an already existing username.
- **THEN** the system SHALL return a 400 Bad Request status with an error message.

### Requirement: User Login
The system SHALL allow an existing user to login by providing their username and password.

#### Scenario: Successful Login
- **WHEN** a POST request is made to `/api/users/login` with valid credentials.
- **THEN** the system SHALL compare the provided password with the stored hash.
- **THEN** the system SHALL return a 200 OK status.

#### Scenario: Login with Invalid Credentials
- **WHEN** a POST request is made to `/api/users/login` with incorrect credentials.
- **THEN** the system SHALL return a 401 Unauthorized status with an error message.
