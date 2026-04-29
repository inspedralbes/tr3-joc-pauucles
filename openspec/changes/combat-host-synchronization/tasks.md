## 1. Player Collision Logic Refactor

- [x] 1.1 Update `OnCollisionEnter2D` in `Player.cs` to retrieve both usernames (`WebSocketClient.LocalUsername` and `opponent.GetComponent<Player>().username` if available, or equivalent).
- [x] 1.2 Implement the lexicographical comparison: `string.Compare(nomP1, nomP2) < 0`.
- [x] 1.3 Implement the **Host branch**: freeze players, generate `gameIndex`, call local `IniciarMinijoc(index)`, and send `MINIJOC_START` message.
- [x] 1.4 Implement the **Client branch**: freeze players and wait (do not open UI).

## 2. Networking and UI Management

- [x] 2.1 Update `MenuManager.cs` (or `GameManager.cs`) to define the `MinigameStartMessage` class for JSON serialization.
- [x] 2.2 Add handling for the `MINIJOC_START` message in the WebSocket message dispatcher.
- [x] 2.3 Implement the participant check: if the local player is either `p1` or `p2` and was not the initiator, trigger the minigame UI.
- [x] 2.4 Update `MinijocUIManager.cs` to allow `IniciarMinijoc` to accept an optional `gameIndex` instead of always generating one randomly.

## 3. Verification

- [ ] 3.1 Verify that the player with the smaller username always becomes the Host.
- [ ] 3.2 Verify that both participants see the exact same minigame simultaneously.
- [ ] 3.3 Ensure non-combatants are not affected by the `MINIJOC_START` broadcast.
