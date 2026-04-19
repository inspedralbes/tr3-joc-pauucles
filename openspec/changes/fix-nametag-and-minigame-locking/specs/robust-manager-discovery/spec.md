## ADDED Requirements

### Requirement: Multi-stage Manager Discovery
The system SHALL attempt multiple methods to locate the `MinijocUIManager` when a combat-triggering collision occurs.

#### Scenario: Singleton instance is missing
- **WHEN** a player collides with an enemy
- **AND** `MinijocUIManager.Instance` returns null
- **THEN** the system MUST attempt to find the manager using the object name "PantallaCombats"
- **AND** if found, the system MUST proceed with combat initialization

### Requirement: Combat Initialization Feedback
The system SHALL log a specific diagnostic message once the UI manager is successfully located and player freezing is initiated.

#### Scenario: Successful combat start
- **WHEN** the `MinijocUIManager` is found (either via singleton or name)
- **THEN** the system MUST log "[SISTEMA] UI trobada amb èxit, parant jugadors..." to the console
