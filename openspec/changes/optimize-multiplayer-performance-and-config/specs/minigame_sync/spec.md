## MODIFIED Requirements

### Requirement: Real-time Minigame Synchronization
El sistema ha de garantir que quan dos jugadors col·lisionen, s'iniciï exactament el mateix minijoc en ambdós clients i que les accions realitzades dins del minijoc es reflecteixin en temps real. El minijoc "Cable Pelat" (ID 4) MUST be excluded.

#### Scenario: Collision triggers minigame
- **WHEN** local player detects collision with an enemy
- **THEN** system SHALL send MINIJOC_START and disable movement (potMoure = false) for both players immediately

### Requirement: Player Movement Lock during Minigames
Els jugadors MUST remain locked (`potMoure = false`) from the moment the collision is detected until the result is processed.

#### Scenario: Movement remains locked
- **WHEN** minigame is active or in transition
- **THEN** player inputs SHALL be ignored and velocity MUST be zeroed
