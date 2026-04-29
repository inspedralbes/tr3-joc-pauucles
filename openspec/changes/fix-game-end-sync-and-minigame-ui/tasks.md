## 1. Backend Implementation

- [x] 1.1 Update `backend/src/server.js` to handle `GAME_OVER` message type and broadcast it to the room.

## 2. Frontend Game Over Synchronization

- [x] 2.1 Define `GameOverMessage` class in `GameManager.cs` or `MenuManager.cs`.
- [x] 2.2 Modify `GameManager.FinalitzarPartida(bool victoria)` to send a `GAME_OVER` message when `victoria` is true.
- [x] 2.3 Update `MenuManager.AlRebreActualitzacioSales` to process the `GAME_OVER` message.
- [x] 2.4 Call `GameManager.Instance.FinalitzarPartida(false)` when a `GAME_OVER` message is received (and it's not from the local player).

## 3. Minigame UI Visibility and Renaming

- [x] 3.1 Rename `ShowUI` to `IniciarMinijoc` in `MinijocUIManager.cs`.
- [x] 3.2 Add visibility logic (GameObject active and DisplayStyle.Flex) at the beginning of `IniciarMinijoc`.
- [x] 3.3 Update all calls to `ShowUI` in `Player.cs` to `IniciarMinijoc`.
- [x] 3.4 Ensure `AmagarTotsElsContenidors` is called correctly to avoid UI overlaps.

## 4. Verification

- [x] 4.1 Verify that capturing the flag triggers the victory screen on the winner's client.
- [x] 4.2 Verify that the opponent receives the `GAME_OVER` message and shows the defeat screen.
- [x] 4.3 Verify that the minigame UI is always visible and interactive when a combat starts.
