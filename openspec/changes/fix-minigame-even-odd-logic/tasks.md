## 1. Class State and Timer Logic

- [x] 1.1 Add `private float tempsRestant = 5f;` and `private bool jocActiu = false;` to `MinijocParellsSenarsLogic.cs`.
- [x] 1.2 Implement the `Update()` method to handle the countdown timer when `jocActiu` is true.
- [x] 1.3 Ensure `Update()` triggers `CridarDerrota()` when `tempsRestant` reaches zero.

## 2. UI Initialization and Interaction

- [x] 2.1 Update the initialization method (e.g., `PreparaSuma`) to find buttons using `root.Q<Button>`.
- [x] 2.2 Assign `.clicked` events to the "Parell" and "Senar" buttons.
- [x] 2.3 Implement the validation logic within button click handlers (check if sum is even/odd).
- [x] 2.4 Set `jocActiu = true` and `tempsRestant = 5f` at the start of the minigame.

## 3. Game Completion Logic

- [x] 3.1 Implement `CridarDerrota()` to deactivate the UI and call `playerLocal.PerdreMinijoc()`.
- [x] 3.2 Implement the winning logic to deactivate the UI and call `playerLocal.GuanyarMinijoc()`.
- [x] 3.3 Ensure `jocActiu = false` is set immediately upon any game completion (win, loss, or timeout).

## 4. Validation

- [x] 4.1 Verify that clicking buttons after the game ends has no effect.
- [x] 4.2 Confirm the UI disappears as expected.
- [x] 4.3 Test that the timer accurately triggers a loss after 5 seconds.
