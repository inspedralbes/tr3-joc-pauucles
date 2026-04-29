## MODIFIED Requirements

### Requirement: Scene Transition Integrity
The game foundation MUST ensure that session state is consistent and UI elements are responsive across scene transitions.

#### Scenario: Robust reentry
- **WHEN** transitioning from gameplay back to the hub/menu
- **THEN** all transient gameplay data is purged and hub UI interaction is restored.
