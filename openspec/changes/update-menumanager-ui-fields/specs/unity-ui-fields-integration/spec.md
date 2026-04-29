## ADDED Requirements

### Requirement: TextMeshPro Integration in MenuManager
The system SHALL support TextMeshPro input fields for the `MenuManager` script.

#### Scenario: TMP_InputField exposure
- **WHEN** the `MenuManager` script is inspected in the Unity Editor
- **THEN** the system SHALL expose two public `TMP_InputField` fields named `campUsuari` and `campPassword`

### Requirement: Public UI Interaction Methods
The system SHALL provide public methods to trigger user registration and login from the Unity UI system.

#### Scenario: Registration through UI button
- **WHEN** the `BotoRegistrarClicat` method is called
- **THEN** the system SHALL invoke the `RegistrarUsuari` method using the values from `campUsuari` and `campPassword`

#### Scenario: Login through UI button
- **WHEN** the `BotoLoginClicat` method is called
- **THEN** the system SHALL invoke the `FerLogin` method using the values from `campUsuari` and `campPassword`
