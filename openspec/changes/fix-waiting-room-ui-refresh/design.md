## Context

The `MenuManager` is a persistent singleton that manages the game's UI and networking state. When a player is in the "Waiting Room" (`pantallaSalaEspera`), they need to see updates as other players join or leave. These updates are received via the `ROOM_UPDATED` WebSocket event. While some logic for this exists in `OmplirLlistaJugadors`, a more explicit and reliable refresh mechanism is required to ensure the visual elements always match the internal `currentRoomData`.

## Goals / Non-Goals

**Goals:**
- Provide a robust way to refresh the player list in the UI.
- Hook the refresh logic directly into the WebSocket message processing loop.
- Ensure the UI correctly displays each player's name and ready status.

**Non-Goals:**
- Refactoring the entire UI Toolkit setup.
- Modifying the backend WebSocket broadcast logic.

## Decisions

- **New Refresh Method**: Implement `ActualitzarUIJugadorsSala()`. This method will be responsible for re-synchronizing the visual player list with the data stored in `currentRoomData.players`.
- **UI Toolkit Querying**: The method will query for the relevant visual elements (like `llistaJugadorsSala` or specific labels) using `rootVisualElement.Q<T>()` to ensure it always operates on the current scene's elements.
- **WebSocket Hook**: Insert a call to `ActualitzarUIJugadorsSala()` inside `AlRebreActualitzacioSales` specifically within the block that handles `"type":"ROOM_UPDATED"`.
- **String Construction**: For each player in the list, a string will be formatted: `"Jugador: " + player.username + (player.isReady ? " (Llest)" : " (Esperant)")`.

## Risks / Trade-offs

- **[Risk]** → Accessing UI elements from a background thread (WebSocket callback).
    - **[Mitigation]** → Use the existing `EnqueueMainThread` mechanism or ensure the update logic is called within a thread-safe context.
- **[Trade-off]** → Rebuilding the whole list instead of surgical updates.
    - **[Mitigation]** → Given the small maximum number of players (typically 4-8), rebuilding the list is extremely fast and ensures there are no synchronization bugs between data and view.
