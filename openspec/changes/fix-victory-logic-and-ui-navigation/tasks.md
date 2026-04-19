## 1. Player Logic Refinement

- [x] 1.1 In `Player.cs`, identify the collision trigger method responsible for base/flag capture.
- [x] 1.2 Add a check at the start of the method to detect remote players (clones) via `name.Contains("(Clone)")` or `GetComponent<RemotePlayer>()`.
- [x] 1.3 Implement an immediate `return` for remote players to prevent them from triggering local victory.

## 2. Game Manager and Network Sync

- [x] 2.1 In `GameManager.cs`, locate the `FinalitzarPartida` method.
- [x] 2.2 Update the `roomId` retrieval logic to use `MenuManager.Instance.currentRoomData.roomId`.
- [x] 2.3 Add a null check for `MenuManager.Instance.currentRoomData` before accessing the ID to prevent runtime errors.
- [x] 2.4 Verify that the `GameOverMessage` sent over WebSocket now includes the correct room ID.

## 3. UI Toolkit and Navigation

- [x] 3.1 In `GameManager.cs`, find the UI initialization or end-screen display logic.
- [x] 3.2 Implement a query-based subscription: `root.Query<Button>("BotoTornar").ToList().ForEach(btn => btn.clicked += TornarAlMenu);`.
- [x] 3.3 Add `Debug.Log("[GameManager] Botó premut, tornant al menú...");` inside the `TornarAlMenu` method.
- [x] 3.4 Ensure the scene transition to `MenuPrincipal` is correctly invoked after the log.

## 4. Verification

- [x] 4.1 Verify that an enemy player touching the base does not end the match for the local player.
- [x] 4.2 Verify that the "Back to Menu" button works consistently on the end-game screen.
