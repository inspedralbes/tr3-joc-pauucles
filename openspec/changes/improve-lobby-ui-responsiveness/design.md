## Context

The current Lobby UI in `MenuUI.uxml` relies heavily on inline styles with fixed pixel dimensions (e.g., `width: 405px`). This causes the UI to appear tiny or misaligned on high-resolution displays or when the build window is resized. The project uses Unity's UI Toolkit, but the `MenuStyles.uss` file is underutilized.

## Goals / Non-Goals

**Goals:**
- Centralize window styling into a reusable USS class `.finestra-principal`.
- Implement responsive layout using percentage widths and maximum width constraints.
- Fix missing/incorrect identifiers for the room code label in the waiting room.
- Standardize and increase font sizes for improved readability.

**Non-Goals:**
- Redesigning the visual assets or theme.
- Modifying the underlying `MenuManager.cs` logic unless necessary for UI binding.

## Decisions

### 1. Introduce `.finestra-principal` USS Class
Instead of repeating background images and flex settings in every window (`finestraLogin`, `finestraLobby`, etc.), we will move these to a CSS class.
- **Rationale**: Better maintainability and consistency.
- **Alternatives**: Keeping inline styles was rejected as it makes responsive adjustments difficult across multiple elements.

### 2. Responsive Sizing
Use `width: 80%` and `max-width: 600px` for the main windows.
- **Rationale**: Ensures the UI takes up a reasonable amount of screen space on mobile/smaller windows while not becoming excessively large on ultrawide monitors.

### 3. Font Size Standardization
Increase base font size for buttons from 12px to 16px.
- **Rationale**: 12px is often unreadable in standalone builds on standard monitors.

## Risks / Trade-offs

- **[Risk]** → Background images might stretch or tile incorrectly with variable widths.
- **[Mitigation]** → Use `background-size: 100% 100%` or ensure the slice settings in Unity are correctly configured for 9-slicing.
- **[Risk]** → The `ListView` height might need adjustment if the window height becomes `auto`.
- **[Mitigation]** → Set a minimum height or use flex-grow for the list containers.
