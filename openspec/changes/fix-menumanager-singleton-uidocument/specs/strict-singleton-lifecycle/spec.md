## ADDED Requirements

### Requirement: Strict Singleton Enforce
The `MenuManager` MUST enforce a strict singleton pattern where only one instance is allowed to exist in the application lifecycle.

#### Scenario: Duplicate instance prevention
- **WHEN** a second instance of `MenuManager` is instantiated (e.g., via scene load)
- **THEN** the application MUST destroy the new instance immediately and retain the original one.
