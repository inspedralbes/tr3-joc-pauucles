## 1. WebSocket Integration in MenuManager

- [x] 1.1 Add the `AlRebreActualitzacioSales(string dadesJSON)` method to `MenuManager.cs`.
- [x] 1.2 Subscribe to the WebSocket `OnMessage` event in the `Start` method to call the new handler.
- [x] 1.3 Implement message type filtering to only process "room_list" updates.

## 2. Dynamic UI Refresh Logic

- [x] 2.1 Implement JSON deserialization using `JsonUtility` inside `AlRebreActualitzacioSales`.
- [x] 2.2 Wrap the UI update logic in `EnqueueMainThread` to ensure thread safety.
- [x] 2.3 Refresh the `llistaPartides` ListView with the received room data.

## 3. Verification

- [x] 3.1 Verify that the client receives and processes the "room_list" message correctly.
- [x] 3.2 Confirm the Lobby UI updates instantly when a new room list is received.
