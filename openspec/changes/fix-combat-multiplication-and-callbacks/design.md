## Context

The current combat system in `MinijocUIManager` and `Player` is prone to race conditions and redundant event triggers. Players colliding multiple times in a single frame or very rapidly can cause the combat UI to try to open multiple times. Additionally, UI buttons accumulate listeners because they are not properly cleared, leading to multiple executions of the combat logic and inconsistent game states.

## Goals / Non-Goals

**Goals:**
- Implement a robust state management system in `MinijocUIManager`.
- Prevent redundant combat initiation from `Player.cs`.
- Ensure each combat round is resolved exactly once.
- Prevent memory leaks and redundant callback execution in the UI.

**Non-Goals:**
- Refactoring the entire minigame logic or adding new minigames.
- Changing the visual design of the UI.
- Modifying the core `Player` movement or collision physics beyond the combat trigger.

## Decisions

- **Decision 1: Centralized State in MinijocUIManager**
    - **Rationale:** Using `MinijocUIManager` as the single source of truth for combat state allows all players and systems to synchronize easily.
    - **Alternatives:** Individual player states (too complex to sync and manage globally).

- **Decision 2: Defensive Checks in Collision Handler**
    - **Rationale:** Checking `minijocActiu` in `Player.OnCollisionEnter2D` provides an early exit, saving processing time and preventing UI glitches before they propagate.
    - **Alternatives:** Handling everything inside `ShowUI` (would still cause multiple redundant calls to `ShowUI` which could be expensive).

- **Decision 3: Explicit Event Unbinding**
    - **Rationale:** Unity's UI Toolkit can accumulate listeners if `+=` is called multiple times on the same button instance. Using `-=` before `+=` or in a cleanup method ensures exactly one listener is active.
    - **Alternatives:** Re-instantiating the entire UI (too slow and resource-intensive).

## Risks / Trade-offs

- **[Risk] State Lock-up**: If `minijocActiu` remains `true` after combat, players will never be able to fight again.
    - **Mitigation**: Ensure `HideUI` ALWAYS resets `minijocActiu` to `false`.
- **[Risk] Missing Unbinding**: Forgetting to unbind an event in one specific minigame handler.
    - **Mitigation**: Standardize the cleanup pattern in `AmagarTotsElsContenidors` or specifically within each `Setup*` method.
