## ADDED Requirements

### Requirement: Kinematic Rigidbodies for Remote Players
The system SHALL set the `Rigidbody2D.bodyType` of any remote player object to `Kinematic` during initialization to prevent local physics (like gravity) from interfering with network synchronization.

#### Scenario: Remote Player Initialization
- **WHEN** a `NetworkSync` component starts on a remote player object
- **THEN** it MUST set the associated `Rigidbody2D.bodyType` to `RigidbodyType2D.Kinematic`

### Requirement: Smooth Interpolated Movement
The system SHALL use linear interpolation (Lerp) to smoothly transition remote player objects to the last received position.

#### Scenario: Remote Position Update
- **WHEN** a remote player object has a valid `posicioObjectiu`
- **THEN** its `transform.position` MUST smoothly transition towards `posicioObjectiu` using `Vector3.Lerp` with a fixed speed (e.g., 15f) in the `Update` loop
