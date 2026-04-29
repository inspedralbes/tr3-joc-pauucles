## 1. Player Logic Updates

- [x] 1.1 Update `OnCollisionEnter2D` in `Player.cs` to search for the manager using `Resources.FindObjectsOfTypeAll<MinijocUIManager>()`.
- [x] 1.2 Implement the activation logic: if a manager is found, set its GameObject to active and log "[SISTEMA] UI TROBADA I ENCESA PER LA FORÇA!".
- [x] 1.3 Call the updated `IniciarMinijoc` passing `this.gameObject` and `collision.gameObject`.
- [x] 1.4 Add a `Debug.LogError` if no `MinijocUIManager` is found.

## 2. MinijocUIManager Refactoring

- [x] 2.1 Update `IniciarMinijoc` signature to receive two `GameObject` parameters.
- [x] 2.2 Inside `IniciarMinijoc`, get the `Player` components from the GameObjects and set `potMoure = false` for both.
- [x] 2.3 Refine the `AmagarTotsElsMinijocs` method to hide all containers using `DisplayStyle.None`.
- [x] 2.4 Update the `switch` statement in `IniciarMinijoc` to set the selected container to `DisplayStyle.Flex`.

## 3. Verification

- [ ] 3.1 Verify combat correctly initiates even if the UI manager starts disabled.
- [ ] 3.2 Confirm that only the two participants are frozen.
- [ ] 3.3 Ensure the correct minigame UI is visible without overlap.
