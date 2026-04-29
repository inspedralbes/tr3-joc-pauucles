## ADDED Requirements

### Requirement: Manager Lifecycle Integrity
Global managers (singletons) MUST maintain reference integrity across scene transitions to ensure UI responsiveness.

#### Scenario: Persistent manager UI update
- **WHEN** a global manager persists across scene loads
- **THEN** it SHALL update its internal scene-dependent references (like UI Documents) before attempting to interact with the new scene's objects.
