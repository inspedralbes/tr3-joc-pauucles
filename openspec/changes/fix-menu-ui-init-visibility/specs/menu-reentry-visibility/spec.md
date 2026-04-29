## ADDED Requirements

### Requirement: Consistent UI State on Initialization
The system MUST ensure that either the Login or Lobby screen is visible immediately after scene initialization, based on the user's authentication status.

#### Scenario: Authenticated user returns to menu
- **WHEN** an authenticated user (with valid `userId`) returns to the Menu scene
- **THEN** the Lobby screen is shown (`DisplayStyle.Flex`) and the Login screen is hidden (`DisplayStyle.None`)

#### Scenario: Unauthenticated user enters menu
- **WHEN** a user with no active session enters the Menu scene
- **THEN** the Login screen is shown (`DisplayStyle.Flex`) and the Lobby screen is hidden (`DisplayStyle.None`)

### Requirement: Forced Visibility
The main `UIDocument` root MUST NOT be hidden if no other full-screen UI overlay is active.

#### Scenario: Scene reload
- **WHEN** the `MenuPrincipal` scene is loaded
- **THEN** the root UI elements are explicitly set to their required visibility states, preventing an empty blue screen.
