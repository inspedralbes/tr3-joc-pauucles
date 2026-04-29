## ADDED Requirements

### Requirement: Positional Follow with Offset
When a flag is captured, it SHALL maintain its position relative to the capturing player to visually simulate being carried.

#### Scenario: Update Position While Captured
- **WHEN** `esCapturada` is `true` and `targetSeguiment` is not null
- **THEN** the flag's position MUST be set to the target's position plus a relative offset (e.g., Vector3(-1f, 0.5f, 0f)) in every update tick
