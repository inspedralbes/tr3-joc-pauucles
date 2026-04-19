## ADDED Requirements

### Requirement: Flag Detachment from Parent
The system SHALL provide a way to detach a flag object from its parent transform in the hierarchy.

#### Scenario: Dropping or Losing the Flag
- **WHEN** `DeixarDeSeguir()` is called on a `Bandera` instance
- **THEN** the system MUST set the flag's parent to `null` (`transform.SetParent(null)`)
