## ADDED Requirements

### Requirement: API Base Configuration
The system MUST use `http://localhost:3000/api` as the central base URL for all backend communications.

#### Scenario: Base URL correctness
- **WHEN** the MenuManager initializes
- **THEN** the `baseUrl` variable is set to `http://localhost:3000/api`

### Requirement: Updated Authentication Endpoints
The system MUST use the specific endpoints `/users/register` for user registration and `/users/login` for user authentication.

#### Scenario: User Registration call
- **WHEN** a user clicks the registration button
- **THEN** a POST request is sent to `http://localhost:3000/api/users/register`

#### Scenario: User Login call
- **WHEN** a user clicks the login button
- **THEN** a POST request is sent to `http://localhost:3000/api/users/login`

### Requirement: Game Creation UI Management
The system MUST provide a dedicated pop-up interface for game configuration that can be toggled by the user.

#### Scenario: Show Game Creation Pop-up
- **WHEN** the "Crear Partida" button is clicked
- **THEN** the `popUpCrearSala` element becomes visible (`DisplayStyle.Flex`)

#### Scenario: Hide Game Creation Pop-up
- **WHEN** the "Tancar" button within the pop-up is clicked
- **THEN** the `popUpCrearSala` element is hidden (`DisplayStyle.None`)

### Requirement: Game Room Validation
The system MUST prevent creating a game if both teams have selected the same color.

#### Scenario: Invalid Team Selection
- **WHEN** the user attempts to confirm a game with `dropdownEquip1.value == dropdownEquip2.value`
- **THEN** a `Debug.LogWarning` is issued and the creation process is aborted

### Requirement: Game Room Persistence
The system MUST send the validated game configuration to the backend to create a new game room.

#### Scenario: Successful Game Room Creation
- **WHEN** the user confirms a game with valid, unique team colors
- **THEN** a JSON payload containing `teamAColor`, `teamBColor`, and `maxPlayers` is POSTed to `/games/create`
