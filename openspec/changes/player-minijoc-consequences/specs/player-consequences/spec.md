## ADDED Requirements

### Requirement: Life System Display
The system SHALL maintain a count of player lives (starting at 3) and display it via a Text UI component.

#### Scenario: Lives are shown
- **WHEN** the game starts
- **THEN** the Text UI SHALL display "Vides: 3"

### Requirement: Lose Combat Consequence
The system SHALL handle a combat loss by dropping the flag, reducing lives by 1, and freezing the player for 7 seconds.

#### Scenario: Player loses combat
- **WHEN** a loss event is triggered
- **THEN** the player SHALL drop the flag (`SetParent(null)`)
- **THEN** the player's life count SHALL decrease by 1
- **THEN** the player SHALL be unable to move for 7 seconds
- **THEN** the player's color SHALL change temporarily to indicate a frozen state

### Requirement: Respawn Logic
The system SHALL teleport the player to a respawn point and freeze them for 45 seconds when lives reach 0.

#### Scenario: Lives reach zero
- **WHEN** lives reach 0
- **THEN** the player SHALL teleport to `puntRespawn`
- **THEN** the player SHALL be frozen for 45 seconds
- **THEN** the player's lives SHALL reset to 3 after the 45-second freeze

### Requirement: Win Combat Consequence
The system SHALL handle a combat win by granting 5 seconds of invulnerability.

#### Scenario: Player wins combat
- **WHEN** a win event is triggered
- **THEN** the player SHALL become invulnerable for 5 seconds
- **THEN** the player's color SHALL change temporarily to indicate invulnerability
