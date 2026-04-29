## ADDED Requirements

### Requirement: UI Toolkit Integration
The system SHALL use the `UnityEngine.UIElements` namespace to manage user interface elements.

#### Scenario: Element Querying
- **WHEN** the `MenuManager` script is enabled
- **THEN** the system SHALL find the `TextField` elements named `inputNomJugador` and `inputPassword`
- **AND** the system SHALL find the `Button` elements named `btnRegistre` and `btnLogin`

### Requirement: Button Click Events
The system SHALL bind button click events to authentication methods using lambda expressions.

#### Scenario: Registration Trigger
- **WHEN** the `btnRegistre` button is clicked
- **THEN** the system SHALL call `RegistrarUsuari` with the values from `inputNomJugador` and `inputPassword`

#### Scenario: Login Trigger
- **WHEN** the `btnLogin` button is clicked
- **THEN** the system SHALL call `FerLogin` with the values from `inputNomJugador` and `inputPassword`
