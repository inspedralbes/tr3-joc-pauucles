## Context

The Unity project requires 6 independent 2D minigames. One is already implemented (`MinijocPPTLLS.cs`). The remaining 5 need their logic layer implemented as pure C# scripts, ensuring they are decoupled from Unity's `MonoBehaviour` and scene-graph dependencies. This allows the `Player` or other game managers to instantiate and use the logic regardless of the visual representation.

## Goals / Non-Goals

**Goals:**
- Implement 5 new independent C# scripts for: Parells o Senars, Acaparament de Mirades, Polsim de Força, Atura la Barra, and Cable Pelat.
- Ensure all logic is testable and does not depend on Unity-specific lifecycle methods (e.g., `Start`, `Update`).
- Maintain a consistent API pattern across all minigame logic classes.

**Non-Goals:**
- Developing the UI, animations, or shaders for the minigames.
- Handling input hardware directly (scripts will receive values/events from a caller).
- Modifying existing `MonoBehaviour` components beyond integration if requested later.

## Decisions

- **Class-per-Minigame**: Each minigame will have its own dedicated C# class (e.g., `MinijocParellsSenarsLogic`).
- **Stateless/Minimal State**: Logic will prefer static methods for simple evaluations (like win/loss) or minimal state for progression-based games (like Force Dust).
- **Time Handling**: For time-sensitive games (Stop the Bar, Stripped Cable), the logic will accept `float` parameters for time/delta-time from the caller, rather than accessing `Time.time` directly, improving testability.
- **Enums for Outcomes**: Standardized enums like `GameResult { Success, Failure, Pending }` will be used to communicate state back to the caller.

## Risks / Trade-offs

- [Risk: Logic/UI Sync] -> Mitigation: Clearly define the state output of the logic scripts so the UI can accurately reflect it without logic leakage.
- [Risk: Timing Precision] -> Mitigation: Use high-precision `float` values for timing windows and provide clear "window" definitions in the logic.
- [Trade-off: No MonoBehaviour] -> While it requires manual updates from a caller, it significantly improves maintainability and decoupling.
