## Context

The "Acaparament de Mirades" minigame is one of several minigames triggered during combat. Currently, it lacks the functional logic to handle player choices, timers, and win conditions. The UI elements are defined in UXML but need to be linked and updated by the logic script.

## Goals / Non-Goals

**Goals:**
- Implement a fully functional "Acaparament de Mirades" minigame logic.
- Provide a clear UI feedback for the choice timer and the final result.
- Handle draws by physically pushing players apart to reset the combat state.

**Non-Goals:**
- Adding new sprites or animations (placeholder text/directions will be used).
- Changing the overall combat triggering system.

## Decisions

- **Two-Phase Loop**: The minigame will split into a `Choice Phase` (5s) and a `Revelation Phase` (3s). This allows players to see what happened before the UI closes.
- **Direct Input**: Using `Input.GetKeyDown` ensures that only the first valid key press per player is recorded during the choice phase.
- **Logic Location**: The core gameplay logic will reside in `MinijocAcaparamentMiradesLogic.cs`, while the post-combat physical consequences (AddForce) will be handled in `MinijocUIManager.cs` to access player Rigidbody references easily.
- **UI Interaction**: Use `VisualElement.Q` to find labels by name and update their `.text` property directly.

## Risks / Trade-offs

- **Risk**: Players might not realize they have made a choice since there's no visual confirmation until the revelation phase.
  - **Mitigation**: The design keeps choices secret until the end to prevent the second player from reacting to the first player's choice.
- **Risk**: `MinijocUIManager` might have null references if `_atacant` or `_defensor` are not set correctly.
  - **Mitigation**: Ensure `FinalitzarCombat` checks for nulls before applying `AddForce`.
