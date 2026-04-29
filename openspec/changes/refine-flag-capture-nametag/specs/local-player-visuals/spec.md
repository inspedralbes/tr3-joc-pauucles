## ADDED Requirements

### Requirement: Exhaustive Nametag Discovery
The system SHALL search for nametag text components using multiple methods to ensure the local player's ID is displayed correctly.

#### Scenario: TextMeshPro Discovery
- **WHEN** the system configures local player visuals
- **THEN** it MUST first attempt to find a `TMPro.TextMeshPro` component in the player's children

#### Scenario: Legacy Text Discovery
- **WHEN** `TextMeshPro` is not found
- **THEN** it MUST attempt to find a `UnityEngine.UI.Text` component in the player's children

#### Scenario: Fallback to Named GameObject
- **WHEN** no text component is found via `GetComponentInChildren`
- **THEN** it MUST search for a child GameObject specifically named "Nametag" to attempt to find a text component there

### Requirement: Local UserID Display
The system SHALL assign the current user's ID to the discovered nametag component.

#### Scenario: Successful Nametag Update
- **WHEN** a text component is found on the local player
- **THEN** its `text` property MUST be set to `MenuManager.Instance.userId`
