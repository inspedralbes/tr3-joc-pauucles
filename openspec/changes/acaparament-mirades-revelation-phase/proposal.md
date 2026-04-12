## Why

The current implementation of the "Acaparament de Mirades" minigame lacks its core gameplay mechanics. This change implements the logic where two players secretly choose a direction, followed by a revelation phase to determine the outcome. This enhances player engagement and completes the minigame suite.

## What Changes

- Implementation of the game loop in `MinijocAcaparamentMiradesLogic.cs`.
- Secret choice phase (5s) with input handling for both players (W/A/S/D for J1, Arrows for J2).
- Revelation phase (3s) displaying both choices before concluding the combat.
- Win condition: Player 2 (defender) wins if they choose the opposite direction of Player 1 (attacker).
- Update to `MinijocUIManager.cs` to apply a physical impulse to both players in the event of a draw, separating them.

## Capabilities

### New Capabilities
- `acaparament-mirades-logic`: Implements the direction-guessing gameplay mechanics, including timer-based choice and revelation phases.

### Modified Capabilities
- None.

## Impact

- `MinijocAcaparamentMiradesLogic.cs`: Full implementation of the minigame logic.
- `MinijocUIManager.cs`: Modification of `FinalitzarCombat` to handle draws with physical feedback.
- Player UI: New labels for time and results will be utilized.
