## ADDED Requirements

### Requirement: Rigidbody2D Body Type Management
The system SHALL use the `bodyType` property instead of `isKinematic` to manage the physical behavior of `Rigidbody2D` components.

#### Scenario: Switching to Kinematic
- **WHEN** a script needs to make a `Rigidbody2D` kinematic (e.g., during transport or penalty)
- **THEN** it SHALL set `bodyType` to `RigidbodyType2D.Kinematic`

#### Scenario: Switching to Dynamic
- **WHEN** a script needs to restore physical behavior to a `Rigidbody2D`
- **THEN** it SHALL set `bodyType` to `RigidbodyType2D.Dynamic`
