## ADDED Requirements

### Requirement: User Model Definition
The system SHALL define a User model with specific properties for identity and progression.

#### Scenario: User data structure
- **WHEN** a user object is created
- **THEN** it SHALL contain:
  - `username`: String (Unique, Required)
  - `password`: String (Required)
  - `coins`: Number (Default: 0)
  - `skins`: Array of Strings (Default: ['base'])

### Requirement: Create User in Repository
The User repository SHALL provide a method to persist a new user.

#### Scenario: Successfully create user
- **WHEN** the `create(user)` method is called with valid user data
- **THEN** the system persists the user and returns the created user object.

### Requirement: Find User by Username
The User repository SHALL provide a method to retrieve a user by their unique username.

#### Scenario: Find existing user
- **WHEN** `findByUsername(username)` is called with an existing username
- **THEN** the system returns the corresponding user object.

#### Scenario: Find non-existing user
- **WHEN** `findByUsername(username)` is called with a username that does not exist
- **THEN** the system returns `null` or `undefined`.
