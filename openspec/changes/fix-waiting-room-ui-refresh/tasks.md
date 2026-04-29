## 1. WebSocket Integration

- [x] 1.1 In `MenuManager.cs`, locate the `AlRebreActualitzacioSales` method.
- [x] 1.2 Identify the logic block that handles `"type":"ROOM_UPDATED"`.
- [x] 1.3 Ensure that `ActualitzarUIJugadorsSala()` is called after updating `currentRoomData` within the `EnqueueMainThread` callback.

## 2. UI Refresh Logic Implementation

- [x] 2.1 Implement `private void ActualitzarUIJugadorsSala()` in `MenuManager.cs`.
- [x] 2.2 Inside `ActualitzarUIJugadorsSala()`, use `GetComponent<UIDocument>().rootVisualElement` to ensure access to current visual elements.
- [x] 2.3 Query for the player list element (e.g., `root.Q<ListView>("llistaJugadorsSala")` or a specific label if used for display).
- [x] 2.4 Iterate through `currentRoomData.players` and construct the formatted status string for each player: `"Jugador: " + p.username + (p.isReady ? " (Llest)" : " (Esperant)")`.
- [x] 2.5 Re-bind or update the UI element's itemsSource and refresh the view.
- [x] 2.6 Add `Debug.Log("[MenuManager] Forçant refresc de la llista de jugadors.");` to track execution.

## 3. Verification

- [x] 3.1 Trigger a `ROOM_UPDATED` event and verify the player list reflects joins/leaves instantly.
- [x] 3.2 Change a player's ready status and verify the text updates to "(Llest)" immediately.
- [x] 3.3 Confirm no stale data remains after a room is deleted.
