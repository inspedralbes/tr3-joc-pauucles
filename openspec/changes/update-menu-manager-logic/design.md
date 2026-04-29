## Context

The `MenuManager.cs` currently manages the basic transition between login and lobby. This design focuses on refining the button logic within the lobby and ensuring the reverse transition (lobby to login) is correctly implemented.

## Goals / Non-Goals

**Goals:**
- Implement the "Close Lobby" transition.
- Add debug logging for room creation and joining.
- Maintain existing login functionality.

**Non-Goals:**
- Implement actual networking or room listing logic.
- Change the UI layout or styling.

## Decisions

### Decision 1: Lobby to Login Transition
**Rationale**: Users must be able to return to the name entry screen if they wish to change their identity or logout.
**Implementation**: Update `btnTancarLobby` callback to set `pantallaLobby.style.display = DisplayStyle.None` and `pantallaLogin.style.display = DisplayStyle.Flex`.

### Decision 2: Console Feedback for Room Actions
**Rationale**: Providing console feedback helps verify that the buttons are correctly linked to the UI elements before implementing the full networking logic.
**Implementation**: Update `btnCrearPartida` and `btnUnirsePartida` callbacks with the specified `Debug.Log` messages.

## Risks / Trade-offs

- **[Risk]** UI Element references might be null if the `.uxml` is not aligned.
- **[Mitigation]** The script already includes null checks from previous versions; ensure they remain intact.
