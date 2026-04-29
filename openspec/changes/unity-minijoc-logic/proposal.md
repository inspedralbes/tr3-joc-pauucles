## Why

The project requires a set of 6 modular and independent 2D minigames to be executed within the Unity client. Decoupling the game logic from `MonoBehaviour` ensures that the rules are pure C# logic, making it easier to test, maintain, and reuse across different parts of the game (e.g., from the `Player` script).

## What Changes

- Implementation of 6 independent C# scripts in `Assets/Scripts/` for the following minigames:
    1. Rock-Paper-Scissors-Lizard-Spock (RPSTLLS).
    2. Evens or Odds (Parells o Senars).
    3. Gaze Snatching (Acaparament de Mirades).
    4. Force Dust (Polsim de Força).
    5. Stop the Bar (Atura la Barra).
    6. Stripped Cable (Cable Pelat).
- Each script will contain pure logic (no `MonoBehaviour`) to handle game states, results, and rules.
- Integration of the existing RPSTLLS logic defined in `plan.md` and `specs.md`.

## Capabilities

### New Capabilities
- `minijoc-logic`: A collection of pure C# logic components for 6 different 2D minigames, providing unified interfaces for determining game outcomes.

### Modified Capabilities
- `plan`: Integrating the planned implementation for the RPSTLLS minigame into the unified logic framework.

## Impact

- **Codebase**: New scripts in `Assets/Scripts/`.
- **Architecture**: Promotes a logic-first approach by separating game rules from Unity-specific rendering and input systems.
- **Dependencies**: No new external dependencies required; standard Unity and C# types only.
