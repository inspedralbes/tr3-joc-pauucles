## ADDED Requirements

### Requirement: Combat Initiation Guard
The system MUST prevent multiple combat instances from being initiated simultaneously.

#### Scenario: Simultaneous Collision
- **WHEN** multiple `OnCollisionEnter2D` events occur between players while a minigame is already active (`minijocActiu == true`)
- **THEN** subsequent calls to `ShowUI` MUST be ignored.

### Requirement: Input Resolution Guard
The system MUST ensure that only one input is processed per combat round to prevent race conditions or duplicate results.

#### Scenario: Rapid Double Click
- **WHEN** a player clicks a combat action button (e.g., "Pedra") while a result is already being resolved (`combatResolentse == true`)
- **THEN** the subsequent clicks MUST be ignored and the `Handle*Click` methods MUST return immediately.

### Requirement: Automatic State Reset
The system MUST automatically reset combat state variables when the combat UI is hidden.

#### Scenario: Combat Ends
- **WHEN** `HideUI` is called after a combat concludes
- **THEN** `minijocActiu` MUST be set to `false`, allowing new combats to be initiated.

### Requirement: Event Listener Cleanup
The system MUST clear button event listeners before re-binding or upon closing the UI to prevent memory leaks and multiple executions.

#### Scenario: Re-opening Combat UI
- **WHEN** the combat UI is opened (`ShowUI`) after being previously closed
- **THEN** any existing listeners on the buttons MUST be removed (`-=`) before new listeners are added (`+=`).
