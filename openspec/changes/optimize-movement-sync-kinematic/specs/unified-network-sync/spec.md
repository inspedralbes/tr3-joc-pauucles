## ADDED Requirements

### Requirement: Role Detection in NetworkSync
The `NetworkSync` component SHALL automatically detect its role as either a "Local Player" or a "Remote Player" to determine its synchronization behavior.

#### Scenario: Role Identification
- **WHEN** the `NetworkSync` component starts
- **THEN** it MUST correctly identify if it is attached to the `LocalPlayer` instance or a remote player prefab

### Requirement: Role-Based Synchronized Behavior
The `NetworkSync` component SHALL provide optimized transmission for local players and smooth interpolation for remote players.

#### Scenario: Local Player Transmission
- **WHEN** `NetworkSync` is running on a local player
- **THEN** it SHALL only transmit its position and visual state over the network when significant movement or a tick-rate interval occurs

#### Scenario: Remote Player Reception
- **WHEN** `NetworkSync` is running on a remote player
- **THEN** it SHALL update its `posicioObjectiu` and visual state based on received messages and interpolate its position towards `posicioObjectiu`
