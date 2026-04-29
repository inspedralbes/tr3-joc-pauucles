## ADDED Requirements

### Requirement: Trigger-Based Proximity Detection
The system SHALL detect the flag using `OnTriggerEnter2D` and `OnTriggerExit2D` events to support trigger colliders.

#### Scenario: Entering Flag Range (Trigger)
- **WHEN** a player's trigger collider enters an object tagged "Bandera"
- **THEN** `aPropDeBandera` SHALL be set to `true`
- **AND** the flag object SHALL be stored in `banderaPropera`

#### Scenario: Exiting Flag Range (Trigger)
- **WHEN** a player's trigger collider exits the object stored in `banderaPropera`
- **THEN** `aPropDeBandera` SHALL be set to `false`
- **AND** `banderaPropera` SHALL be set to `null`

### Requirement: Safe Pickup Execution
The system SHALL verify the existence of the flag reference before executing any pickup logic to prevent runtime errors.

#### Scenario: Manual Pickup Attempt
- **WHEN** the manual pickup function is called
- **AND** `banderaPropera` is `null`
- **THEN** the system SHALL exit the function immediately without performing any actions

### Requirement: Standardized Flag Acquisition
The system SHALL ensure the flag is correctly attached and its physical properties are disabled upon successful manual pickup.

#### Scenario: Successful Manual Pickup
- **WHEN** the manual pickup is executed with a valid `banderaPropera`
- **THEN** the flag's `fugint` state SHALL be set to `false`
- **AND** the flag's parent SHALL be set to the player
- **AND** the flag's `localPosition` SHALL be set to `(-0.8f, 0, 0)`
- **AND** the flag's `Collider2D` SHALL be disabled
- **AND** `aPropDeBandera` SHALL be set to `false`
