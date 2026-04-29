## 1. UI Transition Implementation

- [x] 1.1 In `MenuManager.cs`, locate the `EnviarPeticio` coroutine and the block handling `/users/login` success.
- [x] 1.2 Add an explicit call to `ActualitzarVisibilitatSegonsSessio()` immediately after the user data is stored.
- [x] 1.3 Implement a fallback toggle: explicitly set `pantallaLogin.style.display = DisplayStyle.None` and `pantallaLobby.style.display = DisplayStyle.Flex`.
- [x] 1.4 Add the trace log: `Debug.Log("[MenuManager] Canviant UI a Lobby després de Login exitós");`.

## 2. Verification

- [x] 2.1 Perform a successful login and verify the UI transitions to the Lobby screen without displaying a blank blue background.
- [x] 2.2 Verify the console log confirms the transition.
- [x] 2.3 Verify that the room list automatically refreshes after the transition (already part of `ActualitzarVisibilitatSegonsSessio`).
