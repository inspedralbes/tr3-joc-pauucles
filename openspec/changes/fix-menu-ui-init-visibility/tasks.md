## 1. Core Implementation

- [x] 1.1 In `MenuManager.cs`, create a method `ActualitzarVisibilitatSegonsSessio()` that checks for an existing `userId`.
- [x] 1.2 Implement logic in `ActualitzarVisibilitatSegonsSessio()` to toggle `pantallaLogin` and `pantallaLobby` using `DisplayStyle`.
- [x] 1.3 Update the `Start()` method in `MenuManager.cs` to call `ActualitzarVisibilitatSegonsSessio()` at the end of its execution.
- [x] 1.4 Ensure `UIDocument` root visibility is forced to `Flex` in `ActualitzarVisibilitatSegonsSessio()`.

## 2. Refinement and Edge Cases

- [x] 2.1 Verify that UI references (`pantallaLogin`, `pantallaLobby`) are valid before toggling visibility.
- [x] 2.2 Re-trigger a lobby list refresh (`ObtenirPartides`) if the user is already authenticated on reentry.

## 3. Verification

- [x] 3.1 Verify that the Login screen appears on first launch.
- [x] 3.2 Verify that the Lobby screen appears immediately when returning from the game scene after having logged in.
- [x] 3.3 Verify that no blank blue screen is visible during scene transitions.
