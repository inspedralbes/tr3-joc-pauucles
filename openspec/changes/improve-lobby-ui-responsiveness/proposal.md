## Why

The current Lobby UI in the Unity project uses fixed pixel widths for main containers, which results in poor visual scaling on different resolutions in build environments. Additionally, the room code in the waiting room lacks a standardized identifier for programmatic updates, and font sizes are too small for comfortable readability in a standalone build.

## What Changes

- **UI Responsiveness**: Convert fixed pixel widths in `MenuUI.uxml` to relative widths (80% or max-width 600px) and set `height: auto` for main windows.
- **Styling**: Move inline styles for "grey boxes" (finestraLogin, finestraLobby, etc.) to a reusable class in `MenuStyles.uss` to improve maintainability and ensure consistency.
- **Room Code Identification**: Ensure the room code label in the waiting room section of `MenuUI.uxml` has the name `codeLabel`.
- **Readability**: Increase font sizes for buttons and labels that are currently too small (e.g., from 12px to 16px-18px).

## Capabilities

### New Capabilities
- None (UI refinement only).

### Modified Capabilities
- None (No core requirement changes).

## Impact

- `DAMT3Atrapa la bandera/Assets/UI/MenuUI.uxml`: Structure and inline styles updates.
- `DAMT3Atrapa la bandera/Assets/UI/MenuStyles.uss`: New classes for responsive windows and general UI improvements.
