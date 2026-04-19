## Context

The `MinijocParellsSenarsLogic.cs` handles the "Even or Odd" minigame logic. Currently, it generates a sum but doesn't manage the gameplay flow, timer, or user interaction. The game needs to be time-bound (5 seconds) and provide immediate feedback to the local player.

## Goals / Non-Goals

**Goals:**
- Add a 5-second countdown timer.
- Connect UI buttons ("Parell" and "Senar") to validation logic.
- Handle win/loss states by calling the local player's methods.
- Ensure the UI is disabled after the game ends.

**Non-Goals:**
- Redesigning the UXML/USS files.
- Implementing complex networking (handled by existing `playerLocal` methods).

## Decisions

### 1. Timer Implementation
- **Decision**: Use `Update()` with `Time.deltaTime`.
- **Rationale**: Standard and efficient way to handle short countdowns in Unity.
- **Alternative**: `IEnumerator` with `WaitForSeconds`, but `Update()` allows easier UI updates per frame.

### 2. State Management
- **Decision**: Use a `private bool jocActiu` flag.
- **Rationale**: Prevents multiple clicks from triggering multiple results and stops the timer logic once a result is achieved.

### 3. UI Interaction
- **Decision**: Use `root.Q<Button>` and `.clicked += ...`.
- **Rationale**: Standard UI Toolkit pattern for event handling.

## Risks / Trade-offs

- **[Risk]**: Buttons clicked after the timer hits zero or multiple times.
- **[Mitigation]**: Check `jocActiu` at the beginning of the click handler and set it to `false` immediately upon first valid interaction.
- **[Risk]**: UI elements not found if names change in UXML.
- **[Mitigation]**: Ensure names match exactly ("btnParell", "btnSenar", etc.) or use flexible querying if necessary.
