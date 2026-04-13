## ADDED Requirements

### Requirement: User Registration Service
The `UserService` SHALL provide a method to register a new user, ensuring the username is unique and the password is securely hashed.

#### Scenario: Successful user registration
- **WHEN** the `register(username, password)` method is called with a unique username
- **THEN** the system SHALL hash the password using `bcrypt`, call the repository's `create` method, and return the newly created user object.

#### Scenario: Register existing user
- **WHEN** the `register(username, password)` method is called with a username that already exists in the repository
- **THEN** the system SHALL throw an error indicating the user already exists.

### Requirement: User Registration Controller
The `UserController` SHALL handle user registration requests and format the response appropriately.

#### Scenario: Handle registration request
- **WHEN** a POST request is made to the registration endpoint with `username` and `password`
- **THEN** the system SHALL call the `UserService`, return a 201 status with the user data (excluding the password), or an appropriate error status if registration fails.

### Requirement: User Registration Route
The system SHALL expose a POST route for user registration.

#### Scenario: Access registration endpoint
- **WHEN** a POST request is made to `/api/users/register`
- **THEN** the request is routed to the `UserController.register` method.
