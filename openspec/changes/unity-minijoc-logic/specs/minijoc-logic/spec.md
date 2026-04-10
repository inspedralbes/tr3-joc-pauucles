## ADDED Requirements

### Requirement: Parells o Senars (Evens or Odds) Logic
The system SHALL determine the winner based on two integer choices (0-5) and a side selection (Evens or Odds).
The sum of the choices determines the result: even sum favors "Evens", odd sum favors "Odds".

#### Scenario: Player 1 wins with Evens
- **WHEN** Player 1 chooses "Evens" and 2, Player 2 chooses 2
- **THEN** Result is "Player 1 Wins" because 2+2=4 (Even)

#### Scenario: Player 1 wins with Odds
- **WHEN** Player 1 chooses "Odds" and 3, Player 2 chooses 2
- **THEN** Result is "Player 1 Wins" because 3+2=5 (Odd)

### Requirement: Acaparament de Mirades (Gaze Snatching) Logic
The system SHALL determine if the player successfully "snatches" the gaze or "avoids" it by comparing direction choices (Up, Down, Left, Right).
If choices match, the "snatcher" wins. If they differ, the "avoider" wins.

#### Scenario: Snatcher wins on match
- **WHEN** Player 1 (Snatcher) chooses "Up" and Player 2 (Avoider) chooses "Up"
- **THEN** Result is "Player 1 Wins"

#### Scenario: Avoider wins on mismatch
- **WHEN** Player 1 (Snatcher) chooses "Up" and Player 2 (Avoider) chooses "Down"
- **THEN** Result is "Player 2 Wins"

### Requirement: Polsim de Força (Force Dust) Logic
The system SHALL calculate the progression of a strength bar based on the frequency of inputs (clicks/taps) compared to a resistance value.
The logic SHALL return the current percentage of progress towards the goal (0 to 100).

#### Scenario: Progress increases with input
- **WHEN** Current progress is 50 and an input event occurs with value 5
- **THEN** Resulting progress is 55

#### Scenario: Resistance decreases progress over time
- **WHEN** Current progress is 50 and a time step occurs with resistance 2
- **THEN** Resulting progress is 48

### Requirement: Atura la Barra (Stop the Bar) Logic
The system SHALL determine if a timed action occurs within a target range (window) of a moving bar.
The logic SHALL return the precision of the stop (Perfect, Good, Miss).

#### Scenario: Perfect stop
- **WHEN** Target center is 0.5, window size is 0.1, and player stops at 0.5
- **THEN** Result is "Perfect"

#### Scenario: Missed stop
- **WHEN** Target center is 0.5, window size is 0.1, and player stops at 0.7
- **THEN** Result is "Miss"

### Requirement: Cable Pelat (Stripped Cable) Logic
The system SHALL detect if a player interaction happens exactly during a "safe" window or an "active" trigger.
The logic SHALL handle the timing window validation for reflex-based actions.

#### Scenario: Successful reflex
- **WHEN** Safe window is between 1.0s and 1.2s, and player clicks at 1.1s
- **THEN** Result is "Success"

#### Scenario: Early reflex
- **WHEN** Safe window starts at 1.0s, and player clicks at 0.9s
- **THEN** Result is "Failure"

### Requirement: Rock-Paper-Scissors-Lizard-Spock (RPSTLLS) Logic
The system SHALL evaluate the winner between two players choosing from 5 options (Pedra, Paper, Tisora, Llangardaix, Spock) based on the 10 standard rules.

#### Scenario: Spock vaporizes Rock
- **WHEN** Player 1 chooses "Spock" and Player 2 chooses "Pedra"
- **THEN** Result is "Player 1 Wins"

#### Scenario: Lizard eats Paper
- **WHEN** Player 1 chooses "Llangardaix" and Player 2 chooses "Paper"
- **THEN** Result is "Player 1 Wins"
