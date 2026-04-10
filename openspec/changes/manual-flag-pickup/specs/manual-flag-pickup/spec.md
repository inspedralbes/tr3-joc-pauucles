## ADDED Requirements

### Requirement: Action Button Assignment
The system SHALL assign specific action buttons for flag pickup based on the player ID.

#### Scenario: Player IDs and Buttons
- **WHEN** the player has `idJugador == 1`
- **THEN** the action button SHALL be `KeyCode.E`
- **WHEN** the player has `idJugador == 2`
- **THEN** the action button SHALL be `KeyCode.RightControl`

### Requirement: Proximity Awareness
The system MUST track when a player is within interaction range of the flag.

#### Scenario: Entering Range
- **WHEN** a player collides or enters the trigger of an object tagged "Bandera"
- **THEN** the system SHALL set `aPropDeBandera` to `true`
- **AND** the system SHALL store the reference to the flag object in `banderaPropera`

#### Scenario: Exiting Range
- **WHEN** a player exits the collision or trigger of the stored `banderaPropera`
- **THEN** the system SHALL set `aPropDeBandera` to `false`
- **AND** the system SHALL clear the reference in `banderaPropera`

### Requirement: Manual Pickup Execution
The system SHALL only execute the flag pickup logic when the player is in range and presses the assigned action button.

#### Scenario: Successful Pickup
- **WHEN** `aPropDeBandera` is `true`
- **AND** the player presses their assigned action button
- **THEN** the system SHALL set the flag as a child of the player
- **AND** the system SHALL disable the flag's fugitive state (`fugint = false`)
- **AND** the system SHALL disable the flag's collider
- **AND** the system SHALL set `aPropDeBandera` to `false`
