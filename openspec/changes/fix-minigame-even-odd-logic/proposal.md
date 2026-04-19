## Why

The even-odd minigame currently lacks a timer and proper UI interaction logic, making it incomplete and non-functional within the game flow. This change adds the necessary game mechanics and UI feedback to make it a playable challenge.

## What Changes

- **Timer Implementation**: Add a 5-second countdown timer to `MinijocParellsSenarsLogic.cs`.
- **UI Button Mapping**: Connect UI buttons to answer validation logic using `root.Q<Button>`.
- **Game State Management**: Track if the game is active to handle time-outs and prevent multiple clicks.
- **Result Communication**: Trigger `playerLocal.GuanyarMinijoc()` or `playerLocal.PerdreMinijoc()` based on the player's performance.
- **UI Cleanup**: Automatically close the minigame UI upon completion (win, loss, or timeout).

## Capabilities

### New Capabilities
- `minigame-timed-challenge`: Logic for handling time-limited interactions in minigames.
- `minigame-response-validation`: Standardized pattern for validating player input through UI buttons in minigames.

### Modified Capabilities
- `minigame-even-odd`: Updating the existing minigame logic to include the timer and UI restoration.

## Impact

- `MinijocParellsSenarsLogic.cs`: Main logic file for the minigame.
- `PlayerLocal`: Interaction with the local player's game state.
- UI Toolkit: Interaction with buttons and time labels in the UIDocument.
