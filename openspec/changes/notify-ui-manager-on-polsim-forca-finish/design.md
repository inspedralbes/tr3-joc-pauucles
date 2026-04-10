## Context

The `MinijocPolsimForcaLogic` handles the logic for the "Polsim de Força" minigame. When the game ends, it determines a winner but fails to notify the central `MinijocUIManager` to close the UI and finalize the combat state.

## Goals / Non-Goals

**Goals:**
- Ensure `MinijocUIManager` is notified when the minigame ends.
- Maintain existing winner determination logic.

**Non-Goals:**
- Do not modify the core gameplay mechanics of the minigame.
- Do not change how the winner is calculated.

## Decisions

- **Singleton Pattern Usage**: We will use `MinijocUIManager.Instance` to call the `FinalitzarCombat` method, following the established pattern in other minigame logic scripts.

## Risks / Trade-offs

- **Risk**: If `MinijocUIManager.Instance` is null, the game will crash.
- **Mitigation**: Ensure `MinijocUIManager` is properly initialized in the scene (this is already handled by the project's architecture).
