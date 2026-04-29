## 1. Cleanup and Refactoring

- [x] 1.1 Remove `using UnityEngine.UI;` and replace with `using UnityEngine.UIElements;` in `Player.cs`.
- [x] 1.2 Remove the `public Text livesText;` declaration.
- [x] 1.3 Update player starting lives to 5.
- [x] 1.4 Add `public UIDocument uiDocument;` declaration.
- [x] 1.5 Add `private List<VisualElement> lifeIcons = new List<VisualElement>();` declaration.

## 2. HUD Initialization

- [x] 2.1 In `Start()`, query the `rootVisualElement` of `uiDocument` to find 'Vida1' through 'Vida5' and add them to `lifeIcons`.
- [x] 2.2 Call a reset UI function in `Start()` and when respawning to ensure all 5 icons are visible (`display = DisplayStyle.Flex`).

## 3. UI Logic Implementation

- [x] 3.1 Replace the existing `UpdateLivesUI()` method with a new version that iterates through `lifeIcons` and sets `style.display = DisplayStyle.None` for elements beyond the current `lives` count.
- [x] 3.2 Ensure the new UI logic is correctly triggered in `LoseCombat()` and `HandleRespawnCoroutine()`.

## 4. Final Integration

- [x] 4.1 Verify that the existing coroutines (`HandleWinCoroutine`, `HandleLossCoroutine`, `HandleRespawnCoroutine`) still function correctly with the 5-life system.
- [x] 4.2 Confirm that `isFrozen` and `isInvulnerable` logic remains untouched.
