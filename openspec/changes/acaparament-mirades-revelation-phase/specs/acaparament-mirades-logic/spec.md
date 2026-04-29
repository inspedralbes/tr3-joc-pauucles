## ADDED Requirements

### Requirement: Secret Choice Phase
The system SHALL provide a 5-second window for both players to choose a direction secretly.

#### Scenario: Choice timer countdown
- **WHEN** the "Acaparament de Mirades" minigame starts
- **THEN** a timer of 5 seconds MUST be displayed and countdown to zero.

#### Scenario: Input for Player 1
- **WHEN** Player 1 presses W, A, S, or D
- **THEN** the system SHALL record the choice as "Amunt", "Esquerra", "Avall", or "Dreta" respectively, without revealing it.

#### Scenario: Input for Player 2
- **WHEN** Player 2 presses UpArrow, LeftArrow, DownArrow, or RightArrow
- **THEN** the system SHALL record the choice as "Amunt", "Esquerra", "Avall", or "Dreta" respectively, without revealing it.

### Requirement: Revelation Phase
The system MUST show the results of the choices before finalizing the combat.

#### Scenario: Showing choices
- **WHEN** 5 seconds have passed OR both players have made their choice
- **THEN** the system SHALL display "J1: <eleccioJ1> VS J2: <eleccioJ2>" for 3 seconds.

### Requirement: Win/Draw Evaluation
The system MUST determine the outcome based on the opposition of choices.

#### Scenario: Player 2 Wins on Opposite Directions
- **WHEN** Player 2 chooses the exact opposite direction of Player 1 (e.g., Amunt/Avall, Esquerra/Dreta)
- **THEN** "Jugador 2" SHALL be declared the winner.

#### Scenario: Draw on Non-Opposite Directions
- **WHEN** Player 2 chooses a direction that is NOT the exact opposite of Player 1 (e.g., Amunt/Amunt, Amunt/Esquerra)
- **THEN** the result SHALL be "Empat".

#### Scenario: Draw on Missing Choice
- **WHEN** time expires and at least one player has not made a choice ("Cap")
- **THEN** the result SHALL be "Empat".

### Requirement: Physical Feedback for Draw
The system MUST physically separate players if the result is a draw.

#### Scenario: AddForce on Empat
- **WHEN** the minigame result is "Empat"
- **THEN** an impulse force of 10f MUST be applied to both players in opposite directions to separate them.
