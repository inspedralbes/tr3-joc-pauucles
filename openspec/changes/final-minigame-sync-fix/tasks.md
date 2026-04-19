## 1. RemotePlayer Update

- [x] 1.1 Add `public string username;` field to `RemotePlayer.cs`.
- [x] 1.2 Update `RemotePlayer.Configurar(string name)` to populate the new `username` field.

## 2. Player Collision Logic Rewrite

- [x] 2.1 Update `OnCollisionEnter2D` in `Player.cs` to retrieve `nomRival` using `collision.gameObject.GetComponent<RemotePlayer>().username`.
- [x] 2.2 Add null-checks for the `RemotePlayer` component and the username.
- [x] 2.3 Implement the **Host logic branch**: generate `gameIndex`, activate UI via `Resources.FindObjectsOfTypeAll`, and THEN send the WebSocket message.
- [x] 2.4 Implement the **Client logic branch**: freeze movement and `return` immediately.

## 3. Network Discovery Refinement

- [ ] 3.1 Verify `Resources.FindObjectsOfTypeAll<MinijocUIManager>()[0]` correctly finds and activates the UI manager in a standalone build context.
- [ ] 3.2 Ensure the Client's network receiver is the ONLY path for UI activation for the Follower.

## 4. Verification

- [ ] 4.1 Verify that the Host sees the minigame UI instantly upon collision.
- [ ] 4.2 Verify that the Client waits for the Host's broadcast before opening the UI.
- [ ] 4.3 Confirm both players end up in the exact same minigame session.
